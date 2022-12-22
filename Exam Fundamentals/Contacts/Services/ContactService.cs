using Contacts.Contracts;
using Contacts.Data;
using Contacts.Data.Common;
using Contacts.Data.Models;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactsDbContext context;
        private readonly IRepository repo;
        public ContactService(ContactsDbContext _context,
            IRepository _repo)
        {
            context = _context;
            repo = _repo;
        }

        public async Task AddContactAsync(AddContactViewModel model)
        {
            var entity = new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Website = model.Website,
            };

            await context.Contacts.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddContactToTeamAsync(int contactId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersContacts)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var contact = await context.Contacts.FirstOrDefaultAsync(u => u.Id == contactId);

            if (contact == null)
            {
                throw new ArgumentException("Invalid Contact ID");
            }

            if (!user.ApplicationUsersContacts.Any(m => m.ContactId == contactId))
            {
                user.ApplicationUsersContacts.Add(new ApplicationUserContact()
                {
                    ContactId = contact.Id,
                    ApplicationUserId = user.Id,
                    Contact = contact,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ContactViewModel>> GetAllAsync()
        {
            var entities = await context.Contacts
                .ToListAsync();

            return entities
                .Select(model => new ContactViewModel()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Website = model.Website,
                });
        }

        public async Task<ContactEditViewModel> GetContactById(int contactId)
        {
            return await repo.AllReadonly<Contact>()
               .Where(h => h.Id == contactId)
               .Select(model => new ContactEditViewModel()
               {
                   Id = model.Id,
                   FirstName = model.FirstName,
                   LastName = model.LastName,
                   Email = model.Email,
                   Address = model.Address,
                   PhoneNumber = model.PhoneNumber,
                   Website = model.Website,
               })
               .FirstAsync();
        }

        public async Task Edit(int contactId, ContactEditViewModel model)
        {
            var contact = await repo.GetByIdAsync<Contact>(contactId);

            contact.Id = model.Id;
            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Email = model.Email;
            contact.Address = model.Address;
            contact.PhoneNumber = model.PhoneNumber;
            contact.Website = model.Website;


            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactViewModel>> GetTeamContactsAsync(string userId)
        {
            var user = await context.Users
               .Where(u => u.Id == userId)
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.ApplicationUsersContacts
                .Select(m => new ContactViewModel()
                {
                    FirstName = m.Contact.FirstName,
                    LastName = m.Contact.LastName,
                    Email = m.Contact.Email,
                    Address = m.Contact.Address,
                    PhoneNumber = m.Contact.PhoneNumber,
                    Website = m.Contact.Website,
                });
        }

        public async Task RemoveContactFromTeamAsync(int contactId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersContacts)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var contact = user.ApplicationUsersContacts.FirstOrDefault(m => m.ContactId == contactId);

            if (contact != null)
            {
                user.ApplicationUsersContacts.Remove(contact);

                await context.SaveChangesAsync();
            }
        }
    }
}
