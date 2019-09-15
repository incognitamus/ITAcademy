using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace AdministracijaKorisnika
{
    class Users
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string UserPass { get; set; }
        public int IsAdmin { get; set; }

        public override string ToString()
        {
            return Username;
        }

        public static int UbaciOsobu(Users u)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO Users VALUES (@Username, @Userpass, @IsAdmin)");
            sb.AppendLine("SELECT CAST(SCOPE_IDENTITIY() AS int)");

            int ID = 0;
            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnAdmin1))
            {
                using (SqlCommand komanda = new SqlCommand(sb.ToString(), konekcija))
                {
                    try
                    {
                        komanda.Parameters.AddWithValue("@Username", u.Username);
                        komanda.Parameters.AddWithValue("@Userpass", u.UserPass);
                        komanda.Parameters.AddWithValue("@IsAdmin", u.IsAdmin);

                        konekcija.Open();
                        ID = (int)komanda.ExecuteScalar();
                        return ID;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
        }

        public static int PromijeniOsobu(Users u)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE Users");
            sb.AppendLine("SET Username = @Username");
            sb.AppendLine("Userpass =@Userpass");
            sb.AppendLine("IsAdmin =@IsAdmin");
            sb.AppendLine("WHERE ID = @ID");

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnAdmin1))
            {
                using (SqlCommand komanda = new SqlCommand(sb.ToString(), konekcija))
                {
                    try
                    {
                        komanda.Parameters.AddWithValue("@Username", u.Username);
                        komanda.Parameters.AddWithValue("@Userpass", u.UserPass);
                        komanda.Parameters.AddWithValue("@IsAdmin", u.IsAdmin);

                        konekcija.Open();
                        komanda.ExecuteNonQuery();
                        return 0;

                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
        }

        public static List<Users> VratiOsobe()
        {
            List<Users> listaOsoba = new List<Users>();
            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnAdmin1))
            {
                using (SqlCommand komanda = new SqlCommand("SELECT TOP 1000 Username FROM Users", konekcija))
                {
                    try
                    {
                        konekcija.Open();
                        using (SqlDataReader dr = komanda.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Users u1 = new Users
                                {
                                    Username = dr.GetString(1)
                                };
                                listaOsoba.Add(u1);
                            }
                        }
                        return listaOsoba;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }
    }
}
