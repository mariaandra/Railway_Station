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

namespace Railway_System
{
    /// <summary>
    /// Interaction logic for MyAccount.xaml
    /// </summary>
    public partial class MyAccount : Window
    {
        DataClasses1DataContext dataClasses = new DataClasses1DataContext();
        int id_pasager;
        string firstname;
        string lastname;
        string email;
        public MyAccount(int idpasager)
        {
            id_pasager = idpasager;
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            try
            {
                var pasager = (from p in dataClasses.Pasageris
                               where p.IDPasager == id_pasager
                               select new
                               {
                                   p.Nume,
                                   p.Prenume,
                                   p.Email
                               }).First();



                if (pasager != null)
                {
                    firstname = pasager.Prenume.ToString();
                    lastname = pasager.Nume.ToString();
                    email = pasager.Email.ToString();
                    firstname_placeholder.Text = firstname;
                    lastname_placeholder.Text = lastname;
                    email_placeholder.Text = email;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void modifyButtonClick(object sender, RoutedEventArgs e)
        {
            bool ok = false;
            Pasageri person = dataClasses.Pasageris.SingleOrDefault(p => p.IDPasager == id_pasager);
            if (firstname_box.Text != firstname && firstname_box.Text.Length > 0)
            {
                person.Nume = lastname_box.Text;
                dataClasses.SubmitChanges();
                ok = true;
            }



            if (lastname_box.Text != lastname && lastname_box.Text.Length > 0)
            {
                person.Prenume = firstname_box.Text;
                dataClasses.SubmitChanges();
                ok = true;
            }



            if (email_box.Text != email && email_box.Text.Length > 0)
            {



                person.Email = email_box.Text;
                dataClasses.SubmitChanges();
                ok = true;
            }



            if (password_box.Password == confirm_password_box.Password)
            {
                person.Parola = password_box.Password;
                dataClasses.SubmitChanges();
                ok = true;
            }
            if (ok == true)
                MessageBox.Show("Modificare cu succes!");
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
