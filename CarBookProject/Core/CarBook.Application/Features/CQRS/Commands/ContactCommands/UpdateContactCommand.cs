

namespace CarBook.Application.Features.CQRS.Commands.ContactCommands
{
    public class UpdateContactCommand
    {
        public int ContactId { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
