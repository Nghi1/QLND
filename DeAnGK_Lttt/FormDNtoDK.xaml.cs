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
    /// Interaction logic for FormDNtoDK.xaml
    /// </summary>
    public partial class FormDNtoDK : Window
    {
        private String ConnectionString;
        private SqlConnection connection;
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader reader;
        public FormDNtoDK()
        {
            InitializeComponent();
            ConnectionString = @"Data Source=LAPTOP-LTSR3KDB;Initial Catalog=QLNguoiDung;Integrated Security=True";
            connection = new SqlConnection(ConnectionString);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine(nametxt.Text + " and " + mktxt.Text);

                cmd.CommandText = "SELECT *FROM NGUOIDUNG WHERE TenNguoiDung='" + nametxt.Text + "' and MatKhau='" + mktxt.Text + "' and KeyDN!='Lock Login'";

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
                    DangKyCV win = new DangKyCV();
                    win.Show();
                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập, hoặc không có quyền đăng nhập");
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
