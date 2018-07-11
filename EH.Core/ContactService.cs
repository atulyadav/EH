using EH.Core.Interfaces;
using EH.Core.Repositories;
using EH.Model;
using EH.Utility;
using System.Collections.Generic;

namespace EH.Core
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        
        public void Add(Contact contact)
        {
            if(EmailValidator.IsValidEmail(contact.EmailId))
            {
                // TODO 
            }

            this.contactRepository.Add(contact);
            this.contactRepository.Save();
        }

        public bool Exist(int key)
        {
            return this.contactRepository.Exist(key);
        }

        public Contact Find(int key)
        {
            return this.contactRepository.Find(key);
        }

        public IEnumerable<Contact> GetAll()
        {
            var list = this.contactRepository.GetAll();
            return list;
        }

        public bool Patch(Contact update)
        {
            return this.contactRepository.Patch(update);
        }

        public bool Put(Contact update)
        {
            return this.contactRepository.Put(update);
        }
    }
}
