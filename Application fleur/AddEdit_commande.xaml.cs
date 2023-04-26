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
        private int id_magasin;
        public int id_client;
        private string nom;
        private string courriel;
        private bool creer;
        public AddEdit_commande()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=Projet_fleurs;UID=root;PASSWORD=root;";
            connection = new MySqlConnection(connectionString);
        }

        private void ButtonValider_commande(object sender, RoutedEventArgs e)
        {
            if (creer==false)
            {
                date_commande = DateTime.Now;
                message_commande = message.Text;
                courriel = courriel_client.Text;
                nom = nom_magasin.Text;
                connection.Open();
                string query = "SELECT id_client from client where courriel=@courriel_client;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@courriel_client", courriel);
                id_client = Convert.ToInt32(command.ExecuteScalar());
                query = "SELECT id_magasin from magasin where nom_magasin=@nom_magasin;";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nom_magasin", nom);
                id_magasin = Convert.ToInt32(command.ExecuteScalar());
                d_livraison = DateTime.Now.AddDays(7);

                query = "SELECT adresse_facturation from client where id_client=@id_client;";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_client", id_client);
                adresse = Convert.ToString(command.ExecuteScalar());
                query = "INSERT INTO commande (date_commande,adresse_livraison,message,date_livraison,etat_commande,id_client,id_magasin) VALUES (@date_commande,@adresse_livraison,@message,@date_livraison,@etat_commande,@id_client,@id_magasin)";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@date_commande", date_commande);
                command.Parameters.AddWithValue("@adresse_livraison", adresse);
                command.Parameters.AddWithValue("@message", message_commande);
                command.Parameters.AddWithValue("@date_livraison", d_livraison);
                command.Parameters.AddWithValue("@etat_commande", "VINV");
                command.Parameters.AddWithValue("@id_client", id_client);
                command.Parameters.AddWithValue("@id_magasin", id_magasin);
                command.ExecuteNonQuery();
                connection.Close();
                creer = true;
            }
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }

        private void ButtonAnnuler(object sender, RoutedEventArgs e)
        {
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }

        private void ButtonAdd_bouquet(object sender, RoutedEventArgs e)
        {
            if (creer == false)
            {
                date_commande = DateTime.Now;
                message_commande = message.Text;
                courriel = courriel_client.Text;
                nom = nom_magasin.Text;
                connection.Open();
                string query = "SELECT id_client from client where courriel=@courriel_client;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@courriel_client", courriel);
                id_client = Convert.ToInt32(command.ExecuteScalar());
                query = "SELECT id_magasin from magasin where nom_magasin=@nom_magasin;";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nom_magasin", nom);
                id_magasin = Convert.ToInt32(command.ExecuteScalar());
                d_livraison = DateTime.Now.AddDays(7);

                query = "SELECT adresse_facturation from client where id_client=@id_client;";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_client", id_client);
                adresse = Convert.ToString(command.ExecuteScalar());
                query = "INSERT INTO commande (date_commande,adresse_livraison,message,date_livraison,etat_commande,id_client,id_magasin) VALUES (@date_commande,@adresse_livraison,@message,@date_livraison,@etat_commande,@id_client,@id_magasin)";
                MySqlCommand command2 = new MySqlCommand(query, connection);
                command2.Parameters.AddWithValue("@date_commande", date_commande);
                command2.Parameters.AddWithValue("@adresse_livraison", adresse);
                command2.Parameters.AddWithValue("@message", message_commande);
                command2.Parameters.AddWithValue("@date_livraison", d_livraison);
                command2.Parameters.AddWithValue("@etat_commande", "VINV");
                command2.Parameters.AddWithValue("@id_client", id_client);
                command2.Parameters.AddWithValue("@id_magasin", id_magasin);
                command2.ExecuteNonQuery();
                connection.Close();
                creer = true;
            }
            var w = new AddEdit_contenubouquet();
            w.Show();
        }

        private void ButtonAdd_produit(object sender, RoutedEventArgs e)
        {
            if (creer == false)
            {
                date_commande = DateTime.Now;
                message_commande = message.Text;
                courriel = courriel_client.Text;
                nom = nom_magasin.Text;
                connection.Open();
                string query = "SELECT id_client from client where courriel=@courriel_client;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@courriel_client", courriel);
                id_client = Convert.ToInt32(command.ExecuteScalar());
                query = "SELECT id_magasin from magasin where nom_magasin=@nom_magasin;";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nom_magasin", nom);
                id_magasin = Convert.ToInt32(command.ExecuteScalar());
                d_livraison = DateTime.Now.AddDays(7);

                query = "SELECT adresse_facturation from client where id_client=@id_client;";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_client", id_client);
                adresse = Convert.ToString(command.ExecuteScalar());
                query = "INSERT INTO commande (date_commande,adresse_livraison,message,date_livraison,etat_commande,id_client,id_magasin) VALUES (@date_commande,@adresse_livraison,@message,@date_livraison,@etat_commande,@id_client,@id_magasin)";
                MySqlCommand command2 = new MySqlCommand(query, connection);
                command2.Parameters.AddWithValue("@date_commande", date_commande);
                command2.Parameters.AddWithValue("@adresse_livraison", adresse);
                command2.Parameters.AddWithValue("@message", message_commande);
                command2.Parameters.AddWithValue("@date_livraison", d_livraison);
                command2.Parameters.AddWithValue("@etat_commande", "VINV");
                command2.Parameters.AddWithValue("@id_client", id_client);
                command2.Parameters.AddWithValue("@id_magasin", id_magasin);
                command2.ExecuteNonQuery();
                connection.Close();
                creer = true;
            }
            var w = new AddEdit_contenuproduit();
            w.Show();
        }
    }
}
