using Mobile_Store2.Data.Models;

namespace Mobile_Store2.Data.Repositories
{
    public interface IPhoneRepository
    {
        IEnumerable<Phone> GetAllPhones();
        Phone GetPhoneById(int id);
    }
}
