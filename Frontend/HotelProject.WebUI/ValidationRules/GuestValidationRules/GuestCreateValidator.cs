using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class GuestCreateValidator: AbstractValidator<CreateGuestDto>
    {
        public GuestCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş bırakılamaz.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş bırakılamaz.");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız.");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri girişi yapınız.");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız.");

            RuleFor(x => x.Name).MaximumLength(15).WithMessage("Lütfen en fazla 15 karakter veri girişi yapınız.");
            RuleFor(x => x.Surname).MaximumLength(15).WithMessage("Lütfen en fazla 15 karakter veri girişi yapınız.");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız.");
        }
    }
}
