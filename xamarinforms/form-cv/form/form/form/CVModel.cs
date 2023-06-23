using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace form_cv
{
    public class CVModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        private int edad;
        public int Edad
        {
            get { return edad; }
            set
            {
                if (edad != value)
                {
                    edad = value;
                    OnPropertyChanged(nameof(Edad));
                }
            }
        }

        private string ocupacion;
        public string Ocupacion
        {
            get { return ocupacion; }
            set
            {
                if (ocupacion != value)
                {
                    ocupacion = value;
                    OnPropertyChanged(nameof(Ocupacion));
                }
            }
        }

        private string pais;
        public string Pais
        {
            get { return pais; }
            set
            {
                if (pais != value)
                {
                    pais = value;
                    OnPropertyChanged(nameof(Pais));
                }
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}