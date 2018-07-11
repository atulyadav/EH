namespace EH.Core.Repositories
{
    using EH.Model;

    public interface IContactRepository : IGenericRepository<Contact>
    {
        bool Exist(int key);
        bool Patch(Contact updatedContact);
        bool Put(Contact update);
        Contact Find(int key);
    }
}
