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
    /// Logique d'interaction pour AddEdit_client.xaml
    /// </summary>
    public partial class AddEdit_client : Window
    {
        public static MySqlConnection connection;
        private string nom_client;
        private string prenom_client;
        private string courriel_client;
        private string carte_de_credit_client;
        private string mdp_client;
        private string num_tel_client;
        private string adresse_client;

        public AddEdit_client()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=Projet_fleurs;UID=root;PASSWORD=root;";
            connection = new MySqlConnection(connectionString);
        }

        private void ButtonValider_client(object sender, RoutedEventArgs e)
        {
            nom_client = nom.Text;
            prenom_client = prenom.Text;
            courriel_client = Email.Text;
            carte_de_credit_client = carte_de_crédit.Text;
            mdp_client = mot_de_passe.Password;
            num_tel_client = num_telephone.Text;
            adresse_client = adresse.Text;
            connection.Open();
            string query = "INSERT INTO client (courriel, nom, prenom, num_tel, mdp, adresse_facturation, carte_credit, statut_fidelite) VALUES (@courriel_client,@nom_client,@prenom_client,@num_tel_client,@mdp_client,@adresse_client,@carte_de_credit_client,@statut_fidelite)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nom_client", nom_client);
            command.Parameters.AddWithValue("@prenom_client", prenom_client);
            command.Parameters.AddWithValue("@courriel_client", courriel_client);
            command.Parameters.AddWithValue("@carte_de_credit_client", carte_de_credit_client);
            command.Parameters.AddWithValue("@mdp_client", mdp_client);
            command.Parameters.AddWithValue("@num_tel_client", num_tel_client);
            command.Parameters.AddWithValue("@adresse_client", adresse_client);
            command.Parameters.AddWithValue("@statut_fidelite", DBNull.Value);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void ButtonAnnuler_client(object sender, RoutedEventArgs e)
        {

        }
    }
}
