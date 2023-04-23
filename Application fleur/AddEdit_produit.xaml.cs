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
    /// Logique d'interaction pour AddEdit_produit.xaml
    /// </summary>
    public partial class AddEdit_produit : Window
    {
        public static MySqlConnection connection;
        private string nom;
        private int stock;
        private float prix;
        private string dispo;
        private int ID;
        public AddEdit_produit()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=Projet_fleurs;UID=root;PASSWORD=root;";
            connection = new MySqlConnection(connectionString);
        }

        private void ButtonValider_produit(object sender, RoutedEventArgs e)
        {
            nom = nom_produit.Text;
            stock = Convert.ToInt32(stock_produit.Text);
            prix = float.Parse(prix_produit.Text);
            dispo = dispo_produit.Text;
            ID = Convert.ToInt32(id_magasin.Text);
            connection.Open();
            string query = "INSERT INTO produit (nom_produit,stock_produit,prix_produit,dispo_produit,id_magasin) VALUES (@nom_produit,@stock_produit,@prix_produit,@dispo_produit,@id_magasin)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nom_produit", nom);
            command.Parameters.AddWithValue("@stock_produit", stock);
            command.Parameters.AddWithValue("@prix_produit", prix);
            command.Parameters.AddWithValue("@dispo_produit", dispo);
            command.Parameters.AddWithValue("@id_magasin", ID);
            command.ExecuteNonQuery();
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
