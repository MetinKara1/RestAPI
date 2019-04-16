using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIExample.Models;

namespace WebAPIExample.Services
{
    public class ContactRepository
    {
        public Contact[] GetAllContacts()
        {
            return new Contact[]
            {
                new Contact
                {
                    Id = 1,
                    Name = "Metin KARA"

                },
                new Contact
                {
                    Id = 2,
                    Name = "Mehmet KARA"
                }
            };
        }
    }
}