using EmailApp4.Data;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;

namespace EmailApp4.Services
{
    public class EmailService : IEmailService
    {
        private readonly AppDbContext _db;

        private readonly IConfiguration _config;

        public EmailService(IConfiguration config, AppDbContext db)
        {
            _config = config;
            _db = db;
        }
        public void SendEmail(DataEmail request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.AuthenticationMechanisms.Remove("XOAUTH2");
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);

            smtp.Send(email);
            smtp.Disconnect(true);
        }
        public async Task<List<DataEmail>> GetEmails()
        {

            return await _db.DataEmails.ToListAsync();
        }




        public async Task<DataEmail> PostEmail(DataEmail request)
        //public void SendEmail(DataEmail request)
        {
     /*       EmailTemplate template = await _db.Templates.FindAsync(new_email.IdTemplate);

            new_email.Body = template.BodyTemplate;
            new_email.Subject = template.NameTemplate; */

            var new_email = new DataEmail()
            {
                IdEmail = request.IdEmail,
                From = request.From,//_config.GetSection("EmailUsername").Value,
                To = request.To,
                Subject = request.Subject,
                Body = request.Body,
                Date = request.Date, //     DateTime.Now.Date,
              //  IdTemplate = request.IdTemplate,
            };


            await _db.AddAsync(new_email);
            await _db.SaveChangesAsync();
            return request;
        }

        public async Task<DataEmail> PutEmail(int id, DataEmail request)
        {
            var EmailSaved = _db.DataEmails.Find(id);
            if (EmailSaved != null)
            {
                EmailSaved.To = request.To;
                EmailSaved.From = request.From;
                EmailSaved.Subject = request.Subject;
                EmailSaved.Body = request.Body;
                EmailSaved.Date = DateTime.Now.Date;
             //   EmailSaved.IdTemplate = request.IdTemplate;


                _db.Update(EmailSaved);
                await _db.SaveChangesAsync();

                return EmailSaved;
            }
            else return null;
        }

        public async Task<DataEmail> DeleteEmail(int id)
        {
            var EmailSaved = _db.DataEmails.Find(id);
            if (EmailSaved != null)
            {
                _db.Remove(EmailSaved);
                await _db.SaveChangesAsync();
                return EmailSaved;
            }
            else return null;
        }
    }
}
