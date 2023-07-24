using FluentValidation;
using HomeMade_Burger.Areas.Admin.Models;

namespace HomeMade_Burger.FluentValidations.ProductValidations
{
    public class UpdateProductVMValidator : AbstractValidator<UpdateProductVM>
    {
        public UpdateProductVMValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün Fiyatı Boş Geçilemez");

            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Ürün Kategorisi Boş Geçilemez");

            RuleFor(x => x.ProductID).NotEmpty().WithMessage("ÜrünID Boş Geçilemez");

        }
    }
}
