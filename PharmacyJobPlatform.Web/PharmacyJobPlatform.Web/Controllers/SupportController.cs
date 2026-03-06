using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyJobPlatform.Domain.Entities;
using PharmacyJobPlatform.Infrastructure.Data;
using PharmacyJobPlatform.Web.Models.Support;
using System.Security.Claims;

namespace PharmacyJobPlatform.Web.Controllers
{
    [AllowAnonymous]
    public class SupportController : Controller
    {
        private const string SystemUserEmail = "system@pharmacyjobplatform.local";
        private readonly ApplicationDbContext _context;

        public SupportController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SupportMessageCreateViewModel
            {
                Email = User.Identity?.IsAuthenticated == true ? User.Identity.Name ?? string.Empty : string.Empty
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SupportMessageCreateViewModel model)
        {
            var isAuthenticated = User.Identity?.IsAuthenticated == true;
            var effectiveEmail = isAuthenticated
                ? User.FindFirstValue(ClaimTypes.Email) ?? User.Identity?.Name ?? string.Empty
                : model.Email?.Trim() ?? string.Empty;

            if (!isAuthenticated && string.IsNullOrWhiteSpace(effectiveEmail))
            {
                ModelState.AddModelError(nameof(model.Email), "E-posta adresi zorunludur.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var senderId = await _context.Users
                .AsNoTracking()
                .Where(u => u.Email == SystemUserEmail && !u.IsDeleted)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();

            if (senderId == 0)
            {
                TempData["Error"] = "Sistem hesabı bulunamadı. Lütfen daha sonra tekrar deneyin.";
                return RedirectToAction(nameof(Index));
            }


            var adminUserId = await _context.Users
                .AsNoTracking()
                .Where(u => u.Role.Name == "Admin" && !u.IsDeleted)
                .OrderBy(u => u.Id)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();

            if (adminUserId == 0)
            {
                TempData["Error"] = "Şu anda ulaşılabilir bir admin bulunamadı. Lütfen daha sonra tekrar deneyin.";
                return RedirectToAction(nameof(Index));
            }

            var user1Id = Math.Min(senderId, adminUserId);
            var user2Id = Math.Max(senderId, adminUserId);

            var conversation = await _context.Conversations.FirstOrDefaultAsync(c =>
                c.User1Id == user1Id &&
                c.User2Id == user2Id &&
                c.EndedAt == null);

            if (conversation == null)
            {
                conversation = new Conversation
                {
                    User1Id = user1Id,
                    User2Id = user2Id,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Conversations.Add(conversation);
                await _context.SaveChangesAsync();
            }

            var supportMessage = $"[DESTEK] {model.Subject.Trim()}\n[E-POSTA] {effectiveEmail}\n\n{model.Content.Trim()}";

            _context.Messages.Add(new Message
            {
                ConversationId = conversation.Id,
                SenderId = senderId,
                Content = supportMessage,
                SentAt = DateTime.UtcNow,
                IsRead = false,
                IsSupportMessage = true,
                IsSupportReviewed = false
            });

            await _context.SaveChangesAsync();

            TempData["Success"] = "Destek mesajınız admin ekibine iletildi. En kısa sürede dönüş yapılacaktır.";
            return RedirectToAction(nameof(Index));
        }
    }
}
