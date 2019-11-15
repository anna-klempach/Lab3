using System;
using System.Windows.Controls;
using System.Globalization;

namespace Lab3_Klempach_Var9
{
    class NRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int convertedValue;

            try
            {
                convertedValue = Int32.Parse((string)value);
            }
            catch
            {
                return new ValidationResult(false, "Недопустимые символы. N должно быть целым числом.");
            }

            if (convertedValue <= 0)
            {
                return new ValidationResult(false, "Количество не может быть меньше 0.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
