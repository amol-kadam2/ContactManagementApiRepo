using ContactManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementApi.Interfaces
{
    public interface IContactRepository
    {
       IEnumerable<Contact> GetAllContacts();
       bool CreateContact(Contact contact);
       bool UpdateContact(int id, Contact contact);
       bool DeleteContact(int id);
    }
}
