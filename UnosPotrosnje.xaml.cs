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
using MySql.Data.MySqlClient;

namespace XO_1_9_2015
{
    /// <summary>
    /// Interaction logic for UnosPotrosnje.xaml
    /// </summary>
    public partial class UnosPotrosnje : Window
    {
        MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connectionString);

        public UnosPotrosnje()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (checkInput())
            {
                InsertData();
                this.Close();
            }
        }


        public void InsertData()
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO potrosnja (potroseno_litara, predjeno_km, cijena_po_litru) VALUES (" + Double.Parse(tbPotrosenoLitara.Text) + ", " + Double.Parse(tbPredjenoKilometara.Text) + ", " + Double.Parse(tbCijenaPoLitru.Text) + ");";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private bool checkInput()
        {
            if ((!string.IsNullOrWhiteSpace(tbPredjenoKilometara.Text)) && (!string.IsNullOrWhiteSpace(tbPotrosenoLitara.Text) && (!string.IsNullOrWhiteSpace(tbCijenaPoLitru.Text))))
                return true;
            MessageBox.Show("Popunite potrebna polja!");
            return false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbUnosi_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            Double d;
            if (!Double.TryParse(tb.Text, out d))
            {
                tb.Clear();
                MessageBox.Show("Ne dozvoljen unos!");
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
