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
    /// Interaction logic for UnosNovihPodataka.xaml
    /// </summary>
    public partial class UnosNovihPodataka : Window
    {
        MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connectionString);

        private enum IzabranaBaza {
            Servis,
            Troskovi
        };

        IzabranaBaza Baza;
        public UnosNovihPodataka(string baza)
        {
            InitializeComponent();
            if (baza == "servis")
            {
                lbNaziv_Lokacija.Content = "Lokacija";
                Baza = IzabranaBaza.Servis;
            }
            else
            {
                lbNaziv_Lokacija.Content = "Naziv";
                Baza = IzabranaBaza.Troskovi;
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            string query = "";
            TextRange textRange = new TextRange( rtbOpis.Document.ContentStart,  rtbOpis.Document.ContentEnd );
            switch (Baza)
            {
                case IzabranaBaza.Servis:
                     query = "INSERT INTO servisi (Lokacija, Opis, Cijena) VALUES ('"+tbLokacija_Naziv.Text+"', '"+textRange.Text+"', "+Double.Parse(tbCijena.Text) +");";
                    break;
                case IzabranaBaza.Troskovi:
                    query = "INSERT INTO troskovi (Naziv, Opis, Cijena) VALUES ('" + tbLokacija_Naziv.Text + "', '" + textRange.Text + "', " + Double.Parse(tbCijena.Text) + ");";
                    break;
            }
            try
            {
                connection.Open();
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
            if ((!string.IsNullOrWhiteSpace(tbCijena.Text)) && (!string.IsNullOrWhiteSpace(tbLokacija_Naziv.Text)))
                return true;
            MessageBox.Show("Popunite potrebna polja!");
            return false;
        }

        private void tbCijena_TextChanged(object sender, TextChangedEventArgs e)
        {
            Double d;
            if (!Double.TryParse(tbCijena.Text,out d))
            {
                tbCijena.Clear();
                MessageBox.Show("Ne dozvoljen unos!");
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
