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


namespace Projet_BDD_Fleurs
{
    /// <summary>
    /// Logique d'interaction pour Del_commande.xaml
    /// </summary>
    public partial class Del_commande : Window
    {
        private int ID;
        public static MySqlConnection connection;

        public Del_commande()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=Projet_fleurs;UID=root;PASSWORD=root;";
            connection = new MySqlConnection(connectionString);
        }

        private void ButtonDel_commande(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ID_commande.Text, out int ID) && ID>0)
            {
                connection.Open();
                string query = "DELETE FROM contenant_produit where num_commande=@ID;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
                query = "DELETE FROM contenant_bouquet where num_commande=@ID;";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
                query = "DELETE FROM commande where num_commande=@ID;";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Valeur entrée incorrect.");
                return;
            }
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }

        private void ButtonAnnuler(object sender, RoutedEventArgs e)
        {
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }
    }
}
