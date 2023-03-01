using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator() 
        { 
            RuleFor(x=>x.BlogTitle).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Görsel alanı boş bırakılamaz.");
            RuleFor(x => x.BlogContent).MaximumLength(150).WithMessage("150 karakterden fazla giriş yapılamaz.");
            RuleFor(x => x.BlogContent).MinimumLength(20).WithMessage("20 karakterden az giriş yapılamaz.");

        }
    }
}
