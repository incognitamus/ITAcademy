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
using System.Data;
using System.Data.SqlClient;

namespace AdministracijaKorisnika
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(TextBoxUsernameLogin.Text))
            {
                TextBoxUsernameLogin.Text = "Unesite username";
                TextBoxUsernameLogin.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(PwBoxLogin.Password))
            {
                MessageBox.Show("Unesite password.");
                PwBoxLogin.Focus();
                return false;
            }

            return true;
        }
    

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            if (Validacija() == true)
            {
                SqlConnection konekcija = new SqlConnection(Konekcija.cnnAdmin1);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT (*) FROM Users WHERE Username='" + TextBoxUsernameLogin.Text + "'AND Userpass='" + PwBoxLogin.Password + "'", konekcija);
                DataTable dt1 = new DataTable();
                sda.Fill(dt1);
                if (dt1.Rows[0][0].ToString() == "1")
                {
                    Podaci p1 = new Podaci();
                    SqlDataAdapter sda1 = new SqlDataAdapter("SELECT IsAdmin FROM Users WHERE Username='" + TextBoxUsernameLogin.Text + "'", konekcija);
                    DataTable dt2 = new DataTable();
                    sda1.Fill(dt2);
                    if (dt2.Rows[0]["IsAdmin"].ToString() == "1")
                    {
                        p1.StatusBlock.Text = "Admin";
                    }
                    else
                    {
                        p1.StatusBlock.Text = "User";
                    }
                    p1.Show();
                    p1.BlockName.Text = TextBoxUsernameLogin.Text;
                    Hide();
                }
                else
                {
                    MessageBox.Show("Login failed.Please try again.");
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
