using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfService001.ServiceReference1;

namespace WcfService001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Employee p = new Employee();

                p.EmployeeID = Convert.ToInt32(txtID.Text);
                p.Firstname = txtIme.Text;
                p.LastName = txtIme.Text;
                p.Title = txtTitle.Text;
                p.TitleofCourtesy = txtToC.Text;
                p.BirthDate = txtBirthDate.Text;
                p.HireDate = txtHireDate.Text;
                p.Address = txtAddress.Text;
                p.City = txtCity.Text;
                p.Region = txtRegion.Text;
                p.PostalCode = Convert.ToInt32(txtPostalCode.Text);
                p.Country = txtCountry.Text;
                p.HomePhone = Convert.ToInt32(txtHomePhone.Text);
                p.Extension = Convert.ToInt32(txtExtension.Text);
                p.Notes = txtNotes.Text;
                p.ReportsTo = Convert.ToInt32(txtReports.Text);
                p.PhotoPath = txtPhotoPath.Text;

            Service1Client service = new Service1Client();

            if(service.InsertEmployee(p) == 1)
            {
                MessageBox.Show("Osoba uspješno ubačena u bazu podataka.");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Employee p = new Employee()
            {
                EmployeeID = Convert.ToInt32(txtID.Text),
                Firstname = txtIme.Text,
                LastName = txtIme.Text,
                Title = txtTitle.Text,
                TitleofCourtesy = txtToC.Text,
                BirthDate = txtBirthDate.Text,
                HireDate = txtHireDate.Text,
                Address = txtAddress.Text,
                City = txtCity.Text,
                Region = txtRegion.Text,
                PostalCode = Convert.ToInt32(txtPostalCode.Text),
                Country = txtCountry.Text,
                HomePhone = Convert.ToInt32(txtHomePhone.Text),
                Extension = Convert.ToInt32(txtExtension.Text),
                Notes = txtNotes.Text,
                ReportsTo = Convert.ToInt32(txtReports.Text),
                PhotoPath = txtPhotoPath.Text

            };

            Service1Client service = new Service1Client();

            if (service.UpdateEmployee(p) == 1)
            {
                MessageBox.Show("Osoba uspješno ažurirana.");
            }

            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Employee p = new Employee()
            {
                EmployeeID = Convert.ToInt32(txtID.Text)
            };

            Service1Client service = new Service1Client();
            if (service.DeleteEmployee(p) == 1)
            {
                MessageBox.Show("Osoba uspješno izbrisana.");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            List<Employee> employeeList = new List<Employee>();
            Employee p = new Employee()
            {
                EmployeeID = Convert.ToInt32(txtID.Text)
            };
            Service1Client service = new Service1Client();
            employeeList.Add(service.GetEmployee(p));
            dgvEmployee.DataSource = employeeList;
        }

        private void buttonGetAll_Click(object sender, EventArgs e)
        {
            List<Employee> employeeList = new List<Employee>();
            Service1Client service = new Service1Client();

            dgvEmployee.DataSource = service.GetAll();
        }
    }
}
