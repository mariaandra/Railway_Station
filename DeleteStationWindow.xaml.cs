using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Railway_System
{
    /// <summary>
    /// Interaction logic for DeleteStationWindow.xaml
    /// </summary>
    public partial class DeleteStationWindow : Window
    {
        Database data;
        List<string> stations;
        public DeleteStationWindow()
        {
            InitializeComponent();
            data = new Database();
            stations = new List<string>();
            initStationsArray();
        }

        private void initStationsArray()
        {
            if (data.conn.State == System.Data.ConnectionState.Closed)
                data.Connect();

            var cmd = data.conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT Nume_statie from Statii";

            using (var rezultat = cmd.ExecuteReader())
            {
                while (rezultat.Read())
                {
                    stations.Add(rezultat[0].ToString());
                }
            }
            data.Disconnect();
        }

        private void DeleteStationBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteStationCombobox_LostFocus(object sender, RoutedEventArgs e)
        {
            DeleteStationCombobox.IsDropDownOpen = false;
        }

        private void DeleteStationBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string user_input = DeleteStationBox.Text;
            int counter = 0;
            DeleteStationCombobox.Items.Clear();

            if (DeleteStationBox.Text.Length >= 3)
            {
                foreach (string station in stations)
                {
                    if (station.ToLower().StartsWith(user_input.ToLower()))
                    {
                        DeleteStationCombobox.Items.Add(station);
                        counter++;
                    }
                    if (counter > 7)
                    {
                        break;
                    }
                }
            }

            if (DeleteStationCombobox.Items.Count != 0)
            {
                DeleteStationCombobox.IsDropDownOpen = true;
            }
            else
            {
                DeleteStationCombobox.IsDropDownOpen = false;
            }
        }

        private void DeleteStationCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteStationBox.Text = DeleteStationCombobox.Text;
            Keyboard.ClearFocus();
        }
    }
}
