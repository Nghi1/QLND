using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
    /// Interaction logic for QLNguoiDung.xaml
    /// </summary>
    public partial class QLNguoiDung : Window
    {
        private String ConnectionString;
        private SqlConnection connection;
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader reader;
        public DataTable getNguoiDung()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM NGUOIDUNG", ConnectionString);
            DataTable dtNguoiDung = new DataTable();
            da.Fill(dtNguoiDung);
            return dtNguoiDung;
        }
        public QLNguoiDung()
        {
            InitializeComponent();
            ConnectionString = @"Data Source=LAPTOP-LTSR3KDB;Initial Catalog=QLNguoiDung;Integrated Security=True";
            connection = new SqlConnection(ConnectionString);
            grid1.DataContext = getNguoiDung();
           
        }

        private void grid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = idtxt.Text;
            try
            {
                Console.WriteLine(idtxt.Text);

                cmd.CommandText = "DELETE FROM NGUOIDUNG WHERE Id = @param1";

                cmd.Parameters.AddWithValue("@param1", id);
                
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
                    MessageBox.Show("Đã Xóa Thành Công");
                }
                else
                {
                    MessageBox.Show("Đã Xóa Thành Công");
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

        private void butxn_Click(object sender, RoutedEventArgs e)
        {
            string id = idtxt.Text;
            string key = keytxt.Text;
            try
            {
                Console.WriteLine(idtxt.Text);

                cmd.CommandText = "UPDATE NGUOIDUNG SET KeyDN=@param2 WHERE Id = @param1";

                cmd.Parameters.AddWithValue("@param1", id);
                cmd.Parameters.AddWithValue("@param2", key);
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
                    MessageBox.Show("Đã Xong");
                }
                else
                {
                    MessageBox.Show("Đã Xong");
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            grid1.DataContext = getNguoiDung();
        }
    }

   
}
