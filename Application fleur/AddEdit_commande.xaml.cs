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
        public int id_client;
        private string courriel;
        private bool creer=false;
        public AddEdit_commande()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=Projet_fleurs;UID=root;PASSWORD=root;";
            connection = new MySqlConnection(connectionString);
        }

        private void ButtonValider_commande(object sender, RoutedEventArgs e)
        {
            connection.Open();
            courriel = courriel_client.Text;
            string query = "SELECT courriel FROM client WHERE courriel = @courriel_client";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@courriel_client", courriel);
            object result = command.ExecuteScalar();
            if (result == null)
            {
                MessageBox.Show("Le courriel entré n'existe pas. Veuillez entrer un courriel existant.");
                connection.Close();
                return;
            }
            if (creer == false)
            {
                if (!int.TryParse(ID_magasin.Text, out int ID) || string.IsNullOrEmpty(message.Text) || string.IsNullOrEmpty(courriel_client.Text) || string.IsNullOrEmpty(adresse_livraison.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur");
                    connection.Close();
                    return;
                }
                else
                {
                    date_commande = DateTime.Now;
                    message_commande = message.Text;
                    adresse = adresse_livraison.Text;
                    query = "SELECT id_client from client where courriel=@courriel_client;";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@courriel_client", courriel);
                    id_client = Convert.ToInt32(command.ExecuteScalar());
                    d_livraison = DateTime.Now.AddDays(7);
                    query = "SELECT adresse_facturation from client where id_client=@id_client;";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id_client", id_client);
                    adresse = Convert.ToString(command.ExecuteScalar());
                    query = "INSERT INTO commande (date_commande,adresse_livraison,message,date_livraison,etat_commande,prix_total,id_client,id_magasin) VALUES (@date_commande,@adresse_livraison,@message,@date_livraison,@etat_commande,@prix_total,@id_client,@id_magasin)";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@date_commande", date_commande);
                    command.Parameters.AddWithValue("@adresse_livraison", adresse);
                    command.Parameters.AddWithValue("@message", message_commande);
                    command.Parameters.AddWithValue("@date_livraison", d_livraison);
                    command.Parameters.AddWithValue("@etat_commande", "VINV");
                    command.Parameters.AddWithValue("@id_client", id_client);
                    command.Parameters.AddWithValue("@id_magasin", ID);
                    command.Parameters.AddWithValue("@prix_total", 0);
                    command.ExecuteNonQuery();
                    connection.Close();
                    creer = true;
                }
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
            connection.Open();
            courriel = courriel_client.Text;
            string query = "SELECT courriel FROM client WHERE courriel = @courriel_client";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@courriel_client", courriel);
            object result = command.ExecuteScalar();
            if (result == null)
            {
                MessageBox.Show("Le courriel entré n'existe pas. Veuillez entrer un courriel existant.");
                connection.Close();
                return;
            }
            if (creer == false)
            {
                if (!int.TryParse(ID_magasin.Text, out int ID) || string.IsNullOrEmpty(message.Text) || string.IsNullOrEmpty(courriel_client.Text) || string.IsNullOrEmpty(adresse_livraison.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur");
                    connection.Close();
                    return;
                }
                else
                {
                    date_commande = DateTime.Now;
                    message_commande = message.Text;
                    adresse = adresse_livraison.Text;
                    query = "SELECT id_client from client where courriel=@courriel_client;";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@courriel_client", courriel);
                    id_client = Convert.ToInt32(command.ExecuteScalar());
                    d_livraison = DateTime.Now.AddDays(7);
                    query = "SELECT adresse_facturation from client where id_client=@id_client;";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id_client", id_client);
                    adresse = Convert.ToString(command.ExecuteScalar());
                    query = "INSERT INTO commande (date_commande,adresse_livraison,message,date_livraison,etat_commande,prix_total,id_client,id_magasin) VALUES (@date_commande,@adresse_livraison,@message,@date_livraison,@etat_commande,@prix_total,@id_client,@id_magasin)";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@date_commande", date_commande);
                    command.Parameters.AddWithValue("@adresse_livraison", adresse);
                    command.Parameters.AddWithValue("@message", message_commande);
                    command.Parameters.AddWithValue("@date_livraison", d_livraison);
                    command.Parameters.AddWithValue("@etat_commande", "VINV");
                    command.Parameters.AddWithValue("@id_client", id_client);
                    command.Parameters.AddWithValue("@id_magasin", ID);
                    command.Parameters.AddWithValue("@prix_total", 0);
                    command.ExecuteNonQuery();
                    connection.Close();
                    creer = true;
                }
            }
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
            var w = new AddEdit_contenubouquet();
            w.Show();
        }

        private void ButtonAdd_produit(object sender, RoutedEventArgs e)
        {
            connection.Open();
            courriel = courriel_client.Text;
            string query = "SELECT courriel FROM client WHERE courriel = @courriel_client";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@courriel_client", courriel);
            object result = command.ExecuteScalar();
            if (result == null)
            {
                MessageBox.Show("Le courriel entré n'existe pas. Veuillez entrer un courriel existant.");
                connection.Close();
                return;
            }
            if (creer == false)
            {
                if (!int.TryParse(ID_magasin.Text, out int ID) || string.IsNullOrEmpty(message.Text) || string.IsNullOrEmpty(courriel_client.Text) || string.IsNullOrEmpty(adresse_livraison.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur");
                    connection.Close();
                    return;
                }
                else
                {
                    date_commande = DateTime.Now;
                    message_commande = message.Text;
                    adresse = adresse_livraison.Text;
                    query = "SELECT id_client from client where courriel=@courriel_client;";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@courriel_client", courriel);
                    id_client = Convert.ToInt32(command.ExecuteScalar());
                    d_livraison = DateTime.Now.AddDays(7);
                    query = "SELECT adresse_facturation from client where id_client=@id_client;";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id_client", id_client);
                    adresse = Convert.ToString(command.ExecuteScalar());
                    query = "INSERT INTO commande (date_commande,adresse_livraison,message,date_livraison,etat_commande,prix_total,id_client,id_magasin) VALUES (@date_commande,@adresse_livraison,@message,@date_livraison,@etat_commande,@prix_total,@id_client,@id_magasin)";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@date_commande", date_commande);
                    command.Parameters.AddWithValue("@adresse_livraison", adresse);
                    command.Parameters.AddWithValue("@message", message_commande);
                    command.Parameters.AddWithValue("@date_livraison", d_livraison);
                    command.Parameters.AddWithValue("@etat_commande", "VINV");
                    command.Parameters.AddWithValue("@id_client", id_client);
                    command.Parameters.AddWithValue("@id_magasin", ID);
                    command.Parameters.AddWithValue("@prix_total", 0);
                    command.ExecuteNonQuery();
                    connection.Close();
                    creer = true;
                }
            }
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
            var w = new AddEdit_contenuproduit();
            w.Show();
        }
    }
}
