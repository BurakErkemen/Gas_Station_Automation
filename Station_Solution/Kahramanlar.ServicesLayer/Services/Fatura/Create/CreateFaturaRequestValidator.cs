using FluentValidation;

namespace Kahramanlar.ServicesLayer.Services.Fatura.Create
{
    public class CreateFaturaRequestValidator : AbstractValidator<CreateFaturaRequest>
    {
        public CreateFaturaRequestValidator()
        {
            RuleFor(x => x.Turu)
                .NotEmpty().WithMessage("Fatura türü boş olamaz.")
                .MaximumLength(50).WithMessage("Fatura türü 50 karakteri geçemez.");
            RuleFor(x => x.FisNo)
                .GreaterThan(0).WithMessage("Fiş numarası sıfırdan büyük olmalıdır.");
            RuleFor(x => x.Lt)
                .GreaterThan(0).WithMessage("Lt değeri sıfırdan büyük olmalıdır.");
            RuleFor(x => x.Tutar)
                .GreaterThan(0).WithMessage("Tutar sıfırdan büyük olmalıdır.");
            RuleFor(x => x.Tarih)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Tarih gelecekte olamaz.");

        }
    }
}
