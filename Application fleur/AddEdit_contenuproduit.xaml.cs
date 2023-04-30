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
        private int id_magasin;
        private int stock;
        private string dispo_produit;
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
            connection.Open();
            if (int.TryParse(quantite_produit.Text, out int quantite) && quantite > 0 && !string.IsNullOrEmpty(nom_produit.Text))
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                nom = nom_produit.Text;
                command.CommandText = "SELECT dispo_produit from produit where nom_produit=@nom_produit;";
                command.Parameters.AddWithValue("@nom_produit", nom);
                dispo_produit = (string)command.ExecuteScalar();
                if(!dispo_produit.Split(',').Contains(DateTime.Now.Month.ToString()))
                {
                    MessageBox.Show("Ce produit n'est pas disponible en ce moment.");
                    connection.Close();
                    return;
                }
                command.CommandText = "Select count(*) from commande;";
                numero_commande = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT id_magasin from commande where num_commande=@num_commande;";
                command.Parameters.AddWithValue("@num_commande", numero_commande);
                id_magasin = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT stock_produit from produit where nom_produit=@nom_produit and id_magasin=@id_magasin;";
                command.Parameters.AddWithValue("@id_magasin", id_magasin);
                stock = Convert.ToInt32(command.ExecuteScalar());
                if (stock > 0)
                {
                    command.CommandText = "INSERT INTO contenant_produit (num_commande,nom_produit,quantite_produit) VALUES (@num_commande,@nom_produit,@quantite_produit)";
                    command.Parameters.AddWithValue("@quantite_produit", quantite);
                    command.ExecuteNonQuery();
                    command.CommandText = "UPDATE produit set stock_produit=stock_produit-@quantite_produit where nom_produit=@nom_produit and id_magasin=@id_magasin;";
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Nous sommes désolés mais nous n'avons plus de stock pour ce produit dans ce magasin\nVeuillez nous excuser pour la gêne occasionnée.");
                    connection.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Valeurs entrées incorrects ou champs incomplets.");
                connection.Close();
                return;
            }
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }

        private void ButtonAdd_produit(object sender, RoutedEventArgs e)
        {
            connection.Open();
            if (int.TryParse(quantite_produit.Text, out int quantite) && quantite > 0 && !string.IsNullOrEmpty(nom_produit.Text))
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                nom = nom_produit.Text;
                command.CommandText = "SELECT dispo_produit from produit where nom_produit=@nom_produit;";
                command.Parameters.AddWithValue("@nom_produit", nom);
                dispo_produit = (string)command.ExecuteScalar();
                if (!dispo_produit.Split(',').Contains(DateTime.Now.Month.ToString()))
                {
                    MessageBox.Show("Ce produit n'est pas disponible en ce moment.");
                    connection.Close();
                    return;
                }
                command.CommandText = "Select count(*) from commande;";
                numero_commande = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT id_magasin from commande where num_commande=@num_commande;";
                command.Parameters.AddWithValue("@num_commande", numero_commande);
                id_magasin = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT stock_produit from produit where nom_produit=@nom_produit and id_magasin=@id_magasin;";
                command.Parameters.AddWithValue("@id_magasin", id_magasin);
                stock = Convert.ToInt32(command.ExecuteScalar());
                if (stock > 0)
                {
                    command.CommandText = "INSERT INTO contenant_produit (num_commande,nom_produit,quantite_produit) VALUES (@num_commande,@nom_produit,@quantite_produit)";
                    command.Parameters.AddWithValue("@quantite_produit", quantite);
                    command.ExecuteNonQuery();
                    command.CommandText = "UPDATE produit set stock_produit=stock_produit-@quantite_produit where nom_produit=@nom_produit and id_magasin=@id_magasin;";
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Nous sommes désolés mais nous n'avons plus de stock pour ce produit dans ce magasin\nVeuillez nous excuser pour la gêne occasionnée.");
                    connection.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Valeurs entrées incorrects ou champs incomplets.");
                connection.Close();
                return;
            }
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
            var w = new AddEdit_contenuproduit();
            w.Show();
        }

        private void ButtonAdd_bouquet(object sender, RoutedEventArgs e)
        {
            connection.Open();
            if (int.TryParse(quantite_produit.Text, out int quantite) && quantite > 0 && !string.IsNullOrEmpty(nom_produit.Text))
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                nom = nom_produit.Text;
                command.CommandText = "SELECT dispo_produit from produit where nom_produit=@nom_produit;";
                command.Parameters.AddWithValue("@nom_produit", nom);
                dispo_produit = (string)command.ExecuteScalar();
                if (!dispo_produit.Split(',').Contains(DateTime.Now.Month.ToString()))
                {
                    MessageBox.Show("Ce produit n'est pas disponible en ce moment.");
                    connection.Close();
                    return;
                }
                command.CommandText = "Select count(*) from commande;";
                numero_commande = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT id_magasin from commande where num_commande=@num_commande;";
                command.Parameters.AddWithValue("@num_commande", numero_commande);
                id_magasin = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT stock_produit from produit where nom_produit=@nom_produit and id_magasin=@id_magasin;";
                command.Parameters.AddWithValue("@id_magasin", id_magasin);
                stock = Convert.ToInt32(command.ExecuteScalar());
                if (stock > 0)
                {
                    command.CommandText = "INSERT INTO contenant_produit (num_commande,nom_produit,quantite_produit) VALUES (@num_commande,@nom_produit,@quantite_produit)";
                    command.Parameters.AddWithValue("@quantite_produit", quantite);
                    command.ExecuteNonQuery();
                    command.CommandText = "UPDATE produit set stock_produit=stock_produit-@quantite_produit where nom_produit=@nom_produit and id_magasin=@id_magasin;";
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Nous sommes désolés mais nous n'avons plus de stock pour ce produit dans ce magasin\nVeuillez nous excuser pour la gêne occasionnée.");
                    connection.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Valeurs entrées incorrects ou champs incomplets.");
                connection.Close();
                return;
            }
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
            var w = new AddEdit_contenubouquet();
            w.Show();
        }
    }
}
