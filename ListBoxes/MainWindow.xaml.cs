using System.Windows;

namespace ListBoxes
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Match> matches =
            [
                new() { Team1 = "Borussia Dortmund", Team2 = "Bayern München", Score1 = "4", Score2 = "0", Completion = 55 },
                new() { Team1 = "1. FC Köln", Team2 = "TSG 1899 Hoffenheim", Score1 = "3", Score2 = "2", Completion = 70 },
                new() { Team1 = "Werder Bremen", Team2 = "Union Berlin", Score1 = "1", Score2 = "3", Completion = 60 },
                new() { Team1 = "Schalke 04", Team2 = "Hertha BSC", Score1 = "0", Score2 = "3", Completion = 65 },
                new() { Team1 = "SC Freiburg", Team2 = "VFL Wolfsburg", Score1 = "1", Score2 = "1", Completion = 59 },
                new() { Team1 = "Borussia Mönchengladbach", Team2 = "RB Leipzig", Score1 = "2", Score2 = "1", Completion = 63 }
            ];

            LbMatches.ItemsSource = matches;
        }

        private void ButtonDetails(object sender, RoutedEventArgs e)
        {
            if (LbMatches.SelectedItem != null)
            {
                MessageBox.Show($"Im Spiel {(LbMatches.SelectedItem as Match).Team1}"
                + $" gegen {(LbMatches.SelectedItem as Match).Team2} steht es in der"
                + $" {(LbMatches.SelectedItem as Match).Completion}. Min"
                + $" {(LbMatches.SelectedItem as Match).Score1} :"
                + $" {(LbMatches.SelectedItem as Match).Score2}");
            }
        }
    }
}