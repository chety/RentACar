using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,IEntity entity)
        {
            var context = new ValidationContext<IEntity>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}
