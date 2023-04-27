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
    public partial class AddEdit_bouquet : Window
    {
        public static MySqlConnection connection;
        private string nom;
        private string composition;
        private string categorie;

        public AddEdit_bouquet()
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

        private void ButtonValider_bouquet(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(nom_bouquet.Text) && !string.IsNullOrEmpty(composition_fleurs.Text) && int.TryParse(stock_bouquet.Text, out int stock) && float.TryParse(prix_bouquet.Text, out float prix) && !string.IsNullOrEmpty(categorie_bouquet.Text) && int.TryParse(id_magasin.Text, out int ID) && ID>0)
            {
                nom = nom_bouquet.Text;
                composition = composition_fleurs.Text;
                categorie = categorie_bouquet.Text;
                string query = "";
                MySqlCommand command = new MySqlCommand(query, connection);
                query = "INSERT INTO bouquet (nom_bouquet,composition_fleurs,stock_bouquet,prix_bouquet,categorie_bouquet,id_magasin) VALUES (@nom_bouquet,@composition_fleurs,@stock_bouquet,@prix_bouquet,@categorie_bouquet,@id_magasin)";
                connection.Open();
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nom_bouquet", nom);
                command.Parameters.AddWithValue("@composition_fleurs", composition);
                command.Parameters.AddWithValue("@stock_bouquet", stock);
                command.Parameters.AddWithValue("@prix_bouquet", prix);
                command.Parameters.AddWithValue("@categorie_bouquet", categorie);
                command.Parameters.AddWithValue("@id_magasin", ID);
                command.ExecuteNonQuery();
                connection.Close();
                Window activeWindow = Window.GetWindow(this);
                activeWindow.Close();
            }
            else
            {
                MessageBox.Show("Valeurs entrées incorrects ou champs incomplets.");
            }      
        }
    }
}
