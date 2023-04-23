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
        private int stock;
        private float prix;
        private string categorie;
        private int ID;
        private int modification_id;
        private string modification_bouquet;

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
            nom = nom_bouquet.Text;
            composition = composition_fleurs.Text;
            stock = Convert.ToInt32(stock_bouquet.Text);
            prix = float.Parse(prix_bouquet.Text);
            categorie = categorie_bouquet.Text;
            ID = Convert.ToInt32(id_magasin.Text);
            string query = "";

            MySqlCommand command = new MySqlCommand(query, connection);
            if (modif_id.Text == "" && modif_bouquet.Text=="")
            {
                query = "INSERT INTO bouquet (nom_bouquet,composition_fleurs,stock_bouquet,prix_bouquet,categorie_bouquet,id_magasin) VALUES (@nom_bouquet,@composition_fleurs,@stock_bouquet,@prix_bouquet,@categorie_bouquet,@id_magasin)";
                connection.Open();
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nom_bouquet", nom);
                command.Parameters.AddWithValue("@composition_fleurs", composition);
                command.Parameters.AddWithValue("@stock_bouquet", stock);
                command.Parameters.AddWithValue("@prix_bouquet", prix);
                command.Parameters.AddWithValue("@categorie_bouquet", categorie);
                command.Parameters.AddWithValue("@id_magasin", ID);
            }
            else if (modif_id.Text != "" && modif_bouquet.Text != "")
            {
                modification_id = Convert.ToInt32(modif_id.Text);
                modification_bouquet = modif_bouquet.Text;
                query = "UPDATE bouquet set nom_bouquet=@nom_bouquet,composition_fleurs=@composition_fleurs,stock_bouquet=@stock_bouquet,prix_bouquet=@prix_bouquet,categorie_bouquet=@categorie_bouquet,id_magasin=@id_magasin where nom_bouquet=@modif_bouquet and id_magasin=@modif_id;";
                connection.Open();
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nom_bouquet", nom);
                command.Parameters.AddWithValue("@composition_fleurs", composition);
                command.Parameters.AddWithValue("@stock_bouquet", stock);
                command.Parameters.AddWithValue("@prix_bouquet", prix);
                command.Parameters.AddWithValue("@categorie_bouquet", categorie);
                command.Parameters.AddWithValue("@id_magasin", ID);
                command.Parameters.AddWithValue("@modif_bouquet", modif_bouquet);
                command.Parameters.AddWithValue("@modif_id", modification_id);
            }
            else
            {
                MessageBox.Show("Valeurs entrées incomplètes");
                return;
            }
            command.ExecuteNonQuery();
            connection.Close();
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }
    }
}
