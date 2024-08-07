﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Marka adını boş geçmeyiniz!");
            RuleFor(b => b.Name).MinimumLength(3);
        }
    }
}
