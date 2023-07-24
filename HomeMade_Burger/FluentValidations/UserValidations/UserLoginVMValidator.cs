using FluentValidation;
using HomeMade_Burger.ViewModels.UserVM;

namespace HomeMade_Burger.FluentValidations.UserValidation
{
    public class UserLoginVMValidator : AbstractValidator<UserLoginVM>
    {
        public UserLoginVMValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adınızı giriniz");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrenizi giriniz");
        }
    }
}
