using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace DeAnGK_Lttt
{
    /// <summary>
    /// Interaction logic for FormDK.xaml
    /// </summary>
    public partial class FormDK : Window
    {
        private String ConnectionString;
        private SqlConnection connection;
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader reader;
        public FormDK()
        {
            InitializeComponent();
            ConnectionString = @"Data Source=LAPTOP-LTSR3KDB;Initial Catalog=QLNguoiDung;Integrated Security=True";
            connection = new SqlConnection(ConnectionString);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tenND = nametxt.Text;
            string key = keytxt.Text;
            string mk = mktxt.Text;
            string email = emailtxt.Text;
            int age = Convert.ToInt16(agetxt.Text);
            try
            {
                Console.WriteLine(nametxt.Text + " and " + mktxt.Text + " and " + keytxt.Text);

                cmd.CommandText = "INSERT INTO NGUOIDUNG(TenNguoiDung, KeyDN, MatKhau, Email, Age) VALUES (@param1,@param2,@param3,@param4,@param5)";

                cmd.Parameters.AddWithValue("@param1", tenND);
                cmd.Parameters.AddWithValue("@param2", key);
                cmd.Parameters.AddWithValue("@param3", mk);
                cmd.Parameters.AddWithValue("@param4", email);
                cmd.Parameters.AddWithValue("@param5", age);
                Console.WriteLine(cmd.CommandText);
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();

                int i = 0;

                while (reader.Read())
                {
                    i++;
                }


                if (i == 1)
                {
                    MainWindow win = new MainWindow();
                    win.Show();
                }
                else
                {
                    MainWindow win = new MainWindow();
                    win.Show();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch Block = " + ex);
            }
            finally
            {

                connection.Close();
            }
        
        }
    }
}
