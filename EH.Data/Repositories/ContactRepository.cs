namespace EH.Core.Repositories
{
    using EH.Data;
    using EH.Model;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System;

    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(EHDataContext context) : base(context)
        {
        }

        public bool Exist(int key)
        {
            return this.EHDataContext.Contacts.Any(c => c.Id == key);
        }

        public bool Patch(Contact updatedContact)
        {
            var contact = this.EHDataContext.Contacts.Find(updatedContact.Id);
            contact = updatedContact;
            try
            {
                return context.SaveChanges() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                // TODO Log exception or thow
                return false;
            }
        }

        public bool Put(Contact update)
        {
            try
            {
                this.EHDataContext.Entry(update).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                // TODO Log exception or thow
                return false;
            }
        }

        public Contact Find(int key)
        {
            return this.EHDataContext.Contacts.FirstOrDefault(c => c.Id == key);
        }

        public EHDataContext EHDataContext
        {
            get { return this.context as EHDataContext; }
        }
    }
}
