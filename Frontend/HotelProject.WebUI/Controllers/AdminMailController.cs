using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "yasindenizcure@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); //kimden

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo); //kime

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); //mesaj

            mimeMessage.Subject = model.Subject; //konu

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("yasindenizcure@gmail.com", "qbvr oazz mlto glay");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
    }
}
