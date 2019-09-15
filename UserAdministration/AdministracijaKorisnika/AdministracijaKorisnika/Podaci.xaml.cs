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
using System.Data.SqlClient;
using System.Data;

namespace AdministracijaKorisnika
{
    /// <summary>
    /// Interaction logic for Podaci.xaml
    /// </summary>
    public partial class Podaci : Window
    {
        public Podaci()
        {
            InitializeComponent();
        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text))
            {
                MessageBox.Show("Username polje mora biti popunjeno");
                UsernameBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                MessageBox.Show("Password polje mora biti popunjeno");
                PasswordBox.Focus();
                return false;
            }

            if (Combo.SelectedIndex < 0)
            {
                MessageBox.Show("Status polje mora biti izabrano");
                Combo.Focus();
                return false;
            }


            return true;
        }

        private void PrikaziOsobe()
        {
            List<Users> listaOsoba1 = Users.VratiOsobe();

            if (listaOsoba1 != null)
            {
                foreach (Users u1 in listaOsoba1)
                {
                    ListBox.Items.Add(u1);
                }
            }
        }      

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Validacija();

            if (!Validacija())
            {
                return;
            }

            Users u = new Users();
            Users selOsoba = (Users)ListBox.SelectedItem;

            u.Username = UsernameBox.Text;
            u.UserPass = PasswordBox.Text;
            u.IsAdmin = Combo.SelectedIndex;

            int id = Users.UbaciOsobu(u);

            if (id > 0)
            {
                PrikaziOsobe();
                MessageBox.Show("Podaci ubačeni.");
            }
            else
            {
                MessageBox.Show("Greška.");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Validacija();

            Users u = new Users();
            Users odaranaOsoba = (Users)ListBox.SelectedItem;

            u.Username = odaranaOsoba.Username;
            u.UserPass = odaranaOsoba.UserPass;
            u.IsAdmin = odaranaOsoba.IsAdmin;

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Combo.Items.Add("Admin");
            Combo.Items.Add("User");
            
            PrikaziOsobe();

            if (StatusBlock.Text == "User")
            {
                AddButton.IsEnabled = false;
                SaveButton.IsEnabled = false;
                UsernameBox.IsReadOnly = true;
                PasswordBox.IsReadOnly = true;
                Combo.IsReadOnly = true;

            }
        }

        private void Username_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedIndex > -1)
            {
                Users u = (Users)ListBox.SelectedItem;

                UsernameBox.Text = u.Username.ToString();
                Combo.SelectedItem = u.IsAdmin;
                PasswordBox.Text = u.UserPass;
            }
        }
    }
}
