using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIExample.Models;
using WebAPIExample.Services;

namespace WebAPIExample.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository contactRepository;
        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }
        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }
    }
}