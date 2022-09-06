using EmailApp4.Data;
using Microsoft.EntityFrameworkCore;

namespace EmailApp4.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly AppDbContext _db;

        //private readonly IConfiguration _config;

        public TemplateService(AppDbContext db)
        {
            //_config = config;
            _db = db;
        }
        public async Task<List<EmailTemplate>> GetTemplate()
        {
            return await _db.Templates.ToListAsync();

        }

        public async Task<EmailTemplate> GetUniqueTemplate(int id)
        {

            return await _db.Templates.FindAsync(id);   //FirstOrDefaultAsync(m => m.IdTemplate == id);
        }

        public async Task<EmailTemplate> PostTemplate(EmailTemplate body)
        {
            //      if (TemplateExist(body.IdTemplate)) { } 
            var new_Template = new EmailTemplate()
            {
                IdTemplate = body.IdTemplate,
                NameTemplate = body.NameTemplate,
                BodyTemplate = body.BodyTemplate,
            };
            await _db.AddAsync(new_Template);
            await _db.SaveChangesAsync();
            return body;
        }

        public async Task<EmailTemplate> PutTemplate(int id, EmailTemplate body)
        {
            var TemplateSaved = _db.Templates.Find(id);
            if (TemplateSaved != null)
            {
                TemplateSaved.NameTemplate = body.NameTemplate;
                TemplateSaved.BodyTemplate = body.BodyTemplate;

                _db.Update(TemplateSaved);
                await _db.SaveChangesAsync();

                return TemplateSaved;
            }
            else return null;
        }
        public async Task<EmailTemplate> DeleteTemplate(int id)
        {
            var TemplateSaved = _db.Templates.Find(id);
            if (TemplateSaved != null)
            {
                _db.Remove(TemplateSaved);
                await _db.SaveChangesAsync();
                return TemplateSaved;
            }
            else return null;
        }
    }
}
