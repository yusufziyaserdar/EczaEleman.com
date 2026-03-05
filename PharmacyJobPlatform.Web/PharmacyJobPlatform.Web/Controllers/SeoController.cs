using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PharmacyJobPlatform.Web.Controllers
{
    [AllowAnonymous]
    public class SeoController : Controller
    {
        [HttpGet("robots.txt")]
        public IActionResult Robots()
        {
            var sitemapUrl = $"{Request.Scheme}://{Request.Host}/sitemap.xml";

            var content = string.Join('\n', new[]
            {
                "User-agent: *",
                "Allow: /",
                string.Empty,
                "Disallow: /Admin",
                "Disallow: /Messages",
                "Disallow: /Support",
                "Disallow: /WorkerDashboard",
                "Disallow: /PharmacyDashboard",
                "Disallow: /PharmacyApplications",
                "Disallow: /JobApplications",
                "Disallow: /JobPosts",
                "Disallow: /Conversations",
                "Disallow: /Reports",
                "Disallow: /Profile",
                "Disallow: /Auth/Login",
                "Disallow: /Auth/Logout",
                "Disallow: /Auth/ConfirmEmail",
                string.Empty,
                $"Sitemap: {sitemapUrl}"
            });

            return Content(content, "text/plain", Encoding.UTF8);
        }

        [HttpGet("sitemap.xml")]
        public IActionResult Sitemap()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var today = DateTime.UtcNow.Date;

            var urls = new List<SitemapUrl>
            {
                new($"{baseUrl}/", today, "daily", "1.0"),
                new($"{baseUrl}/Home/Privacy", today, "monthly", "0.3"),
                new($"{baseUrl}/Auth/Register", today, "weekly", "0.8")
            };

            var sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

            foreach (var item in urls)
            {
                sb.AppendLine("  <url>");
                sb.AppendLine($"    <loc>{item.Location}</loc>");
                sb.AppendLine($"    <lastmod>{item.LastModified:yyyy-MM-dd}</lastmod>");
                sb.AppendLine($"    <changefreq>{item.ChangeFrequency}</changefreq>");
                sb.AppendLine($"    <priority>{item.Priority}</priority>");
                sb.AppendLine("  </url>");
            }

            sb.AppendLine("</urlset>");

            return Content(sb.ToString(), "application/xml", Encoding.UTF8);
        }

        private sealed record SitemapUrl(string Location, DateTime LastModified, string ChangeFrequency, string Priority);
    }
}