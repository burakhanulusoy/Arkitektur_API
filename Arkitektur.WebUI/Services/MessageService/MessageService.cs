using MailKit.Net.Smtp;
using MimeKit;

namespace Arkitektur.WebUI.Services.MessageService
{
    public class MessageService(IConfiguration configuration) :IMessageService
    {


        public async Task SendMessageAsync(string email, bool isCancelled, DateTime date)
        {
            var emailConfirmCode = configuration["Email:Code"];
            var adminEmail = "burakhanulusoy18@gmail.com";

            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Arkitektur Admin", adminEmail));
            mimeMessage.To.Add(new MailboxAddress("Değerli Müşterimiz", email));
            mimeMessage.Subject = "Arkitektur Mimarlık A.Ş. - Randevu Bilgilendirmesi";

            var bodyBuilder = new BodyBuilder();

            if (isCancelled)
            {
                bodyBuilder.TextBody = $"Sayın müşterimiz, şirketimizdeki yoğunluk nedeniyle {date:dd.MM.yyyy HH:mm} tarihindeki randevunuz iptal edilmiştir. Başka bir güne tekrardan randevu almanızı rica ederiz. Anlayışınız için teşekkür ederiz.";
            }
            else
            {
                bodyBuilder.TextBody = $"Sayın müşterimiz, randevunuz tarafımızca onaylanmıştır. Randevu tarihiniz: {date:dd.MM.yyyy HH:mm}. Sizinle tanışmak ve projelerimizi anlatmak için randevu saatinizde sizi bekliyoruz.";
            }

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync("smtp.gmail.com", 587,false);
                await client.AuthenticateAsync(adminEmail, emailConfirmCode);
                await client.SendAsync(mimeMessage);
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }

      
    }
}
