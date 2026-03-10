using FluentValidation;

namespace Kahramanlar.ServicesLayer.Services.Calisan.Create
{
    public class CreateCalisanRequestValidator : AbstractValidator<CreateCalisanRequest>
    {
        public CreateCalisanRequestValidator()
        {
            RuleFor(x => x.Adı)
                .NotEmpty().WithMessage("Ad boş olamaz.");

            RuleFor(x => x.TcNo)
                .NotEmpty().WithMessage("TC No boş olamaz.")
                .Matches(@"^\d{11}$").WithMessage("TC No 11 haneli olmalıdır.");

            RuleFor(x => x.TelNo)
                .NotEmpty().WithMessage("Telefon boş olamaz.")
                .Matches(@"^\d{10}$").WithMessage("Telefon numarası 10 haneli olmalıdır.");

            RuleFor(x => x.IseGirisTarihi)
                .NotEmpty().WithMessage("İşe giriş tarihi boş olamaz.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("İşe giriş tarihi gelecekte olamaz.");
        }
    }
}
