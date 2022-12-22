using Contacts.Models;

namespace Contacts.Contracts
{
    public interface IContactService
    {
        Task<IEnumerable<ContactViewModel>> GetAllAsync();

        Task<IEnumerable<ContactViewModel>> GetTeamContactsAsync(string userId);

        Task AddContactAsync(AddContactViewModel model);

        Task AddContactToTeamAsync(int contactId, string userId);

        Task RemoveContactFromTeamAsync(int contactId, string userId);

        Task<ContactEditViewModel> GetContactById (int contactId);

        Task Edit(int contactId, ContactEditViewModel model);

    }
}
