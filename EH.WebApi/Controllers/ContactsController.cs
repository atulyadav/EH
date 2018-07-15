namespace EH.Controllers
{
    using EH.Core.Interfaces;
    using EH.Model;
    using Microsoft.AspNet.OData;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class ContactsController : ODataController
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        
        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage GetContacts()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.contactService.GetAll());
        }

        [HttpPost]
        public IHttpActionResult Post(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.contactService.Add(contact);
            return Created(contact);
        }

        [HttpPatch]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Contact> contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!this.contactService.Exist(key))
            {
                return NotFound();
            }

            var updatedContact = this.contactService.Find(key);
            contact.Patch(updatedContact);
            bool hasUpdated = this.contactService.Patch(updatedContact);

           if(!hasUpdated)
            {
                Request.CreateResponse(HttpStatusCode.BadRequest, "unbale to update");
            }

            return Updated(contact);

        }

        [HttpPut]
        public IHttpActionResult Put([FromODataUri] int key, Contact update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != update.Id)
            {
                return BadRequest();
            }

            bool hasUpdated = this.contactService.Put(update);
            if (!hasUpdated)
            {
                Request.CreateResponse(HttpStatusCode.BadRequest, "unbale to update");
            }

            return Updated(update);
        }
    }
}
