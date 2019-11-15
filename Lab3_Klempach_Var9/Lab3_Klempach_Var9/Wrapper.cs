using System;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;

namespace Lab3_Klempach_Var9
{
    public class Wrapper : DependencyObject
    {
        public static readonly DependencyProperty StartProperty =
             DependencyProperty.Register("start", typeof(double),
             typeof(Wrapper), new FrameworkPropertyMetadata(null));

        public double start
        {
            get { return (double)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }
    }

    class XStopRule : ValidationRule
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
                return new ValidationResult(false, "Недопустимые символы!!!");
            }

            if (convertedValue < this.Wrapper.start)
            {
                
                return new ValidationResult(false, "Конечное значение не может быть меньше начального значения аргумента.");
            }

            if (convertedValue >= 1 && convertedValue <= -1)
            {

                return new ValidationResult(false, "Конечное значение не может быть больше или равно 1 или меньше или равно -1.");
            }

            return ValidationResult.ValidResult;
        }
        public Wrapper Wrapper { get; set; }
    }
}
