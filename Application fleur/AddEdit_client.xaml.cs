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
            if (!string.IsNullOrEmpty(nom.Text) && !string.IsNullOrEmpty(prenom.Text) && !string.IsNullOrEmpty(Email.Text) && !string.IsNullOrEmpty(carte_de_crédit.Text) && !string.IsNullOrEmpty(mot_de_passe.Password) && !string.IsNullOrEmpty(num_telephone.Text) && !string.IsNullOrEmpty(adresse.Text))
            {
                nom_client = nom.Text;
                prenom_client = prenom.Text;
                courriel_client = Email.Text;
                carte_de_credit_client = carte_de_crédit.Text;
                mdp_client = mot_de_passe.Password;
                num_tel_client = num_telephone.Text;
                adresse_client = adresse.Text;

                // Vérifie si l'email existe déjà dans la base de données
                connection.Open();
                MySqlCommand checkEmailCmd = new MySqlCommand("SELECT COUNT(*) FROM client WHERE courriel = @courriel_client", connection);
                checkEmailCmd.Parameters.AddWithValue("@courriel_client", courriel_client);
                int count = Convert.ToInt32(checkEmailCmd.ExecuteScalar());
                connection.Close();

                if (courriel_client=="bozo" || courriel_client=="root")
                {
                    MessageBox.Show("Petit filou, n'essaye pas d'usurper mon identité");
                    return;
                }
                if (count > 0)
                {
                    MessageBox.Show("Cet email est déjà pris veuillez en sélectionner un autre.");
                    return;
                }

                // Ajoute le client dans la base de données
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO client (courriel, nom, prenom, num_tel, mdp, adresse_facturation, carte_credit, statut_fidelite) VALUES (@courriel_client,@nom_client,@prenom_client,@num_tel_client,@mdp_client,@adresse_client,@carte_de_credit_client,@statut_fidelite)";
                command.Parameters.AddWithValue("@statut_fidelite", null);
                command.Parameters.AddWithValue("@nom_client", nom_client);
                command.Parameters.AddWithValue("@prenom_client", prenom_client);
                command.Parameters.AddWithValue("@courriel_client", courriel_client);
                command.Parameters.AddWithValue("@carte_de_credit_client", carte_de_credit_client);
                command.Parameters.AddWithValue("@mdp_client", mdp_client);
                command.Parameters.AddWithValue("@num_tel_client", num_tel_client);
                command.Parameters.AddWithValue("@adresse_client", adresse_client);
                command.ExecuteNonQuery();
                connection.Close();
                Window activeWindow = Window.GetWindow(this);
                activeWindow.Close();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
            }

        }

        private void ButtonAnnuler(object sender, RoutedEventArgs e)
        {
            Window activeWindow = Window.GetWindow(this);
            activeWindow.Close();
        }
    }
}
