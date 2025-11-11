using System.ComponentModel.DataAnnotations;

namespace MVCDemoLab.CustomValidation
{
    public class PriceAttribute : ValidationAttribute
    {
        public static string MyErrorMessage { get; set; }
        public static ValidationResult ValidateValue(decimal valueAmount, ValidationContext context)
        {
            if (valueAmount < 500)
                return new ValidationResult(MyErrorMessage);
            return ValidationResult.Success;
        }
    }
}
