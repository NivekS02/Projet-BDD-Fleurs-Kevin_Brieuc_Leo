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
    /// Logique d'interaction pour Del_magasin.xaml
    /// </summary>
    public partial class Del_magasin : Window
    {
        private int num_commande;
        public static MySqlConnection connection;
        public static MySqlConnection connection2;
        public Del_magasin()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=Projet_fleurs;UID=root;PASSWORD=root;";
            connection = new MySqlConnection(connectionString);
            connection2 = new MySqlConnection(connectionString);
        }

        private void ButtonDel_magasin(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ID_magasin.Text, out int ID) && ID > 0)
            {
                connection.Open();
                connection2.Open();
                string query = "SELECT num_commande from commande where id_magasin=@ID;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = command.ExecuteReader();
                MySqlCommand command2 = new MySqlCommand();
                command2.Connection = connection2;
                while (reader.Read())
                {
                    command2.Parameters.Clear();
                    num_commande = reader.GetInt32(0);
                    command2.CommandText = "DELETE FROM contenant_produit where num_commande=@num_commande;";
                    command2.Parameters.AddWithValue("@num_commande", num_commande);
                    command2.ExecuteNonQuery();
                    command2.CommandText = "DELETE FROM contenant_bouquet where num_commande=@num_commande;";
                    command2.ExecuteNonQuery();
                    command2.CommandText = "DELETE FROM commande where num_commande=@num_commande;";
                    command2.ExecuteNonQuery();
                }
                reader.Close();
                command.CommandText = "DELETE FROM produit where id_magasin=@ID;";
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM bouquet where id_magasin=@ID;";
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM magasin where id_magasin=@ID;";
                command.ExecuteNonQuery();
                connection.Close();
                connection2.Close();
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
