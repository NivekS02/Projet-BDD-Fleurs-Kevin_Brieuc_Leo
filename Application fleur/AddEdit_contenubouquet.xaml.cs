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
    public partial class AddEdit_contenubouquet : Window
    {
        public static MySqlConnection connection;
        private string nom;
        private int numero_commande;
        private int quantite;
        private int id_magasin;
        private int stock;
        public AddEdit_contenubouquet()
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

        private void ButtonValider_contenubouquet(object sender, RoutedEventArgs e)
        {
            string query = "Select count(*) from commande;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            nom = nom_bouquet.Text;
            quantite = Convert.ToInt32(quantite_bouquet.Text);
            numero_commande = Convert.ToInt32(command.ExecuteScalar());
            command.CommandText = "SELECT id_magasin from commande where num_commande=@num_commande;";
            command.Parameters.AddWithValue("@num_commande", numero_commande);
            id_magasin = Convert.ToInt32(command.ExecuteScalar());
            command.CommandText = "SELECT stock_bouquet from bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
            command.Parameters.AddWithValue("@nom_bouquet", nom);
            command.Parameters.AddWithValue("@id_magasin", id_magasin);
            stock = Convert.ToInt32(command.ExecuteScalar());
            if (stock > 0)
            {
                command.CommandText = "INSERT INTO contenant_bouquet (num_commande,nom_bouquet,quantite_bouquet) VALUES (@num_commande,@nom_bouquet,@quantite_bouquet)";
                command.Parameters.AddWithValue("@quantite_bouquet", quantite);
                command.ExecuteNonQuery();
                command.CommandText = "UPDATE bouquet set stock_bouquet=stock_bouquet-@quantite_bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
                command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Nous sommes désolés mais nous n'avons plus de stock pour ce bouquet dans ce magasin\nVeuillez nous excuser pour la gêne occasionnée");
                connection.Close();
                return;
            }
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }

        private void ButtonAdd_bouquet(object sender, RoutedEventArgs e)
        {
            string query = "Select count(*) from commande;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            nom = nom_bouquet.Text;
            quantite = Convert.ToInt32(quantite_bouquet.Text);
            numero_commande = Convert.ToInt32(command.ExecuteScalar());
            command.CommandText = "SELECT id_magasin from commande where num_commande=@num_commande;";
            command.Parameters.AddWithValue("@num_commande", numero_commande);
            id_magasin = Convert.ToInt32(command.ExecuteScalar());
            command.CommandText = "SELECT stock_bouquet from bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
            command.Parameters.AddWithValue("@nom_bouquet", nom);
            command.Parameters.AddWithValue("@id_magasin", id_magasin);
            stock = Convert.ToInt32(command.ExecuteScalar());
            if (stock > 0)
            {
                command.CommandText = "INSERT INTO contenant_bouquet (num_commande,nom_bouquet,quantite_bouquet) VALUES (@num_commande,@nom_bouquet,@quantite_bouquet)";
                command.Parameters.AddWithValue("@quantite_bouquet", quantite);
                command.ExecuteNonQuery();
                command.CommandText = "UPDATE bouquet set stock_bouquet=stock_bouquet-@quantite_bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
                command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Nous sommes désolés mais nous n'avons plus de stock pour ce bouquet dans ce magasin\nVeuillez nous excuser pour la gêne occasionnée");
                connection.Close();
                return;
            }
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
            var w = new AddEdit_contenubouquet();
            w.Show();
        }

        private void ButtonAdd_produit(object sender, RoutedEventArgs e)
        {
            string query = "Select count(*) from commande;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            nom = nom_bouquet.Text;
            quantite = Convert.ToInt32(quantite_bouquet.Text);
            numero_commande = Convert.ToInt32(command.ExecuteScalar());
            command.CommandText = "SELECT id_magasin from commande where num_commande=@num_commande;";
            command.Parameters.AddWithValue("@num_commande", numero_commande);
            id_magasin = Convert.ToInt32(command.ExecuteScalar());
            command.CommandText = "SELECT stock_bouquet from bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
            command.Parameters.AddWithValue("@nom_bouquet", nom);
            command.Parameters.AddWithValue("@id_magasin", id_magasin);
            stock = Convert.ToInt32(command.ExecuteScalar());
            if (stock > 0)
            {
                command.CommandText = "INSERT INTO contenant_bouquet (num_commande,nom_bouquet,quantite_bouquet) VALUES (@num_commande,@nom_bouquet,@quantite_bouquet)";
                command.Parameters.AddWithValue("@quantite_bouquet", quantite);
                command.ExecuteNonQuery();
                command.CommandText = "UPDATE bouquet set stock_bouquet=stock_bouquet-@quantite_bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
                command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Nous sommes désolés mais nous n'avons plus de stock pour ce bouquet dans ce magasin\nVeuillez nous excuser pour la gêne occasionnée");
                connection.Close();
                return;
            }
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
            var w = new AddEdit_contenuproduit();
            w.Show();
        }
    }
}
