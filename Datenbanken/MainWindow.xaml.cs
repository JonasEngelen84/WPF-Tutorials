using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Datenbanken
{
    public partial class MainWindow : Window
    {
        // Bekommt bei implementierung den connectionString übergeben zum Verbindungsaufbau zur Datenbank
        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();

            // Beinhaltet den bei der Erstellug der Datenbank erstellten connectionString als Wert
            string connectionString = ConfigurationManager.ConnectionStrings["Datenbanken.Properties.Settings.ZooDatabaseConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            ShowZoos();
        }

        public void ShowZoos()
        {
            try
            {
                string query = "SELECT* FROM Zoo";
                // Ermöglicht es die Werte der Datenbank wie Objekte zu nutzen
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);

                using (adapter)
                {
                    //Zum speichern der auszugebenden Tabellenwerte
                    DataTable zooTable = new DataTable();
                    // Dem SqlDataAdapter-Objekt wird das DataTable-Objekt übergeben
                    adapter.Fill(zooTable);
                    // Gibt an, welcher Wert in der Zooliste ausgegeben werden sollen
                    ZooList.DisplayMemberPath = "Location";
                    // Gibt an, welcher Wert zurückgegeben werden soll wenn ein Zoo aus der Zooliste ausgewählt wird
                    ZooList.SelectedValuePath = "Id";
                    // Gibt alle Daten die sich in der Tabelle befinden zurück, anhand des Aufrufs von DefaultView
                    ZooList.ItemsSource = zooTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public void ShowAnimalsOfZoo()
        {
            try
            {
                // Durch @ ist die eingegebene ZooId variabel (abhängig von dem ausgewählten Zoo aus der Zooliste)
                string query = "SELECT * FROM Animal a INNER JOIN ZooAnimal za ON a.Id = za.AnimalId WHERE za.ZooId = @ZooId";

                // Um die variable ZooId als Parameter nutzen zu können muss ein SqlCommand implementiert werden, welches dem Adapter übergeben wird
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                using (adapter)
                {
                    // Bestimmung des Wertes vom Parameter @ZooId
                    command.Parameters.AddWithValue("@ZooId", ZooList.SelectedValue);

                    DataTable animalTable = new DataTable();
                    adapter.Fill(animalTable);
                    AnimalList.DisplayMemberPath = "Name";
                    AnimalList.SelectedValuePath = "Id";
                    AnimalList.ItemsSource = animalTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        // Eventhandler für die einzelnen Zoos aus der Zooliste
        private void ZooList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ShowAnimalsOfZoo();
        }
    }
}