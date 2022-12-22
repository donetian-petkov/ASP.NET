using Contacts.Contracts;
using Contacts.Data.Models;
using Contacts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Contacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IContactService contactService;
        private readonly UserManager<ApplicationUser> userManager;

        public ContactsController(
            IContactService _contactService,
            UserManager<ApplicationUser> _userManager
            )
        {
            contactService = _contactService;
            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await contactService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Team()
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await contactService.GetTeamContactsAsync(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddContactViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await contactService.AddContactAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> AddToTeam(int contactId)
        {
            try
            {


                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                await contactService.AddContactToTeamAsync(contactId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromTeam(int contactId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await contactService.RemoveContactFromTeamAsync(contactId, userId);

            return RedirectToAction(nameof(Team));
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromQuery] int contactId)
        {

            var contact = await contactService.GetContactById(contactId);

            var model = new ContactEditViewModel()
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Address = contact.Address,
                PhoneNumber = contact.PhoneNumber,
                Website = contact.Website
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, ContactEditViewModel model)
        {

            if (ModelState.IsValid == false)
            {
                
                return View(model);
            }

            await contactService.Edit(Id, model);

            return RedirectToAction("All", "Contacts");
        }



    }


}

