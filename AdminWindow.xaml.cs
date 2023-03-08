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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        DataClasses1DataContext dataClasses1 = new DataClasses1DataContext();
        int id_pasager;
        public AdminWindow(int id)
        {
            InitializeComponent();
            id_pasager = id;

            var trenuri = (from StatiiPlecare in dataClasses1.StatiiPlecares
                          join StatiiSosire in dataClasses1.StatiiSosires
                          on StatiiPlecare.IDTren equals StatiiSosire.IDTren
                          select new
                          {
                              StatiiPlecare.IDTren,
                              StatiiPlecare.Tip_Tren,
                              Statie_PLecare = StatiiPlecare.Nume_statie,
                              Statie_sosire = StatiiSosire.Nume_statie
                          }).ToList();

            trains.ItemsSource = trenuri;

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
            Application.Current.Shutdown();
        }

        private void disconnectButtonClick(object sender, RoutedEventArgs e)
        {
            Login lw = new Login();
            lw.Show();
            this.Close();
        }

        private void myAccountButtonClick(object sender, RoutedEventArgs e)
        {
            MyAccount ma = new MyAccount(id_pasager);
            this.Hide();
            ma.ShowDialog();
            this.ShowDialog();
        }

        private void modifyRoutesButtonClick(object sender, RoutedEventArgs e)
        {
            ModifyRouteDialog mrd = new ModifyRouteDialog();
            mrd.ShowDialog();
        }
    }
}
