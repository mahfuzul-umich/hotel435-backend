using hotel435.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace hotel435.Services
{
    public class MailService : IMailService
    {
        public async Task SendSummaryEmailAsync(Reservation reservation)
        {
            var builder = new StringBuilder();

            using var reader = System.IO.File.OpenText("EmailTemplate/summary_template.html");
            builder.Append(reader.ReadToEnd());

            builder.Replace("{{name}}", $"{reservation.FirstName} {reservation.LastName}");
            builder.Replace("{{checkIn}}", $"{reservation.ActualCheckIn.Value.ToString("dd MMMM yyyy hh:mm:ss tt")} - UTC");
            builder.Replace("{{checkOut}}", $"{reservation.ActualCheckOut.Value.ToString("dd MMMM yyyy hh:mm:ss tt")} - UTC");
            builder.Replace("{{amount}}", $"${reservation.Price}");

            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("cis435hotel435@gmail.com", "Cis435Hotel435!")
            };

            using (var message = new MailMessage("cis435hotel435@gmail.com", $"{reservation.Email}")
            {
                Subject = "Hotel435 Confirmation",
                Body = builder.ToString(),
                IsBodyHtml = true
            })
            {
                await smtpClient.SendMailAsync(message);
            }
        }

        public async Task SendConfirmationEmailAsync(Reservation reservation)
        {
            var builder = new StringBuilder();

            using var reader = System.IO.File.OpenText("EmailTemplate/confirmation_template.html");
            builder.Append(reader.ReadToEnd());

            builder.Replace("{{name}}", $"{reservation.FirstName} {reservation.LastName}");
            builder.Replace("{{checkIn}}", $"{reservation.CheckIn.ToString("dd MMMM yyyy hh:mm:ss tt")} - UTC");
            builder.Replace("{{checkOut}}", $"{reservation.CheckOut.ToString("dd MMMM yyyy hh:mm:ss tt")} - UTC");
            builder.Replace("{{amount}}", $"${reservation.Price}");
            builder.Replace("{{confirmation}}", $"{reservation.ConfirmationNumber}");

            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("cis435hotel435@gmail.com", "Cis435Hotel435!")
            };

            using (var message = new MailMessage("cis435hotel435@gmail.com", $"{reservation.Email}")
            {
                Subject = "Hotel435 Confirmation",
                Body = builder.ToString(),
                IsBodyHtml = true
            })
            {
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
