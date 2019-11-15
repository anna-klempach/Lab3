using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;

namespace Task_2
{
    [Serializable]
    class Entry : INotifyPropertyChanged
    {
        private string _surname;
        private double _salary;
        private string _profession;
        private string _street;
        private string _house;
        private string _city;
        private int _index;

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public int index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value;
            }
        }
        public string surname
        {
            get
            {
                return this._surname;
            }
            set
            {
                this._surname = value;
                OnPropertyChanged("surname");
            }
        }
        public double salary
        {
            get
            {
                return this._salary;
            }
            set
            {
                double convertedValue;
                bool result = double.TryParse(value.ToString(), out convertedValue);

                if (result)
                {
                    this._salary = convertedValue;
                    OnPropertyChanged("salary");
                }
            }
        }
        public string profession
        {
            get
            {
                return this._profession;
            }
            set
            {
                this._profession = value;
                OnPropertyChanged("profession");
            }
        }
        public string street
        {
            get
            {
                return this._street;
            }
            set
            {
                this._street = value;
                OnPropertyChanged("street");
            }
        }
        public string house
        {
            get
            {
                return this._house;
            }
            set
            {
                this._house = value;
                OnPropertyChanged("house");
            }
        }
        public string city
        {
            get
            {
                return this._city;
            }
            set
            {
                 this._city = value;
                 OnPropertyChanged("city");
            }
        }
        
        public void Clear()
        {
            this.city = "";
            this.profession = "";
            this.salary = 0;
            this.surname = "";
            this.street = "";
            this.house = "";
        }

        public bool isFilled()
        {
            return !string.IsNullOrEmpty(this.surname)
                && (this.salary > 0)
                && !string.IsNullOrEmpty(this.street)
                && !string.IsNullOrEmpty(this.profession)
                && !string.IsNullOrEmpty(this.city)
                && !string.IsNullOrEmpty(this.house);
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
