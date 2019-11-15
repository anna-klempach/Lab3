using System;
using System.Windows.Controls;
using System.Globalization;
namespace Task_2
{
    class StringRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            if (value.ToString().Length == 0)
            {
                return new ValidationResult(false, "Значение поля не может быть пустым.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
