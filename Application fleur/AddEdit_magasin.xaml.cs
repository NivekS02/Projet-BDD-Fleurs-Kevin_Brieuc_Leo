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
    /// Logique d'interaction pour AddEdit_magasin.xaml
    /// </summary>
    public partial class AddEdit_magasin : Window
    {
        public static MySqlConnection connection;
        private string nom;
        private string adresse;
        private string ville;
        private string chef;
        public AddEdit_magasin()
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

        private void ButtonValider_magasin(object sender, RoutedEventArgs e)
        {
            nom = nom_magasin.Text;
            adresse = adresse_magasin.Text;
            ville = ville_magasin.Text;
            chef = chef_magasin.Text;
            connection.Open();
            string query = "INSERT INTO magasin (adresse,ville,nom_magasin,chef_magasin) VALUES (@adresse_magasin,@ville_magasin,@nom_magasin,@chef_magasin)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nom_magasin", nom);
            command.Parameters.AddWithValue("@adresse_magasin", adresse);
            command.Parameters.AddWithValue("@ville_magasin", ville);
            command.Parameters.AddWithValue("@chef_magasin", chef);
            command.ExecuteNonQuery();
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }
    }
}
