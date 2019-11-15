using System;
using System.Windows.Controls;
using System.Globalization;

namespace Lab3_Klempach_Var9
{
    class StepRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double convertedValue;

            try
            {
                convertedValue = Double.Parse((string)value, new NumberFormatInfo());
            }
            catch
            {
                return new ValidationResult(false, "Недопустимые символы.");
            }

            if (convertedValue <= 0)
            {
                return new ValidationResult(false, "Шаг не может быть меньше или равен 0.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
