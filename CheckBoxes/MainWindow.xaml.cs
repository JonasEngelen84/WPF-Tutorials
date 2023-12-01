using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckBoxes
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

        private void cBAlleBelägeChecked(object sender, RoutedEventArgs e)
        {
            bool newVal = (cBAlleBeläge.IsChecked == true);
            cBSalami.IsChecked = newVal;
            cBGouda.IsChecked = newVal;
            cBChampignons.IsChecked = newVal;
        }

        private void cBEinzelbelag(object sender, RoutedEventArgs e)
        {
            cBAlleBeläge.IsChecked = null;
            if ((cBSalami.IsChecked == true) && (cBChampignons.IsChecked == true) && (cBGouda.IsChecked == true))
            {
                _ = cBAlleBeläge.IsChecked == true;
            }
            if ((cBSalami.IsChecked == false) || (cBChampignons.IsChecked == false) || (cBGouda.IsChecked == false))
            {
                _ = cBAlleBeläge.IsChecked == false;
            }
        }
    }
}