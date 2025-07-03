using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;


namespace CarBook.Application.Validators.ReviewValidators
{
	public class UpdateReviewValidator:AbstractValidator<UpdateReviewCommand>
	{
        public UpdateReviewValidator()
        {
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Müşteri Adını Boş Geçmeyiniz!");
			RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Müşteri Adı En Az 5 Karakter Olmalı!");
			RuleFor(x => x.CustomerName).MaximumLength(30).WithMessage("Müşteri Adı En Fazla 30 Karakter Olmalı!");
			RuleFor(x => x.CustomerImg).NotEmpty().WithMessage("Müşteri Resim Url'ni Boş Geçmeyiniz!");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Müşteri Yorumunu Boş Geçmeyiniz!");
			RuleFor(x => x.Comment).MinimumLength(15).WithMessage("Müşteri Yorumunu En Az 15 Karakter Olmalı!");
			RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Müşteri Yorumunu En Fazla 500 Karakter Olmalı!");
			RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Arabaya Verilecek Puanı Boş Geçmeyiniz!");
		}
    }
}
