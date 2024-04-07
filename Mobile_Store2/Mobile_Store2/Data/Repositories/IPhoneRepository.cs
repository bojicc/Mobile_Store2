using Mobile_Store2.Data.Models;

namespace Mobile_Store2.Data.Repositories
{
    public interface IPhoneRepository
    {
        Phone GetPhoneById(int id);
        IEnumerable<Phone> GetAllPhones();
        void AddPhone(Phone phone);
        void UpdatePhone(Phone phone);
        void DeletePhone(int id);

        //Phone GetPhoneById(int id);
        //IEnumerable<Phone> GetAllPhones();
        //void CreatePhone(Phone phone);
        //void UpdatePhone(Phone phone);
        //void DeletePhone(int id);
    }
}
