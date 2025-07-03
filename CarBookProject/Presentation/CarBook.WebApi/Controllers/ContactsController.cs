using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.ReadHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.WriteHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetContactByIdQueryHandler _getContactById;
        private readonly GetContactQueryHandler _getContact;
        private readonly CreateContactCommandHandler _createContact;
        private readonly UpdateContactCommandHandler _updateContact;
        private readonly DeleteContactCommandHandler _deleteContact;
        public ContactsController(GetContactByIdQueryHandler getContactById, GetContactQueryHandler getContact, CreateContactCommandHandler createContact, UpdateContactCommandHandler updateContact, DeleteContactCommandHandler deleteContact)
        {
            _getContactById = getContactById;
            _getContact = getContact;
            _createContact = createContact;
            _updateContact = updateContact;
            _deleteContact = deleteContact;
        }
        [HttpGet]
        public async Task<IActionResult> GetContact()
        {
            var values = await _getContact.Handle();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("İletişim Listesi Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var value = await _getContactById.Handle(new GetContactByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("İletişim Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand c)
        {
            await _createContact.Handle(c);
            return Ok("İletişim Eklemesi Başarıyla Yapıldı!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand c)
        {
            await _updateContact.Handle(c);
            return Ok("İletişim Güncellemesi Başarıyla Yapıldı!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _deleteContact.Handle(new DeleteContactCommand(id));
            return Ok("İletişim Başarıyla Silindi!");
        }
    }
}
