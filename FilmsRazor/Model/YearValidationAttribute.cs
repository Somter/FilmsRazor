using System.ComponentModel.DataAnnotations;

namespace FilmsRazor.Model
{
    public class YearValidationAttribute : ValidationAttribute
    {
        private readonly int _minYear;
        private readonly int _maxYear;

        public YearValidationAttribute(int minYear = 1900, int maxYear = 2100)
        {
            _minYear = minYear;
            _maxYear = maxYear;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int year)
            {
                if (year < _minYear || year > _maxYear)
                {
                    return new ValidationResult($"Год должен быть в диапазоне от {_minYear} до {_maxYear}.");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Неверный формат года.");
        }
    }
}
