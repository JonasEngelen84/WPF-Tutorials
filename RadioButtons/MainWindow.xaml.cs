using System.Windows;

namespace RadioButtons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void JaButtonChecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Danke, dass du mich magst.");
        }

        private void NeinButtonChecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dann verpiss dich!!!");
        }

        private void VielleichtButtonChecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dann lern mich besser kennen ;)");
        }
    }
}