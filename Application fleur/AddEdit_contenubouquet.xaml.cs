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
        private int id_magasin;
        private int stock;
        private string categorie_bouquet;
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
            connection.Open();
            if (int.TryParse(quantite_bouquet.Text, out int quantite) && quantite > 0 && !string.IsNullOrEmpty(nom_bouquet.Text))
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                nom = nom_bouquet.Text;
                command.CommandText = "SELECT categorie_bouquet from bouquet where nom_bouquet=@nom_bouquet;";
                command.Parameters.AddWithValue("@nom_bouquet", nom);
                categorie_bouquet = (string)command.ExecuteScalar();
                if (!categorie_bouquet.Split(',').Contains(DateTime.Now.Month.ToString()))
                {
                    MessageBox.Show("Ce produit n'est pas disponible en ce moment.");
                    connection.Close();
                    return;
                }
                command.CommandText= "Select count(*) from commande;";
                quantite = Convert.ToInt32(quantite_bouquet.Text);
                numero_commande = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT id_magasin from commande where num_commande=@num_commande;";
                command.Parameters.AddWithValue("@num_commande", numero_commande);
                id_magasin = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT stock_bouquet from bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
                command.Parameters.AddWithValue("@id_magasin", id_magasin);
                stock = Convert.ToInt32(command.ExecuteScalar());
                if (stock > 0)
                {
                    try
                    {
                        command.CommandText = "INSERT INTO contenant_bouquet (num_commande,nom_bouquet,id_magasin,quantite_bouquet) VALUES (@num_commande,@nom_bouquet,@id_magasin,@quantite_bouquet)";
                        command.Parameters.AddWithValue("@quantite_bouquet", quantite);
                        command.ExecuteNonQuery();
                        command.CommandText = "UPDATE bouquet set stock_bouquet=stock_bouquet-@quantite_bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Nous n'en avons pas assez en stock");
                        connection.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nous sommes désolés mais nous n'avons plus de stock pour ce produit dans ce magasin\nVeuillez nous excuser pour la gêne occasionnée.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Valeurs entrées incorrects ou champs incomplets.");
                return;
            }
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }

        private void ButtonAdd_bouquet(object sender, RoutedEventArgs e)
        {
            connection.Open();
            if (int.TryParse(quantite_bouquet.Text, out int quantite) && quantite > 0 && !string.IsNullOrEmpty(nom_bouquet.Text))
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                nom = nom_bouquet.Text;
                command.CommandText = "SELECT categorie_bouquet from bouquet where nom_bouquet=@nom_bouquet;";
                command.Parameters.AddWithValue("@nom_bouquet", nom);
                categorie_bouquet = (string)command.ExecuteScalar();
                if (!categorie_bouquet.Split(',').Contains(DateTime.Now.Month.ToString()))
                {
                    MessageBox.Show("Ce produit n'est pas disponible en ce moment.");
                    connection.Close();
                    return;
                }
                command.CommandText = "Select count(*) from commande;";
                quantite = Convert.ToInt32(quantite_bouquet.Text);
                numero_commande = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT id_magasin from commande where num_commande=@num_commande;";
                command.Parameters.AddWithValue("@num_commande", numero_commande);
                id_magasin = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT stock_bouquet from bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
                command.Parameters.AddWithValue("@id_magasin", id_magasin);
                stock = Convert.ToInt32(command.ExecuteScalar());
                if (stock > 0)
                {
                    try
                    {
                        command.CommandText = "INSERT INTO contenant_bouquet (num_commande,nom_bouquet,id_magasin,quantite_bouquet) VALUES (@num_commande,@nom_bouquet,@id_magasin,@quantite_bouquet)";
                        command.Parameters.AddWithValue("@quantite_bouquet", quantite);
                        command.ExecuteNonQuery();
                        command.CommandText = "UPDATE bouquet set stock_bouquet=stock_bouquet-@quantite_bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Nous n'en avons pas assez en stock");
                        connection.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nous sommes désolés mais nous n'avons plus de stock pour ce produit dans ce magasin\nVeuillez nous excuser pour la gêne occasionnée.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Valeurs entrées incorrects ou champs incomplets.");
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
            connection.Open();
            if (int.TryParse(quantite_bouquet.Text, out int quantite) && quantite > 0 && !string.IsNullOrEmpty(nom_bouquet.Text))
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                nom = nom_bouquet.Text;
                command.CommandText = "SELECT categorie_bouquet from bouquet where nom_bouquet=@nom_bouquet;";
                command.Parameters.AddWithValue("@nom_bouquet", nom);
                categorie_bouquet = (string)command.ExecuteScalar();
                if (!categorie_bouquet.Split(',').Contains(DateTime.Now.Month.ToString()))
                {
                    MessageBox.Show("Ce produit n'est pas disponible en ce moment.");
                    connection.Close();
                    return;
                }
                command.CommandText = "Select count(*) from commande;";
                quantite = Convert.ToInt32(quantite_bouquet.Text);
                numero_commande = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT id_magasin from commande where num_commande=@num_commande;";
                command.Parameters.AddWithValue("@num_commande", numero_commande);
                id_magasin = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT stock_bouquet from bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
                command.Parameters.AddWithValue("@id_magasin", id_magasin);
                stock = Convert.ToInt32(command.ExecuteScalar());
                if (stock > 0)
                {
                    try
                    {
                        command.CommandText = "INSERT INTO contenant_bouquet (num_commande,nom_bouquet,id_magasin,quantite_bouquet) VALUES (@num_commande,@nom_bouquet,@id_magasin,@quantite_bouquet)";
                        command.Parameters.AddWithValue("@quantite_bouquet", quantite);
                        command.ExecuteNonQuery();
                        command.CommandText = "UPDATE bouquet set stock_bouquet=stock_bouquet-@quantite_bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Nous n'en avons pas assez en stock");
                        connection.Close();
                        return;
                    }
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
    }
}
