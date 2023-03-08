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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        DataClasses1DataContext dataClasses = new DataClasses1DataContext();
     
        public Login()
        {
            InitializeComponent();
        }

        private void loginButtonClick(object sender, RoutedEventArgs e)
        {
            string email = email_box.Text;
            string password = password_box.Password;
            int idpasager = -1;
            if (String.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("You have not entered an email!");
                return;
            }
            else
            if (String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("You have not entered a password!");
                return;
            }

            try
            {
                var person = (from p in dataClasses.Pasageris
                              where p.Email.Equals(email) && p.Parola.Equals(password)
                              select new
                              {
                                  p.Email,
                                  p.Parola,
                                  p.IDPasager
                              }).First();



                if (person.Email != null && person.Parola != null)
                {
                    idpasager = Convert.ToInt32(person.IDPasager);



                    if (idpasager == 1)
                    {
                        AdminWindow ad = new AdminWindow(idpasager);
                        ad.Show();
                        this.Close();
                    }
                    else if (email == person.Email.ToString() && password == person.Parola.ToString())
                    {
                        MainWindow mw = new MainWindow(idpasager);
                        mw.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                if (idpasager != -1)
                    MessageBox.Show("Email or password were not entered corectly");
                else
                    MessageBox.Show(ex.Message);
            }
        }
        

        private void registerButtonClick(object sender, RoutedEventArgs e)
        {
            Register rw = new Register();
            Application.Current.MainWindow = rw;
            rw.Show();
            this.Hide();
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

        private void forgotPasswordButtonClick(object sender, RoutedEventArgs e)
        {

        }
        private void emailBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (email_box.Text.Length > 0)
            {
                email_placeholder.Visibility = Visibility.Hidden;
            }
            else
            {
                email_placeholder.Visibility = Visibility.Visible;
            }
        }

        private void passwordBoxPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (password_box.Password.Length > 0)
            {
                password_placeholder.Visibility = Visibility.Hidden;
            }
            else
            {
                password_placeholder.Visibility = Visibility.Visible;
            }
        }
    }
}
