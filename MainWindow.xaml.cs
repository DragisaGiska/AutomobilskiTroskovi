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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MySql.Data.MySqlClient;

namespace XO_1_9_2015
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.connectionString);
       DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            readAvgMinMaxFromDB();

            setTimer();
        }
        private void setTimer()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0,0,10);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            readAvgMinMaxFromDB();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void readAvgMinMaxFromDB()
        {
            try
            {
                connection.Open();
                double ukupno = 0;
                string query = "SELECT COUNT(*) FROM potrosnja;";
                MySqlCommand command1 = new MySqlCommand(query, connection);
                if (Convert.ToDouble(command1.ExecuteScalar()) > 0)
                {
                    string query1 = "SELECT AVG(potroseno_litara) FROM potrosnja;";
                    string query2 = "SELECT MAX(potroseno_litara) FROM potrosnja;";
                    string query3 = "SELECT MIN(potroseno_litara) FROM potrosnja;";
                    command1 = new MySqlCommand(query1, connection);
                    double avgPL = Convert.ToDouble(command1.ExecuteScalar());
                    command1 = new MySqlCommand(query2, connection);
                    double maxPL = Convert.ToDouble(command1.ExecuteScalar());
                    command1 = new MySqlCommand(query3, connection);
                    double minPL = Convert.ToDouble(command1.ExecuteScalar());

                    lbAvgPotrosnja.Content = string.Format("{0:0.00}", avgPL) + " l";
                    lbMaxPotrosnja.Content = string.Format("{0:0.00}", maxPL) + " l";
                    lbMinPotrosnja.Content = string.Format("{0:0.00}", minPL) + " l";

                    string queryy = "SELECT SUM(potroseno_litara*cijena_po_litru) FROM potrosnja;";
                    command1 = new MySqlCommand(queryy, connection);
                    double rez = Convert.ToDouble(command1.ExecuteScalar());
                    
                    lbUkupnaPotrosnja.Content = string.Format("{0:0.00}", rez) + " KM";
                    ukupno+= Convert.ToDouble(lbUkupnaPotrosnja.Content.ToString().Substring(0,lbUkupnaPotrosnja.Content.ToString().Length-3));
                }
                else
                {
                    lbAvgPotrosnja.Content = "- l";
                    lbMaxPotrosnja.Content = "- l";
                    lbMinPotrosnja.Content = "- l";
                    lbUkupnaPotrosnja.Content = "- KM";
                }
                query = "SELECT COUNT(*) FROM troskovi";
                command1 = new MySqlCommand(query, connection);
                if (Convert.ToDouble(command1.ExecuteScalar()) > 0)
                {
                    string query4 = "SELECT AVG(Cijena) FROM troskovi;";
                    string query5 = "SELECT MAX(Cijena) FROM troskovi;";
                    string query6 = "SELECT MIN(Cijena) FROM troskovi;";
                    command1 = new MySqlCommand(query4, connection);
                    double avgTR = Convert.ToDouble(command1.ExecuteScalar());
                    command1 = new MySqlCommand(query5, connection);
                    double maxTR = Convert.ToDouble(command1.ExecuteScalar());
                    command1 = new MySqlCommand(query6, connection);
                    double minTR = Convert.ToDouble(command1.ExecuteScalar());

                    lbAvgTroskovi.Content = string.Format("{0:0.00}", avgTR) + " KM";
                    lbMaxTroskovi.Content = string.Format("{0:0.00}", maxTR) + " KM";
                    lbMinTroskovi.Content = string.Format("{0:0.00}", minTR) + " KM";

                    string queryy = "SELECT SUM(Cijena) FROM troskovi;";
                    command1 = new MySqlCommand(queryy, connection);
                    double rez = Convert.ToDouble(command1.ExecuteScalar());
                    lbUkupniTroskovi.Content = string.Format("{0:0.00}", rez) + " KM";

                    ukupno += Convert.ToDouble(lbUkupniTroskovi.Content.ToString().Substring(0, lbUkupnaPotrosnja.Content.ToString().Length - 3));
                }
                else
                {
                    lbAvgTroskovi.Content ="- KM";
                    lbMaxTroskovi.Content = "- KM";
                    lbMinTroskovi.Content ="- KM";
                    lbUkupniTroskovi.Content = "- KM";
                }
                query = "SELECT COUNT(*) FROM servisi";
                command1 = new MySqlCommand(query, connection);
                if (Convert.ToDouble(command1.ExecuteScalar()) > 0)
                {
                    string query7 = "SELECT AVG(Cijena) FROM servisi;";
                    string query8 = "SELECT MAX(Cijena) FROM servisi;";
                    string query9 = "SELECT MIN(Cijena) FROM servisi;";
                    command1 = new MySqlCommand(query7, connection);
                    double avgSER = Convert.ToDouble(command1.ExecuteScalar());
                    command1 = new MySqlCommand(query8, connection);
                    double maxSER = Convert.ToDouble(command1.ExecuteScalar());
                    command1 = new MySqlCommand(query9, connection);
                    double minSER = Convert.ToDouble(command1.ExecuteScalar());

                    lbAvgServis.Content = string.Format("{0:0.00}", avgSER) + " KM";
                    lbMaxServis.Content = string.Format("{0:0.00}", maxSER) + " KM";
                    lbMinServis.Content = string.Format("{0:0.00}", minSER) + " KM";

                    string queryy = "SELECT SUM(Cijena) FROM servisi;";
                    command1 = new MySqlCommand(queryy, connection);
                    double rez = Convert.ToDouble(command1.ExecuteScalar());
                    lbUkupanServis.Content= string.Format("{0:0.00}", rez) + " KM";
                    
                    ukupno += Convert.ToDouble(lbUkupanServis.Content.ToString().Substring(0, lbUkupnaPotrosnja.Content.ToString().Length - 3));
                }
                else
                {
                    lbAvgServis.Content = "- KM";
                    lbMaxServis.Content = "- KM";
                    lbMinServis.Content = "- KM";
                    lbUkupanServis.Content = "- KM";
                }

                lbUkupno.Content = "Ukupno: " + string.Format("{0:0.00}",ukupno) + " KM";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }


        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UnosNovihPodataka unosNP = new UnosNovihPodataka("troskovi");
            unosNP.ShowDialog();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            UnosNovihPodataka unosNP = new UnosNovihPodataka("servis");
            unosNP.ShowDialog();
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            UnosPotrosnje potrosnja = new UnosPotrosnje();
            potrosnja.ShowDialog();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }
    }
}
