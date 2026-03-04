using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyJobPlatform.Domain.Entities;
using PharmacyJobPlatform.Infrastructure.Data;
using PharmacyJobPlatform.Web.Models.Support;
using System.Security.Claims;

namespace PharmacyJobPlatform.Web.Controllers
{
    [Authorize]
    public class SupportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupportController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SupportMessageCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SupportMessageCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var senderId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
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

            var supportMessage = $"[DESTEK] {model.Subject.Trim()}\n\n{model.Content.Trim()}";

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
