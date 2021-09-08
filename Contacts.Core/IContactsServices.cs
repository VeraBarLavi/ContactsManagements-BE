using Contacts.DB;
using System.Collections.Generic;

namespace Contacts.Core
{
    public interface IContactsServices
    {
        List<Contact> GetContacts();
        Contact GetContact(string id);
        Contact CreateContact(Contact contact);
        void DeleteContact(Contact contact);
        Contact EditContact(Contact contact);
    }
}
