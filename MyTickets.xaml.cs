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
    /// Interaction logic for MyTickets.xaml
    /// </summary>
    public partial class MyTickets : Window
    {
        DataClasses1DataContext dataClasses = new DataClasses1DataContext();
        int id_pasager;
        public MyTickets(int idpasager)
        {
            id_pasager = idpasager;
            InitializeComponent();
            showTickets();
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
            this.Close();
        }

        private void showTickets()
        {
            var bilete=(from Bilete in dataClasses.Biletes
                        where Bilete.IDPasager.Equals(id_pasager)
                        select Bilete).ToList();

            ticketsgrid.ItemsSource = bilete;

        }

        private void deleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (ticketsgrid.SelectedItem != null)
            {
                Bilete data = (Bilete)ticketsgrid.SelectedItem;

                dataClasses.Biletes.DeleteOnSubmit(data);
                dataClasses.SubmitChanges();

                MessageBox.Show("Biletul a fost sters");

                showTickets();
            }
            else MessageBox.Show("Nu ati selectat un bilet");
        }
    }
}
