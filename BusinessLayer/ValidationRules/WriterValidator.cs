using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x=>x.WriterFullName).NotEmpty().WithMessage("Adı Soyadı alanı boş geçilemez.");
            RuleFor(x=>x.WriterEmail).NotEmpty().WithMessage("Email adresi boş geçilemez.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre kısmı boş geçilemez.");
            RuleFor(x => x.WriterFullName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın.");
            RuleFor(x => x.WriterFullName).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapılabilir. ");
           
        }
    }
}
