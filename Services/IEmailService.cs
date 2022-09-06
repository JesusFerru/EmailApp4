using EmailApp4.Data;

namespace EmailApp4.Services
{
    public interface IEmailService
    {
        void SendEmail(DataEmail request);
        Task<List<DataEmail>> GetEmails();                 //Get
        Task<DataEmail> PostEmail(DataEmail request);      //Post
        Task<DataEmail> PutEmail(int id, DataEmail body);       //Put
        Task<DataEmail> DeleteEmail(int id);               //Delete
    }
}
