using Contacts.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Core
{
    public class ContactsServices : IContactsServices
    {
        private AppDbContext _context;

        public ContactsServices(AppDbContext context)
        {
            _context = context;
        }

        public List<Contact> GetContacts()
        {
            return _context.Contacts.ToList();
        }

        public Contact GetContact(string id)
        {
            return _context.Contacts.First(c => c.ID == id);
        }

        public Contact CreateContact(Contact contact)
        {
            var dbContact = _context.Contacts.FirstOrDefault(c => c.ID == contact.ID);
            if (dbContact != null)
            {
                throw new Exception("Contact with ID=" + contact.ID + " is already in use.");
            }

            _context.Add(contact);
            _context.SaveChanges();

            return contact;
        }

        public void DeleteContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public Contact EditContact(Contact contact)
        {
            var dbContact = _context.Contacts.First(c => c.ID == contact.ID);
            dbContact.FullName = contact.FullName;
            dbContact.Email = contact.Email;
            dbContact.DateOfBirth = contact.DateOfBirth;
            dbContact.Gender = contact.Gender;
            dbContact.PhoneNumber = contact.PhoneNumber;
            _context.SaveChanges();

            return dbContact;
        }
    }
}
