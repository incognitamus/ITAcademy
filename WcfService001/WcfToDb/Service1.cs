using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService001;

namespace WcfToDb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        public Service1()
        {
            ConnecttoDb();
        }

        SqlConnection conn;
        SqlCommand comm;
        SqlConnectionStringBuilder connStringBuilder;

        void ConnecttoDb()
        {
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "INCOGNITAMUS";
            connStringBuilder.InitialCatalog = "NORTHWND";
            connStringBuilder.Encrypt = true;
            connStringBuilder.TrustServerCertificate = true;
            connStringBuilder.ConnectTimeout = 30;
            connStringBuilder.AsynchronousProcessing = true;
            connStringBuilder.MultipleActiveResultSets = true;
            connStringBuilder.IntegratedSecurity = true;

            conn = new SqlConnection(connStringBuilder.ToString());
            comm = conn.CreateCommand();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int InsertEmployee(Employee p)
        {
            try
            {
                comm.CommandText = "INSERT INTO Employee VALUES(@EmployeeID, @LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address, @City, @Region, @PostalCode, @Country, @HomePhone, @Extension, @Photo, @Notes, @ReportsTo, @PhotoPath)";
                comm.Parameters.AddWithValue("EmployeeID", p.EmployeeID);
                comm.Parameters.AddWithValue("FirstName", p.Firstname);
                comm.Parameters.AddWithValue("LastName", p.LastName);
                comm.Parameters.AddWithValue("Title", p.Title);
                comm.Parameters.AddWithValue("TitleofCourtesy", p.TitleofCourtesy);
                comm.Parameters.AddWithValue("BirthDate", p.BirthDate);
                comm.Parameters.AddWithValue("HireDate", p.HireDate);
                comm.Parameters.AddWithValue("Address", p.Address);
                comm.Parameters.AddWithValue("City", p.City);
                comm.Parameters.AddWithValue("Region", p.Region);
                comm.Parameters.AddWithValue("Country", p.Country);
                comm.Parameters.AddWithValue("PostalCode", p.PostalCode);
                comm.Parameters.AddWithValue("HomePhone", p.HomePhone);
                comm.Parameters.AddWithValue("Extension", p.Extension);
                comm.Parameters.AddWithValue("ReportsTo", p.ReportsTo);
                comm.Parameters.AddWithValue("PhotoPath", p.PhotoPath);
                comm.Parameters.AddWithValue("Photo", p.Photo);
                comm.Parameters.AddWithValue("Notes", p.Notes);


                comm.CommandType = CommandType.Text;
                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int UpdateEmployee(Employee p)
        {
            try
            {
                comm.CommandText = "UPDATE Employees SET  LastName=@LastName, FirstName=@FirstName, Title=@Title, TitleOfCourtesy=@TitleOfCourtesy, BirthDate=@BirthDate, HireDate=@HireDate, Address=@Address, City=@City, Region=@Region, PostalCode=@PostalCode, Country=@Country, HomePhone=@HomePhone, Extension=@Extension, Photo=@Photo, Notes=@Notes, ReportsTo=@ReportsTo, PhotoPath=@PhotoPath WHERE EmployeeID=@EmployeeID";
                comm.Parameters.AddWithValue("EmployeeID", p.EmployeeID);
                comm.Parameters.AddWithValue("FirstName", p.Firstname);
                comm.Parameters.AddWithValue("LastName", p.LastName);
                comm.Parameters.AddWithValue("Title", p.Title);
                comm.Parameters.AddWithValue("TitleofCourtesy", p.TitleofCourtesy);
                comm.Parameters.AddWithValue("BirthDate", p.BirthDate);
                comm.Parameters.AddWithValue("HireDate", p.HireDate);
                comm.Parameters.AddWithValue("Address", p.Address);
                comm.Parameters.AddWithValue("City", p.City);
                comm.Parameters.AddWithValue("Region", p.Region);
                comm.Parameters.AddWithValue("Country", p.Country);
                comm.Parameters.AddWithValue("PostalCode", p.PostalCode);
                comm.Parameters.AddWithValue("HomePhone", p.HomePhone);
                comm.Parameters.AddWithValue("Extension", p.Extension);
                comm.Parameters.AddWithValue("ReportsTo", p.ReportsTo);
                comm.Parameters.AddWithValue("PhotoPath", p.PhotoPath);
                comm.Parameters.AddWithValue("Photo", p.Photo);
                comm.Parameters.AddWithValue("Notes", p.Notes);
                comm.CommandType = CommandType.Text;

                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int DeleteEmployee(Employee p)
        {
            try
            {
                comm.CommandText = "DELETE Employees WHERE EmployeeID=@EmployeeID";
                comm.Parameters.AddWithValue("EmployeeID", p.EmployeeID);
                comm.CommandType = CommandType.Text;
                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public Employee GetEmployee(Employee p)
        {
            Employee employee = new Employee();
            try
            {
                comm.CommandText = "SELECT * FROM Employees WHERE EmployeeID=@EmployeeID";
                comm.Parameters.AddWithValue("EmployeeID", p.EmployeeID);
                comm.CommandType = CommandType.Text;

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    employee.EmployeeID = Convert.ToInt32(reader[0]);
                    employee.Firstname = reader[1].ToString();
                    employee.LastName = reader[2].ToString();
                    employee.Title = reader[3].ToString();
                    employee.TitleofCourtesy = reader[4].ToString();
                    employee.BirthDate = reader[5].ToString();
                    employee.HireDate = reader[6].ToString();
                    employee.Address = reader[7].ToString();
                    employee.City = reader[8].ToString();
                    employee.Region = reader[9].ToString();
                    employee.PostalCode = Convert.ToInt32(reader[10]);
                    employee.Country = reader[11].ToString();
                    employee.HomePhone = Convert.ToInt32(reader[12]);
                    employee.Extension = Convert.ToInt32(reader[13]);
                    employee.Photo = reader[14].ToString();
                    employee.Notes = reader[15].ToString();
                    employee.ReportsTo = Convert.ToInt32(reader[16]);
                    employee.PhotoPath = reader[17].ToString();
                }
                return employee;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public List<Employee> GetAll()
        {
            List<Employee> employeeList = new List<Employee>();
            try
            {
                comm.CommandText = "SELECT * FROM Employees";
                comm.CommandType = CommandType.Text;
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee()
                    {
                        EmployeeID = Convert.ToInt32(reader[0]),
                        Firstname = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        Title = reader[3].ToString(),
                        TitleofCourtesy = reader[4].ToString(),
                        BirthDate = reader[5].ToString(),
                        HireDate = reader[6].ToString(),
                        Address = reader[7].ToString(),
                        City = reader[8].ToString(),
                        Region = reader[9].ToString(),
                        PostalCode = Convert.ToInt32(reader[10]),
                        Country = reader[11].ToString(),
                        HomePhone = Convert.ToInt32(reader[12]),
                        Extension = Convert.ToInt32(reader[13]),
                        Photo = reader[14].ToString(),
                        Notes = reader[15].ToString(),
                        ReportsTo = Convert.ToInt32(reader[16]),
                        PhotoPath = reader[17].ToString()
                    };
                    employeeList.Add(employee);
                }
                return employeeList;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
