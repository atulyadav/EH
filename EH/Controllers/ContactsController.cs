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
            var list = this.contactService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, list);
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

            var exist = this.contactService.Exist(key);

            if (!exist)
            {
                return NotFound();
            }

            var updatedContact = new Contact();
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
