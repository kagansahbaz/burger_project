using FluentValidation;
using HomeMade_Burger.ViewModels.UserVM;

namespace HomeMade_Burger.FluentValidations.UserValidation
{
    public class UserRegisterVMValidator : AbstractValidator<UserRegisterVM>
    {
        public UserRegisterVMValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name boş geçilemez yoksa Emre sizi cezalandırır!!!")
                                    .MinimumLength(2).WithMessage("İsminiz minimum 2 karakter içermelidir.")
                                    .MaximumLength(30).WithMessage("Çocuğuna 30 karakterden fazla isim de koymazsın ...");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password boş geçilemez")
                                    .Length(6, 20).WithMessage("Şifreniz 6-20 karakter içermelidir");

            RuleFor(x => x.Password).Must(password =>
                                    password.Any(char.IsUpper) &&
                                    password.Any(char.IsLower) &&
                                    password.Any(char.IsDigit)).WithMessage("Şifreniz en az 1 küçük harf, 1 büyük harf ve 1 rakam içermelidir. Yoksa Yıldızlar takımı sizi cezalandırır!!!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez")
                                 .EmailAddress().WithMessage("Uygun bir email adresi giriniz");
        }
    }
}
