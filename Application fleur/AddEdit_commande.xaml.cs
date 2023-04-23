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
    /// Logique d'interaction pour AddEdit_commande.xaml
    /// </summary>
    public partial class AddEdit_commande : Window
    {
        public static MySqlConnection connection;
        private DateTime date_commande;
        private string message_commande;
        private string adresse;
        private DateTime d_livraison;
        private int id_mag;
        private int id_cli;
        public AddEdit_commande()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=Projet_fleurs;UID=root;PASSWORD=root;";
            connection = new MySqlConnection(connectionString);
        }

        private void ButtonValider_commande(object sender, RoutedEventArgs e)
        {
            date_commande = DateTime.Now;
            message_commande = message.Text;
            id_cli = Convert.ToInt32(id_client.Text);
            id_mag = Convert.ToInt32(id_magasin.Text);
            d_livraison = Convert.ToDateTime(date_livraison.Text);
            connection.Open();
            string query1 = "SELECT adresse_facturation from client where id_client=@id_client;";
            MySqlCommand command1 = new MySqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@id_client", id_cli);
            adresse = Convert.ToString(command1.ExecuteScalar());
            string query2 = "INSERT INTO commande (date_commande,adresse_livraison,message,date_livraison,etat_commande,id_client,id_magasin) VALUES (@date_commande,@adresse_livraison,@message,@date_livraison,@etat_commande,@id_client,@id_magasin)";
            MySqlCommand command2 = new MySqlCommand(query2, connection);
            command2.Parameters.AddWithValue("@date_commande", date_commande);
            command2.Parameters.AddWithValue("@adresse_livraison", adresse);
            command2.Parameters.AddWithValue("@message", message_commande);
            command2.Parameters.AddWithValue("@date_livraison", d_livraison);
            command2.Parameters.AddWithValue("@etat_commande", "VINV");
            command2.Parameters.AddWithValue("@id_client", id_cli);
            command2.Parameters.AddWithValue("@id_magasin", id_mag);
            command2.ExecuteNonQuery();
            connection.Close();
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
