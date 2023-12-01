using System.Windows;

namespace INotifyPropertyChanged_OneWay
{
    public partial class MainWindow : Window
    {
        public Person Person { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Person = new Person();
            this.DataContext = Person;
        }
    }
}