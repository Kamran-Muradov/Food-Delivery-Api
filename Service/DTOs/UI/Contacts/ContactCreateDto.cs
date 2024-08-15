using FluentValidation;

namespace Service.DTOs.UI.Contacts
{
    public class ContactCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

    public class ContactCreateDtoValidator : AbstractValidator<ContactCreateDto>
    {
        public ContactCreateDtoValidator()
        {
            RuleFor(m => m.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(100);

            RuleFor(m => m.Subject)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(m => m.FullName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(m => m.Message)
                .NotEmpty();
        }
    }
}
