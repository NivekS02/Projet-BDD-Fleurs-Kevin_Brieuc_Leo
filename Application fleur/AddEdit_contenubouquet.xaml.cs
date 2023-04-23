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
        private int numero_commande;
        private string nom;
        private int quantite;
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
            nom = nom_bouquet.Text;
            numero_commande = Convert.ToInt32(num_commande.Text);
            quantite = Convert.ToInt32(quantite_bouquet.Text);
            connection.Open();
            string query = "INSERT INTO contenant_bouquet (num_commande,nom_bouquet,quantite_bouquet) VALUES (@num_commande,@nom_bouquet,@quantite_bouquet)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@num_commande", numero_commande);
            command.Parameters.AddWithValue("@nom_bouquet", nom);
            command.Parameters.AddWithValue("@quantite_bouquet", quantite);
            command.ExecuteNonQuery();
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }
    }
}
