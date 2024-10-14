using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BalMutfak.Models;
using System.Net;
using System.Net.Mail;

namespace BalMutfak.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Brownie beyaz çikolata", Description = "Beyaz çikolatanın yoğun brownie ile müthiş uyumu.", ImageUrl = "~/images/Desserts/beyazcikolatalibrowni.png" },
            new Product { Id = 2, Name = "Budapeşte", Description = "Unutulmaz bir tatlı deneyimi için zengin ve yoğun lezzet.", ImageUrl = "~/images//Desserts/budapeste.png" },
            new Product { Id = 3, Name = "Chia puding", Description = "Hafif ve sağlıklı, chia tohumlarının lezzetle dansı.", ImageUrl = "~/images//Desserts/chiapuding.png" },
            new Product { Id = 4, Name = "Çilekli tart", Description = "Kıtır taban, taze çilek ve kremanın kusursuz dengesi.", ImageUrl = "~/images//Desserts/tartcilekli.png" },
            new Product { Id = 5, Name = "Çilek magnolya", Description = "Taze çileklerle hafif ve ferahlatıcı bir lezzet!", ImageUrl = "~/images//Desserts/cilekmagnolya.png" },
            new Product { Id = 6, Name = "Cookie", Description = "Dışı çıtır, içi yumuşak klasik cookie lezzeti.", ImageUrl = "~/images//Desserts/cookie.png" },
            new Product { Id = 7, Name = "Cream puff", Description = "Dışı çıtır, içi yumuşacık kremayla dolu lezzet bombası.", ImageUrl = "~/images//Desserts/creampuffs.png" },
            new Product { Id = 8, Name = "Havuçlu kek", Description = "Havuç ve tarçının harika birlikteliğiyle yumuşacık kek.", ImageUrl = "~/images//Desserts/havuclukek.png" },
            new Product { Id = 9, Name = "Ibiza", Description = "Tropikal esintilerle dolu ferah bir tatlı deneyimi.", ImageUrl = "~/images//Desserts/ibizatatlisi.png" },
            new Product { Id = 10, Name = "Lotus cheesecake", Description = "Lotus bisküvi ile harmanlanmış hafif cheesecake.", ImageUrl = "~/images//Desserts/lotuscheesecake.png" },
            new Product { Id = 11, Name = "Mois", Description = "Yoğun çikolata severler için vazgeçilmez bir tatlı!", ImageUrl = "~/images//Desserts/moispasta.png" },
            new Product { Id = 12, Name = "Muzlu rulo", Description = "Yumuşacık rulo kek ve taze muzun muhteşem birleşimi.", ImageUrl = "~/images//Desserts/rulopasta.png" },
            new Product { Id = 13, Name = "Muz magnolya", Description = "Taptaze muzlu, kremalı ve çıtır lezzet şöleni!", ImageUrl = "~/images//Desserts/muzlumagnolya.png" },
            new Product { Id = 14, Name = "Nutella magnolya", Description = "Nutella'nın enfes dokunuşuyla sütlü tatlının eşsiz buluşması!", ImageUrl = "~/images//Desserts/nutellamagnolya.png" },
            new Product { Id = 15, Name = "Nutella muffin", Description = "Yoğun Nutella dolgulu, yumuşak ve nefis muffin!", ImageUrl = "~/images//Desserts/nutellamuffins.png" },
            new Product { Id = 16, Name = "Oreo pasta", Description = "Kremalı Oreo katmanlarıyla tam bir lezzet patlaması.", ImageUrl = "~/images//Desserts/oreolupasta.png" },
            new Product { Id = 17, Name = "San Sebastian", Description = "İspanyol usulü, içi akışkan yumuşacık cheesecake.", ImageUrl = "~/images//Desserts/sansebastian.png" },
            new Product { Id = 18, Name = "Snickers cake", Description = "Fıstık ve karamelin çikolata ile buluştuğu tatlı kaçamak.", ImageUrl = "~/images//Desserts/snickerscake.png" },
            new Product { Id = 19, Name = "Trio", Description = "Üç farklı lezzetin tek tabakta buluştuğu mükemmel uyum.", ImageUrl = "~/images//Desserts/trio.png" },
        };
        return View(products);
    }

    public IActionResult Catalog()
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Brownie beyaz çikolata", Description = "Beyaz çikolatanın yoğun brownie ile müthiş uyumu.", ImageUrl = "~/images/Desserts/beyazcikolatalibrowni.png" },
            new Product { Id = 2, Name = "Budapeşte", Description = "Unutulmaz bir tatlı deneyimi için zengin ve yoğun lezzet.", ImageUrl = "~/images//Desserts/budapeste.png" },
            new Product { Id = 3, Name = "Chia puding", Description = "Hafif ve sağlıklı, chia tohumlarının lezzetle dansı.", ImageUrl = "~/images//Desserts/chiapuding.png" },
            new Product { Id = 4, Name = "Çilekli tart", Description = "Kıtır taban, taze çilek ve kremanın kusursuz dengesi.", ImageUrl = "~/images//Desserts/tartcilekli.png" },
            new Product { Id = 5, Name = "Çilek magnolya", Description = "Taze çileklerle hafif ve ferahlatıcı bir lezzet!", ImageUrl = "~/images//Desserts/cilekmagnolya.png" },
            new Product { Id = 6, Name = "Cookie", Description = "Dışı çıtır, içi yumuşak klasik cookie lezzeti.", ImageUrl = "~/images//Desserts/cookie.png" },
            new Product { Id = 7, Name = "Cream puff", Description = "Dışı çıtır, içi yumuşacık kremayla dolu lezzet bombası.", ImageUrl = "~/images//Desserts/creampuffs.png" },
            new Product { Id = 8, Name = "Havuçlu kek", Description = "Havuç ve tarçının harika birlikteliğiyle yumuşacık kek.", ImageUrl = "~/images//Desserts/havuclukek.png" },
            new Product { Id = 9, Name = "Ibiza", Description = "Tropikal esintilerle dolu ferah bir tatlı deneyimi.", ImageUrl = "~/images//Desserts/ibizatatlisi.png" },
            new Product { Id = 10, Name = "Lotus cheesecake", Description = "Lotus bisküvi ile harmanlanmış hafif cheesecake.", ImageUrl = "~/images//Desserts/lotuscheesecake.png" },
            new Product { Id = 11, Name = "Mois", Description = "Yoğun çikolata severler için vazgeçilmez bir tatlı!", ImageUrl = "~/images//Desserts/moispasta.png" },
            new Product { Id = 12, Name = "Muzlu rulo", Description = "Yumuşacık rulo kek ve taze muzun muhteşem birleşimi.", ImageUrl = "~/images//Desserts/rulopasta.png" },
            new Product { Id = 13, Name = "Muz magnolya", Description = "Muzun tatlı aromasıyla kremsi bir şölen.", ImageUrl = "~/images//Desserts/muzlumagnolya.png" },
            new Product { Id = 14, Name = "Nutella magnolya", Description = "Nutella'nın enfes dokunuşuyla sütlü tatlının eşsiz buluşması!", ImageUrl = "~/images//Desserts/nutellamagnolya.png" },
            new Product { Id = 15, Name = "Nutella muffin", Description = "Nutella dolgulu, yumuşacık muffin keyfi!", ImageUrl = "~/images//Desserts/nutellamuffins.png" },
            new Product { Id = 16, Name = "Oreo pasta", Description = "Kremalı Oreo katmanlarıyla tam bir lezzet patlaması.", ImageUrl = "~/images//Desserts/oreolupasta.png" },
            new Product { Id = 17, Name = "San Sebastian", Description = "İspanyol usulü, içi akışkan yumuşacık cheesecake.", ImageUrl = "~/images//Desserts/sansebastian.png" },
            new Product { Id = 18, Name = "Snickers cake", Description = "Fıstık ve karamelin çikolata ile buluştuğu tatlı kaçamak.", ImageUrl = "~/images//Desserts/snickerscake.png" },
            new Product { Id = 19, Name = "Trio", Description = "Üç farklı lezzetin tek tabakta buluştuğu mükemmel uyum.", ImageUrl = "~/images//Desserts/trio.png" },
        };

        return View("_Catalog", products);
    }

    public IActionResult SearchResult(string searchTerm)
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Brownie beyaz çikolata", Description = "Beyaz çikolatanın yoğun brownie ile müthiş uyumu.", ImageUrl = "~/images/Desserts/beyazcikolatalibrowni.png" },
            new Product { Id = 2, Name = "Budapeşte", Description = "Unutulmaz bir tatlı deneyimi için zengin ve yoğun lezzet.", ImageUrl = "~/images//Desserts/budapeste.png" },
            new Product { Id = 3, Name = "Chia puding", Description = "Hafif ve sağlıklı, chia tohumlarının lezzetle dansı.", ImageUrl = "~/images//Desserts/chiapuding.png" },
            new Product { Id = 4, Name = "Çilekli tart", Description = "Kıtır taban, taze çilek ve kremanın kusursuz dengesi.", ImageUrl = "~/images//Desserts/tartcilekli.png" },
            new Product { Id = 5, Name = "Çilek magnolya", Description = "Taze çileklerle hafif ve ferahlatıcı bir lezzet!", ImageUrl = "~/images//Desserts/cilekmagnolya.png" },
            new Product { Id = 6, Name = "Cookie", Description = "Dışı çıtır, içi yumuşak klasik cookie lezzeti.", ImageUrl = "~/images//Desserts/cookie.png" },
            new Product { Id = 7, Name = "Cream puff", Description = "Dışı çıtır, içi yumuşacık kremayla dolu lezzet bombası.", ImageUrl = "~/images//Desserts/creampuffs.png" },
            new Product { Id = 8, Name = "Havuçlu kek", Description = "Havuç ve tarçının harika birlikteliğiyle yumuşacık kek.", ImageUrl = "~/images//Desserts/havuclukek.png" },
            new Product { Id = 9, Name = "Ibiza", Description = "Tropikal esintilerle dolu ferah bir tatlı deneyimi.", ImageUrl = "~/images//Desserts/ibizatatlisi.png" },
            new Product { Id = 10, Name = "Lotus cheesecake", Description = "Lotus bisküvi ile harmanlanmış hafif cheesecake.", ImageUrl = "~/images//Desserts/lotuscheesecake.png" },
            new Product { Id = 11, Name = "Mois", Description = "Yoğun çikolata severler için vazgeçilmez bir tatlı!", ImageUrl = "~/images//Desserts/moispasta.png" },
            new Product { Id = 12, Name = "Muzlu rulo", Description = "Yumuşacık rulo kek ve taze muzun muhteşem birleşimi.", ImageUrl = "~/images//Desserts/rulopasta.png" },
            new Product { Id = 13, Name = "Muz magnolya", Description = "Muzun tatlı aromasıyla kremsi bir şölen.", ImageUrl = "~/images//Desserts/muzlumagnolya.png" },
            new Product { Id = 14, Name = "Nutella magnolya", Description = "Nutella'nın enfes dokunuşuyla sütlü tatlının eşsiz buluşması!", ImageUrl = "~/images//Desserts/nutellamagnolya.png" },
            new Product { Id = 15, Name = "Nutella muffin", Description = "Nutella dolgulu, yumuşacık muffin keyfi!", ImageUrl = "~/images//Desserts/nutellamuffins.png" },
            new Product { Id = 16, Name = "Oreo pasta", Description = "Kremalı Oreo katmanlarıyla tam bir lezzet patlaması.", ImageUrl = "~/images//Desserts/oreolupasta.png" },
            new Product { Id = 17, Name = "San Sebastian", Description = "İspanyol usulü, içi akışkan yumuşacık cheesecake.", ImageUrl = "~/images//Desserts/sansebastian.png" },
            new Product { Id = 18, Name = "Snickers cake", Description = "Fıstık ve karamelin çikolata ile buluştuğu tatlı kaçamak.", ImageUrl = "~/images//Desserts/snickerscake.png" },
            new Product { Id = 19, Name = "Trio", Description = "Üç farklı lezzetin tek tabakta buluştuğu mükemmel uyum.", ImageUrl = "~/images//Desserts/trio.png" },
        };
        // Arama işlemi
        var filteredProducts = products
            .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // SearchTerm'i ViewBag'e aktar
        ViewBag.SearchTerm = searchTerm;

        return View(filteredProducts);
    }

    public IActionResult Support()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SendEmail(string name, string surname, string email, string message)
    {
        try
        {
            // Mail mesajını oluşturuyoruz
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("erenmeral02@gmail.com"); // SMTP sunucusuna kayıtlı mail adresi
            mail.To.Add("erenmeral02@gmail.com"); // Alıcı mail adresi
            mail.Subject = "Yeni İletişim Mesajı";
            mail.Body = $"İsim: {name}\nSoyisim: {surname}\nE-posta: {email}\nMesaj: {message}";

            // Kullanıcının e-posta adresini Reply-To olarak ekliyoruz
            mail.ReplyToList.Add(new MailAddress(email));

            // SMTP sunucusu bilgileri
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential("erenmeral02@gmail.com", "voki eewb efdr fhyy");
            smtpServer.EnableSsl = true;

            // Mail gönderimi
            smtpServer.Send(mail);
            return Json(new { success = true, responseText = "Mesaj başarıyla gönderildi." });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, responseText = $"Mail gönderimi başarısız: {ex.Message}" });
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
