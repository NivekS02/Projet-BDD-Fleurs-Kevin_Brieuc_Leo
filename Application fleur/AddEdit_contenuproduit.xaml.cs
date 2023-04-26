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
    /// Logique d'interaction pour AddEdit_contenubouquet.xaml
    /// </summary>
    public partial class AddEdit_contenuproduit : Window
    {
        public static MySqlConnection connection;
        private int numero_commande;
        private string nom;
        private int quantite;
        public AddEdit_contenuproduit()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=Projet_fleurs;UID=root;PASSWORD=root;";
            connection = new MySqlConnection(connectionString);
        }

        private void ButtonAnnuler(object sender, RoutedEventArgs e)
        {
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }

        private void ButtonValider_contenuproduit(object sender, RoutedEventArgs e)
        {
            string query = "Select count(*) from commande;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            nom = nom_produit.Text;
            numero_commande = Convert.ToInt32(command.ExecuteScalar())+1;
            quantite = Convert.ToInt32(quantite_produit.Text);
            query = "INSERT INTO contenant_produit (num_commande,nom_produit,quantite_produit) VALUES (@num_commande,@nom_produit,@quantite_produit)";
            command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@num_commande", numero_commande);
            command.Parameters.AddWithValue("@nom_produit", nom);
            command.Parameters.AddWithValue("@quantite_produit", quantite);
            command.ExecuteNonQuery();
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }

        private void ButtonAdd_produit(object sender, RoutedEventArgs e)
        {
            string query = "Select count(*) from commande;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            nom = nom_produit.Text;
            numero_commande = Convert.ToInt32(command.ExecuteScalar()) + 1;
            quantite = Convert.ToInt32(quantite_produit.Text);
            query = "INSERT INTO contenant_produit (num_commande,nom_produit,quantite_produit) VALUES (@num_commande,@nom_produit,@quantite_produit)";
            command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@num_commande", numero_commande);
            command.Parameters.AddWithValue("@nom_produit", nom);
            command.Parameters.AddWithValue("@quantite_produit", quantite);
            command.ExecuteNonQuery();
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
            var w = new AddEdit_contenuproduit();
            w.Show();
        }

        private void ButtonAdd_bouquet(object sender, RoutedEventArgs e)
        {
            string query = "Select count(*) from commande;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            nom = nom_produit.Text;
            numero_commande = Convert.ToInt32(command.ExecuteScalar()) + 1;
            quantite = Convert.ToInt32(quantite_produit.Text);
            query = "INSERT INTO contenant_produit (num_commande,nom_produit,quantite_produit) VALUES (@num_commande,@nom_produit,@quantite_produit)";
            command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@num_commande", numero_commande);
            command.Parameters.AddWithValue("@nom_produit", nom);
            command.Parameters.AddWithValue("@quantite_produit", quantite);
            command.ExecuteNonQuery();
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
            var w = new AddEdit_contenubouquet();
            w.Show();
        }
    }
}
