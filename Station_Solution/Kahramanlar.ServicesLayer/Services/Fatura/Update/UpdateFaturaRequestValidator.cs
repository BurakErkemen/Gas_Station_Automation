using FluentValidation;
using Google.Protobuf.WellKnownTypes;

namespace Kahramanlar.ServicesLayer.Services.Fatura.Update
{
    public class UpdateFaturaRequestValidator : AbstractValidator<UpdateFaturaRequest>
    {
        public UpdateFaturaRequestValidator() { 
            RuleFor(x => x.FaturaId)
                .NotEmpty().WithMessage("Fatura ID boş olamaz.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Geçersiz Fatura ID formatı.");
            RuleFor(x => x.Turu)
                .NotEmpty().WithMessage("Fatura türü boş olamaz.")
                .MaximumLength(50).WithMessage("Fatura türü 50 karakteri geçemez.");
            RuleFor(x => x.FisNo)
                .GreaterThan(0).WithMessage("Fiş numarası sıfırdan büyük olmalıdır.");
            RuleFor(x => x.Lt)
                .GreaterThan(0).WithMessage("Lt değeri sıfırdan büyük olmalıdır.");
            RuleFor(x => x.Tutar)
                .GreaterThan(0).WithMessage("Tutar sıfırdan büyük olmalıdır.");
        }
    }
}
