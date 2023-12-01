using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotifyPropertyChanged_OneWay
{
    // INotifyPropertyChanged ist ein Interface welches über die Veränderung
    // einer Property informiert, und gegebenenfalls Code Ausführt.
    public class Person : INotifyPropertyChanged
    {
        private string? vorname;
        private string? nachname;

        public string Vorname
        {
            get => vorname;
            set
            {
                vorname = value;
                OnPropertyChanged("Vorname");
                OnPropertyChanged("Name");
            }
        }

        public string Nachname
        {
            get => nachname;
            set
            {
                nachname = value;
                OnPropertyChanged("Nachname");
                OnPropertyChanged("Name");
            }
        }

        public string Name
        {
            get { return vorname + " " + nachname; }
            set
            {
                string[] name = value.Split(' ');
                value = name[0];
                vorname = value;
                OnPropertyChanged("Vorname");
                value = name[1];
                nachname = value;
                OnPropertyChanged("Nachname");
            }
        }


        // Dieses Event wird bei Veränderung einer Property
        // über OnPropertyChanged() aufgerufen.
        // PropertyChangedEventHandler ist ein Delegat.
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            // Wenn PropertyChanged != null => Aufruf von PropertyChanged
            // Dieses muss den Sender und PropertyChangedEventArgs() aufrufen,
            // welche den Namen der Property (welche angepasst werden soll) übergeben bekommt.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            // äquivalent zu:
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
