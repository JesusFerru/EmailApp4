namespace EmailApp4.Services
{
    public interface ITemplateService
    {
        Task<List<EmailTemplate>> GetTemplate();                 //Get
        Task<EmailTemplate> GetUniqueTemplate(int id);
        Task<EmailTemplate> PostTemplate(EmailTemplate body);      //Post
        Task<EmailTemplate> PutTemplate(int id, EmailTemplate body);       //Put
        Task<EmailTemplate> DeleteTemplate(int id);
        Task<bool> Verif(int id);
    }
}
