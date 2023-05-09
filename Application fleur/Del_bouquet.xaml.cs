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
    /// Logique d'interaction pour Del_bouquet.xaml
    /// </summary>
    public partial class Del_bouquet : Window
    {
        private string nom;
        private int ID;
        public static MySqlConnection connection;
        public Del_bouquet()
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

        private void ButtonDel_bouquet(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(nom_bouquet.Text) && !string.IsNullOrEmpty(nom_bouquet.Text))
            {
                nom = nom_bouquet.Text;
                ID = Convert.ToInt32(id_magasin.Text);
                connection.Open();
                string query = "DELETE FROM contenant_bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nom_bouquet", nom);
                command.Parameters.AddWithValue("@id_magasin", ID);
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM bouquet where nom_bouquet=@nom_bouquet and id_magasin=@id_magasin;";
                command.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Valeur entrée incorrect.");
                return;
            }
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }
    }
}
