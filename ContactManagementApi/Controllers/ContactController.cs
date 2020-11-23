using ContactManagementApi.Filters;
using ContactManagementApi.Interfaces;
using ContactManagementApi.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace ContactManagementApi.Controllers
{
    [RoutePrefix("api/contact")]
    [ContactExceptionFilter]
    public class ContactController : ApiController
    {
        private readonly IContactRepository _contactRepo;

        public ContactController(IContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAllContacts()
        {         
            var contactList = _contactRepo.GetAllContacts();
            return Request.CreateResponse(HttpStatusCode.OK, contactList);
        }

        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage PostContact([FromBody]Contact contactModel)
        {
            if (ModelState.IsValid)
            {
                var isCreated = _contactRepo.CreateContact(contactModel);
                return Request.CreateResponse(HttpStatusCode.OK, isCreated);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
               
        }

        [Route("Edit/{Id:int}")]
        [HttpPut]
        public HttpResponseMessage PutContact([FromUri]int Id, [FromBody]Contact contactModel)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = _contactRepo.UpdateContact(Id, contactModel);
                return Request.CreateResponse(HttpStatusCode.OK, isUpdated);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("Delete/{Id:int}")]
        [HttpDelete]
        public HttpResponseMessage DeleteContact([FromUri]int Id)
        {
            var isDeleted = _contactRepo.DeleteContact(Id);
            return Request.CreateResponse(HttpStatusCode.OK, isDeleted);
        }
    }
}
