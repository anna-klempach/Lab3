using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lab3_Klempach_Var9
{
    class Values : INotifyPropertyChanged
    {
        private double _XStart;
        private double _XStop;
        private double _step;
        private int _N;

        public double XStart
        {
            get
            {
                return this._XStart;
            }
            set
            {
                double convertedValue;
                bool result = double.TryParse(value.ToString(), out convertedValue);
                if (result && convertedValue < 1 && convertedValue > -1)
                {
                    this._XStart = convertedValue;
                    OnPropertyChanged("XStart");
                }
            }
        }
        public double XStop
        {
            get
            {
                return this._XStop;
            }
            set
            {
                double convertedValue;
                bool result = double.TryParse(value.ToString(), out convertedValue);
                
                if (result && convertedValue < 1 && convertedValue > -1)
                {
                    this._XStop = convertedValue;
                    OnPropertyChanged("XStop");
                }
            }
        }
        public double step
        {
            get
            {
                return this._step;
            }
            set
            {
                double convertedValue;
                bool result = double.TryParse(value.ToString(), out convertedValue);
                MessageBox.Show(value.ToString());
                if (result && convertedValue < 1)
                {
                    this._step = convertedValue;
                    OnPropertyChanged("step");
                }
            }
        }
        public double N
        {
            get
            {
                return this._N;
            }
            set
            {
                int convertedValue;
                bool result = Int32.TryParse(value.ToString(), out convertedValue);
                if (result && convertedValue > 0)
                {
                    this._N = convertedValue;
                    OnPropertyChanged("N");
                }
            }
        }
        public Values()
        {
            this._XStart = 0;
            this._XStop = 0;
            this._step = 0.1;
            this._N = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void getResults(ObservableCollection<string> results)
        {
            double xStart = this.XStart;
            double xStop = this.XStop;
            while (xStart <= xStop)
            {
                int k = 0;
                double sum = 0;
                while (k <= this.N)
                {
                    sum += Math.Pow(xStart, (4 * k + 1)) / (4 * k + 1);
                    k += 1;
                }
                string resString = $"S({xStart}) = {sum}";
                results.Add(resString);
                if (xStart == 1)
                {
                    results.Add($"Y({xStart}) = Ошибка. Деление на ноль!");
                }
                else
                {
                    double result;
                    result = 0.25 * Math.Log((1 + xStart), Math.E) - Math.Log((1 - xStart), Math.E) + 0.5 * Math.Atan(xStart); // Поскольку Math.Log отрицательного числа = NaN, х не может быть больше 0.99 и меньше -0.99
                    results.Add($"Y({xStart}) = {result}");
                }
                xStart += this.step;
            }
        }
    }
}
