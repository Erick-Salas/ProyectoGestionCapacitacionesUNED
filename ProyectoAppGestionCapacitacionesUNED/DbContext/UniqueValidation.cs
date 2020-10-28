using ProyectoAppGestionCapacitacionesUNED.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAppGestionCapacitacionesUNED.DbContext
{
    public class UniqueValidation : ValidationAttribute
    {
        private readonly string _errorMessage;

        public UniqueValidation(string ErrorMessage)
        {
            _errorMessage = ErrorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ApplicationDbContext db = validationContext.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            IQueryable<ICodigo> result = db.GetType().GetMethod("Set").MakeGenericMethod(validationContext.ObjectType).Invoke(db, null) as IQueryable<ICodigo>;
            var v = result.FirstOrDefault(u => u.Codigo == ((ICodigo)validationContext.ObjectInstance).Codigo);
            if (v != null)
            {
                return new ValidationResult(_errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
