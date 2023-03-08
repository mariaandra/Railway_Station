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
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data.Linq;

namespace Railway_System
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        DataClasses1DataContext dataClasses = new DataClasses1DataContext();

        public Register()
        {
            InitializeComponent();
        }

        private void registerButtonClick(object sender, RoutedEventArgs e)
        {
            string firstname = firstname_box.Text;
            string lastname = lastname_box.Text;
            string email = email_box.Text;
            string password = password_box.Password;
            string confirm_password = confirm_password_box.Password;

            if (String.IsNullOrWhiteSpace(firstname))
            {
                MessageBox.Show("You have not entered a firstname!");
                return;
            }
            else if(String.IsNullOrWhiteSpace(lastname))
            {
                MessageBox.Show("You have not entered a lastname!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("You have not entered an email!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("You have not entered a password!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(confirm_password))
            {
                MessageBox.Show("You have not entered a password confirmation!");
                return;
            }
            else if(password != confirm_password)
            {
                MessageBox.Show("Passwords don't match!");
                return;
            }
            else if (!Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("You entered an invalid email address!");
                return;
            }

            try
            {
                var psg = dataClasses.Pasageris.FirstOrDefault(p => p.Email == email);

                if (psg == null)
                { 
                    Pasageri pasager = new Pasageri
                    {
                        Nume = lastname,
                        Prenume = firstname,
                        Email = email,
                        Parola = password
                    };

                    dataClasses.Pasageris.InsertOnSubmit(pasager);
                    dataClasses.SubmitChanges();

                    MessageBox.Show("Ati fost inregistrat cu succes!");

                    Login login_window = new Login();
                    login_window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Inregistrarea nu s-a realizat cu succes!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backToLoginButtonClick(object sender, RoutedEventArgs e)
        {
            Login lw = new Login();
            Application.Current.MainWindow = lw;
            lw.Show();
            this.Close();
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

        private void firstnameBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (firstname_box.Text.Length > 0)
            {
                firstname_placeholder.Visibility = Visibility.Hidden;
            }
            else
            {
                firstname_placeholder.Visibility = Visibility.Visible;
            }
        }

        private void lastnameBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (lastname_box.Text.Length > 0)
            {
                lastname_placeholder.Visibility = Visibility.Hidden;
            }
            else
            {
                lastname_placeholder.Visibility = Visibility.Visible;
            }
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

        private void confirmPasswordBoxTextChanged(object sender, TextChangedEventArgs e)
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

        private void confirmPasswordBoxPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (confirm_password_box.Password.Length > 0)
            {
                confirm_password_placeholder.Visibility = Visibility.Hidden;
            }
            else
            {
                confirm_password_placeholder.Visibility = Visibility.Visible;
            }
        }
    }
}
