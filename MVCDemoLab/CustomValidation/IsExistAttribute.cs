using System.ComponentModel.DataAnnotations;

namespace MVCDemoLab.CustomValidation
{
    public class IsExistAttribute : ValidationAttribute
    {
        public string MyErrorMessage { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //Check value
            if (value == null) return null;
            //GetData
            string data = value.ToString();

            //Create Instance from DbContext
            MVCDbContext db = (MVCDbContext)validationContext.GetService(typeof(MVCDbContext)); //new MVCDbContext();
            //Check Is Exist 
            Product productName = db.Products.FirstOrDefault(p => p.Name == data);
            if (productName != null)
            {
                return new ValidationResult(MyErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
