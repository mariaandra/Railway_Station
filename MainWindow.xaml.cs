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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Railway_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClasses1DataContext dataClasses = new DataClasses1DataContext();
        List<string> stations;
        int id_pasager;
        public MainWindow(int id)
        {
            InitializeComponent();
            date_picker.SelectedDate = DateTime.Now;
            stations = new List<string>();
            id_pasager = id;
            initStationsArray();
        }

        private void initStationsArray()
        {
            var statii = (from Statii in dataClasses.Statiis
                          select Statii.Nume_statie).ToList();

            stations.AddRange(statii);
        }
        private void topBarMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void minimizeButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
            arrival_combobox.IsDropDownOpen = false;
            departure_combobox.IsDropDownOpen = false;
        }

        private void maximizeButtonClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Normal)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void exitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void departureTextChanged(object sender, TextChangedEventArgs e)
        {
            string user_input = departure_box.Text;
            int counter = 0;
            departure_combobox.Items.Clear();

            if (departure_box.Text.Length >= 3)
            {
                foreach (string station in stations)
                {
                    if (station.ToLower().StartsWith(user_input.ToLower()))
                    {
                        departure_combobox.Items.Add(station);
                        counter++;
                    }
                    if (counter > 7)
                    {
                        break;
                    }
                }
            }

            if (departure_combobox.Items.Count != 0)
            {
                departure_combobox.IsDropDownOpen = true;
            }
            else
            {
                departure_combobox.IsDropDownOpen = false;
            }
        }


        private void arrivalTextChanged(object sender, TextChangedEventArgs e)
        {
            string user_input = arrival_box.Text;
            int counter = 0;
            arrival_combobox.Items.Clear();

            if (arrival_box.Text.Length >= 3)
            {
                foreach (string station in stations)
                {
                    if (station.ToLower().StartsWith(user_input.ToLower()))
                    {
                        arrival_combobox.Items.Add(station);
                        counter++;
                    }
                    if (counter > 7)
                    {
                        break;
                    }
                }
            }

            if (arrival_combobox.Items.Count != 0)
            {
                arrival_combobox.IsDropDownOpen = true;
            }
            else
            {
                arrival_combobox.IsDropDownOpen = false;
            }
        }

        private void departureComboboxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            departure_box.Text = departure_combobox.Text;
            Keyboard.ClearFocus();
        }

        private void arrivalComboboxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            arrival_box.Text = arrival_combobox.Text;
            Keyboard.ClearFocus();
        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {
            date_picker.IsDropDownOpen = true;
        }


        private void dateBoxPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
            date_picker.IsDropDownOpen = true;
        }

        private void searchButtonClick(object sender, RoutedEventArgs e)
        {
            gridDate.Visibility = Visibility.Visible;
            if (departure_box.Text != "" || arrival_box.Text != "")
            {


                string date = Convert.ToDateTime(date_box.Text).ToString("yyyy-MM-dd");

                var trenuri_plecare = (from StatiiPlecare in dataClasses.StatiiPlecares
                                       where StatiiPlecare.Nume_statie.Equals(departure_box.Text)
                                       && StatiiPlecare.Ziua.Equals(date)
                                       select new
                                       {
                                           StatiiPlecare.IDTren,
                                           StatiiPlecare.Tip_Tren,
                                           StatiiPlecare.Ora_sosire,
                                           StatiiPlecare.Ora_plecare,
                                           StatiiPlecare.Nume_statie,
                                           StatiiPlecare.Ziua
                                       }).ToList();
                var trenuri_sosire=(from StatiiSosire in dataClasses.StatiiSosires
                                    where StatiiSosire.Nume_statie.Equals(arrival_box.Text)
                                    && StatiiSosire.Ziua.Equals(date)
                                    select new
                                    {
                                        StatiiSosire.IDTren,
                                        StatiiSosire.Tip_Tren,
                                        StatiiSosire.Ora_sosire,
                                        StatiiSosire.Ora_plecare,
                                        StatiiSosire.Nume_statie,
                                        StatiiSosire.Ziua
                                    }).ToList();
                var trenuri=(from StatiiPlecare in trenuri_plecare
                             join StatiiSosire in trenuri_sosire
                             on StatiiPlecare.IDTren equals StatiiSosire.IDTren
                             select new
                             {
                                 StatiiPlecare.IDTren,
                                 StatiiPlecare.Tip_Tren,
                                 StatiiPlecare.Ora_plecare,
                                 StatiiSosire.Ora_sosire,
                                 StatiiSosire.Ziua
                             }).ToList();

                gridDate.ItemsSource = trenuri;
            }
            else MessageBox.Show("Nu ati introdus o statie valida!");
        }

        private void ticketsHistoryButtonClick(object sender, RoutedEventArgs e)
        {
            MyTickets acc = new MyTickets(id_pasager);
            this.Hide();
            acc.ShowDialog();
            this.ShowDialog();
        }

        private void disconnectButtonClick(object sender, RoutedEventArgs e)
        {
            Login lw = new Login();
            lw.Show();
            this.Close();
        }

        private void myAccountButtonClick(object sender, RoutedEventArgs e)
        {
            MyAccount ma=new MyAccount(id_pasager);
            this.Hide();
            ma.ShowDialog();
            this.ShowDialog();
        }

        private void buyButtonClick(object sender, RoutedEventArgs e)
        {
            if (gridDate.SelectedItem != null)
            {

                var data=gridDate.SelectedItem.ToString();
                Random rnd = new Random();

                int price = rnd.Next(10,100);
                int place = rnd.Next(1, 100);
                int vagon = rnd.Next(1, 5);
                string idTren = "";
                int id_tren;

                foreach(var aux in data)
                {
                    if (Char.IsDigit(aux))
                        idTren += aux;

                    if (aux == ',')
                        break;
                }

                id_tren=Convert.ToInt32(idTren);

                Bilete bilete = new Bilete
                {
                    IDPasager = id_pasager,
                    IDTren = id_tren,
                    Pret = price,
                    Statie_plecare = departure_box.Text,
                    Statie_destinatie = arrival_box.Text,
                    Loc_pasager = place,
                    Vagon = vagon
                };

                dataClasses.Biletes.InsertOnSubmit(bilete);
                dataClasses.SubmitChanges();

                MessageBox.Show("Ati cumparat un bilet");
            }
            else MessageBox.Show("Nu ati selectat un tren inca");
        }

        private void departureBoxLostFocus(object sender, RoutedEventArgs e)
        {
            departure_combobox.IsDropDownOpen = false;
        }

        private void arrivalBoxLostFocus(object sender, RoutedEventArgs e)
        {
            arrival_combobox.IsDropDownOpen = false;
        }
    }
}
