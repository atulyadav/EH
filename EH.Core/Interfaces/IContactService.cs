namespace EH.Core.Interfaces
{
    using EH.Model;
    using System.Collections.Generic;

    public interface IContactService
    {
        IEnumerable<Model.Contact> GetAll();

        void Add(Contact contact);

        bool Exist(int key);

        bool Patch(Contact updatedContact);

        bool Put(Contact update);

        Contact Find(int key);
    }
}
