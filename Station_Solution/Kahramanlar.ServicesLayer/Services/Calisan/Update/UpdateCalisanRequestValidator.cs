using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kahramanlar.ServicesLayer.Services.Calisan.Update
{
    public class UpdateCalisanRequestValidator : AbstractValidator<UpdateCalisanRequest>
    {
        public UpdateCalisanRequestValidator()
        {
            RuleFor(x => x.CalisanId).NotEmpty().WithMessage("Çalışan ID boş olamaz.");

            RuleFor(x => x.Ad).NotEmpty().WithMessage("Ad boş olamaz.")
                .Matches(@"^\d{11}$").WithMessage("TC No 11 haneli olmalıdır.");

            RuleFor(x => x.TcNo).NotEmpty().WithMessage("TC No boş olamaz.");
            
            RuleFor(x => x.TelNo).NotEmpty().WithMessage("Telefon No boş olamaz.")
                .Matches(@"^\d{11}").WithMessage("Telefon Numarası 11 haneli olmalıdır.");
            
            RuleFor(x => x.IseGirisTarihi)
                .NotEmpty().WithMessage("İşe giriş tarihi boş olamaz.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("İşe giriş tarihi gelecekte olamaz.");

        }
    }
}
