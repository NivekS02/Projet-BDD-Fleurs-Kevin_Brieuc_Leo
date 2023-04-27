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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;



namespace Projet_BDD_Fleurs
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string email;
        private string password;
        public static MySqlConnection connection;
        private int id_client;
        private int nb_tt_commande;
        private float prix_produit;
        private float prix_bouquet;
        private int nb_bouquet;
        private string statut_fidelite;
        private int nb_client;
        public MainWindow()
        {

            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=Projet_fleurs;UID=root;PASSWORD=root;";
            connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command1 = new MySqlCommand("SELECT AVG(prix_bouquet) FROM bouquet", connection);
            double prixMoyen = (double)command1.ExecuteScalar();
            PrixMoyenBouquet.Text = prixMoyen.ToString("C2");

            /* Meilleur client du mois
            MySqlCommand command2 = new MySqlCommand("SELECT TOP 1 Client, SUM(Prix) as TotalPrix FROM Commandes WHERE MONTH(Date) = MONTH(GETDATE()) GROUP BY Client ORDER BY TotalPrix DESC", connection);
            MySqlDataReader reader2 = command2.ExecuteReader();
            if (reader2.Read())
            {
                string nomClient = reader2.GetString(0);
                double totalPrix = reader2.GetDouble(1);
                MeilleurClientMois.Text = nomClient + " (" + totalPrix.ToString("C2") + ")";
            }
            reader2.Close();

            // Meilleur client de l'année
            MySqlCommand command3 = new MySqlCommand("SELECT TOP 1 Client, SUM(Prix) as TotalPrix FROM Commandes WHERE YEAR(Date) = YEAR(GETDATE()) GROUP BY Client ORDER BY TotalPrix DESC", connection);
            MySqlDataReader reader3 = command3.ExecuteReader();
            if (reader3.Read())
            {
                string nomClient = reader3.GetString(0);
                double totalPrix = reader3.GetDouble(1);
                MeilleurClientAnnee.Text = nomClient + " (" + totalPrix.ToString("C2") + ")";
            }
            reader3.Close();*/
            connection.Close();

        }
        private void ConnexionButton_Click(object sender, RoutedEventArgs e)
        {
            email = Email.Text;
            password = Mot_de_passe.Password;
            connection.Open();
            string query = "SELECT id_client from client where courriel=@courriel_client;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@courriel_client", email);
            id_client = Convert.ToInt32(command.ExecuteScalar());
            query = "SELECT count(*) FROM client WHERE courriel = @email and mdp=@password";
            command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            long compteur = (long)command.ExecuteScalar();
            if (email == "root" && password == "root")
            {
                Onglet_Client.Visibility = Visibility.Visible;
                Onglet_Magasin.Visibility = Visibility.Visible;
                Onglet_Produit.Visibility = Visibility.Visible;
                Onglet_Bouquet.Visibility = Visibility.Visible;
                Onglet_Commande.Visibility = Visibility.Visible;
                Onglet_Contenu_commande_produit.Visibility = Visibility.Visible;
                Onglet_Contenu_commande_bouquet.Visibility = Visibility.Visible;
                Add_bouquet.Visibility = Visibility.Visible;
                Add_client.Visibility = Visibility.Visible;
                Add_commande.Visibility = Visibility.Visible;
                Add_magasin.Visibility = Visibility.Visible;
                Add_produit.Visibility = Visibility.Visible;
                Del_commande.Visibility = Visibility.Visible;
                Refresh_client.Visibility = Visibility.Visible;
                Refresh_bouquet.Visibility = Visibility.Visible;
                Refresh_produit.Visibility = Visibility.Visible;
                Refresh_commande.Visibility = Visibility.Visible;
                Refresh_magasin.Visibility = Visibility.Visible;
                Onglet_Statistique.Visibility = Visibility.Visible;
                string querybis = "SELECT * FROM client";
                MySqlDataAdapter adapter = new MySqlDataAdapter(querybis, connection);
                DataTable dataTable = new DataTable("Client");
                adapter.Fill(dataTable);
                ClientDataGrid.ItemsSource = dataTable.DefaultView;
                querybis = "SELECT * FROM magasin";
                adapter = new MySqlDataAdapter(querybis, connection);
                dataTable = new DataTable("Magasin");
                adapter.Fill(dataTable);
                MagasinDataGrid.ItemsSource = dataTable.DefaultView;
                querybis = "SELECT * FROM commande";
                adapter = new MySqlDataAdapter(querybis, connection);
                dataTable = new DataTable("Commande");
                adapter.Fill(dataTable);
                CommandeDataGrid.ItemsSource = dataTable.DefaultView;
                querybis = "SELECT * FROM bouquet";
                adapter = new MySqlDataAdapter(querybis, connection);
                dataTable = new DataTable("Bouquet");
                adapter.Fill(dataTable);
                BouquetDataGrid.ItemsSource = dataTable.DefaultView;
                querybis = "SELECT * FROM produit";
                adapter = new MySqlDataAdapter(querybis, connection);
                dataTable = new DataTable("produit");
                adapter.Fill(dataTable);
                ProduitDataGrid.ItemsSource = dataTable.DefaultView;
                querybis = "SELECT * FROM contenant_produit";
                adapter = new MySqlDataAdapter(querybis, connection);
                dataTable = new DataTable("Contenant_produit");
                adapter.Fill(dataTable);
                Contenant_produitDataGrid.ItemsSource = dataTable.DefaultView;
                querybis = "SELECT * FROM contenant_bouquet";
                adapter = new MySqlDataAdapter(querybis, connection);
                dataTable = new DataTable("Contenant_bouquet");
                adapter.Fill(dataTable);
                Contenant_bouquetDataGrid.ItemsSource = dataTable.DefaultView;
            }
            else if (email == "bozo" && password == "bozo")
            {
                Onglet_Client.Visibility = Visibility.Visible;
                Onglet_Magasin.Visibility = Visibility.Visible;
                Onglet_Produit.Visibility = Visibility.Visible;
                Onglet_Bouquet.Visibility = Visibility.Visible;
                Onglet_Commande.Visibility = Visibility.Visible;
                Onglet_Contenu_commande_produit.Visibility = Visibility.Visible;
                Onglet_Contenu_commande_bouquet.Visibility = Visibility.Visible;
                Add_bouquet.Visibility = Visibility.Collapsed;
                Add_client.Visibility = Visibility.Collapsed;
                Add_commande.Visibility = Visibility.Collapsed;
                Add_magasin.Visibility = Visibility.Collapsed;
                Add_produit.Visibility = Visibility.Collapsed;
                Del_commande.Visibility = Visibility.Collapsed;
                Refresh_client.Visibility = Visibility.Visible;
                Refresh_bouquet.Visibility = Visibility.Visible;
                Refresh_produit.Visibility = Visibility.Visible;
                Refresh_commande.Visibility = Visibility.Visible;
                Refresh_magasin.Visibility = Visibility.Visible;
                Onglet_Statistique.Visibility = Visibility.Visible;
                string querybis = "SELECT * FROM client";
                MySqlDataAdapter adapter = new MySqlDataAdapter(querybis, connection);
                DataTable dataTable = new DataTable("Client");
                adapter.Fill(dataTable);
                ClientDataGrid.ItemsSource = dataTable.DefaultView;
                querybis = "SELECT * FROM magasin";
                adapter = new MySqlDataAdapter(querybis, connection);
                dataTable = new DataTable("Magasin");
                adapter.Fill(dataTable);
                MagasinDataGrid.ItemsSource = dataTable.DefaultView;
                querybis = "SELECT * FROM commande";
                adapter = new MySqlDataAdapter(querybis, connection);
                dataTable = new DataTable("Commande");
                adapter.Fill(dataTable);
                CommandeDataGrid.ItemsSource = dataTable.DefaultView;
                querybis = "SELECT * FROM bouquet";
                adapter = new MySqlDataAdapter(querybis, connection);
                dataTable = new DataTable("Bouquet");
                adapter.Fill(dataTable);
                BouquetDataGrid.ItemsSource = dataTable.DefaultView;
                querybis = "SELECT * FROM produit";
                adapter = new MySqlDataAdapter(querybis, connection);
                dataTable = new DataTable("produit");
                adapter.Fill(dataTable);
                ProduitDataGrid.ItemsSource = dataTable.DefaultView;
                querybis = "SELECT * FROM contenant_produit";
                adapter = new MySqlDataAdapter(querybis, connection);
                dataTable = new DataTable("Contenant_produit");
                adapter.Fill(dataTable);
                Contenant_produitDataGrid.ItemsSource = dataTable.DefaultView;
                querybis = "SELECT * FROM contenant_bouquet";
                adapter = new MySqlDataAdapter(querybis, connection);
                dataTable = new DataTable("Contenant_bouquet");
                adapter.Fill(dataTable);
                Contenant_bouquetDataGrid.ItemsSource = dataTable.DefaultView;
            }
            else if (compteur > 0)
            {
                Onglet_Client.Visibility = Visibility.Visible;
                Onglet_Magasin.Visibility = Visibility.Visible;
                Onglet_Produit.Visibility = Visibility.Visible;
                Onglet_Bouquet.Visibility = Visibility.Visible;
                Onglet_Commande.Visibility = Visibility.Visible;
                Onglet_Contenu_commande_produit.Visibility = Visibility.Visible;
                Onglet_Contenu_commande_bouquet.Visibility = Visibility.Visible;
                Add_bouquet.Visibility = Visibility.Collapsed;
                Add_client.Visibility = Visibility.Collapsed;
                Add_commande.Visibility = Visibility.Visible;
                Add_magasin.Visibility = Visibility.Collapsed;
                Add_produit.Visibility = Visibility.Collapsed;
                Del_commande.Visibility = Visibility.Collapsed;
                Refresh_client.Visibility = Visibility.Visible;
                Refresh_bouquet.Visibility = Visibility.Visible;
                Refresh_produit.Visibility = Visibility.Visible;
                Refresh_commande.Visibility = Visibility.Visible;
                Refresh_magasin.Visibility = Visibility.Visible;
                Onglet_Statistique.Visibility = Visibility.Collapsed;
                MySqlCommand commandbis = new MySqlCommand();
                commandbis.Connection = connection;
                commandbis.CommandText = "SELECT * FROM client where id_client=@id_client;";
                commandbis.Parameters.AddWithValue("@id_client", id_client);
                MySqlDataAdapter adapter = new MySqlDataAdapter(commandbis);
                DataTable dataTable = new DataTable("Client");
                adapter.Fill(dataTable);
                ClientDataGrid.ItemsSource = dataTable.DefaultView;
                commandbis.Connection = connection;
                commandbis.CommandText = "SELECT * FROM magasin;";
                adapter = new MySqlDataAdapter(commandbis);
                dataTable = new DataTable("Magasin");
                adapter.Fill(dataTable);
                MagasinDataGrid.ItemsSource = dataTable.DefaultView;
                commandbis.Connection = connection;
                commandbis.CommandText = "SELECT * FROM commande where id_client=@id_client;";
                adapter = new MySqlDataAdapter(commandbis);
                dataTable = new DataTable("Commande");
                adapter.Fill(dataTable);
                CommandeDataGrid.ItemsSource = dataTable.DefaultView;
                commandbis.Connection = connection;
                commandbis.CommandText = "SELECT * FROM bouquet;";
                adapter = new MySqlDataAdapter(commandbis);
                dataTable = new DataTable("Bouquet");
                adapter.Fill(dataTable);
                BouquetDataGrid.ItemsSource = dataTable.DefaultView;
                commandbis.Connection = connection;
                commandbis.CommandText = "SELECT * FROM produit;";
                adapter = new MySqlDataAdapter(commandbis);
                dataTable = new DataTable("produit");
                adapter.Fill(dataTable);
                ProduitDataGrid.ItemsSource = dataTable.DefaultView;
                commandbis.Connection = connection;
                commandbis.CommandText = "SELECT * FROM contenant_produit NATURAL JOIN commande where commande.id_client = @id_client;";
                adapter = new MySqlDataAdapter(commandbis);
                dataTable = new DataTable("Contenant_produit");
                adapter.Fill(dataTable);
                Contenant_produitDataGrid.ItemsSource = dataTable.DefaultView;
                commandbis.Connection = connection;
                commandbis.CommandText = "SELECT * FROM contenant_bouquet NATURAL JOIN commande where commande.id_client = @id_client;";
                adapter = new MySqlDataAdapter(commandbis);
                dataTable = new DataTable("Contenant_bouquet");
                adapter.Fill(dataTable);
                Contenant_bouquetDataGrid.ItemsSource = dataTable.DefaultView;
            }
            else
            {
                Onglet_Client.Visibility = Visibility.Collapsed;
                Onglet_Magasin.Visibility = Visibility.Collapsed;
                Onglet_Produit.Visibility = Visibility.Collapsed;
                Onglet_Bouquet.Visibility = Visibility.Collapsed;
                Onglet_Commande.Visibility = Visibility.Collapsed;
                Onglet_Contenu_commande_produit.Visibility = Visibility.Collapsed;
                Onglet_Contenu_commande_bouquet.Visibility = Visibility.Collapsed;
                Add_bouquet.Visibility = Visibility.Collapsed;
                Add_client.Visibility = Visibility.Collapsed;
                Add_commande.Visibility = Visibility.Collapsed;
                Add_magasin.Visibility = Visibility.Collapsed;
                Add_produit.Visibility = Visibility.Collapsed;
                Del_commande.Visibility = Visibility.Collapsed;
                Onglet_Statistique.Visibility = Visibility.Collapsed;
                MessageBox.Show("Mot de passe ou email entré incorrect");
            }
            connection.Close();

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ButtonAdd_client(object sender, RoutedEventArgs e)
        {
            var w = new AddEdit_client();
            w.Show();
        }
        private void ButtonAdd_magasin(object sender, RoutedEventArgs e)
        {
            var w = new AddEdit_magasin();
            w.Show();
        }
        private void ButtonAdd_produit(object sender, RoutedEventArgs e)
        {
            var w = new AddEdit_produit();
            w.Show();
        }
        private void ButtonAdd_bouquet(object sender, RoutedEventArgs e)
        {
            var w = new AddEdit_bouquet();
            w.Show();
        }
        private void ButtonAdd_commande(object sender, RoutedEventArgs e)
        {
            var w = new AddEdit_commande();
            w.Show();
        }

        private void ButtonDel_commande(object sender, RoutedEventArgs e)
        {
            var w = new Del_commande();
            w.Show();
        }

        private void Signup_Button_Click(object sender, RoutedEventArgs e)
        {
            var w = new AddEdit_client();
            w.Show();
        }

        private void RefreshButton_client(object sender, RoutedEventArgs e)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            connection.Open();
            if (email!="bozo" && email != "root")
            {
                command.CommandText = "SELECT * FROM client where id_client=@id_client;";
                command.Parameters.AddWithValue("@id_client", id_client);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable("Client");
                adapter.Fill(dataTable);
                ClientDataGrid.ItemsSource = dataTable.DefaultView;
            }
            else
            {
                string query = "SELECT * FROM client";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable("Client");
                adapter.Fill(dataTable);
                ClientDataGrid.ItemsSource = dataTable.DefaultView;
            }
            command.CommandText = "SELECT count(*) from client;";
            nb_client = Convert.ToInt32(command.ExecuteScalar());
            for (int i = 1; i <= nb_client; i++)
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT SUM(cb.quantite_bouquet) AS nombre_bouquets_commandes FROM contenant_bouquet cb INNER JOIN commande c ON cb.num_commande = c.num_commande INNER JOIN client cl ON c.id_client = cl.id_client WHERE cl.id_client =@id_client AND c.date_commande >= DATE_SUB(NOW(), INTERVAL 1 MONTH);";
                command.Parameters.AddWithValue("@id_client", i);
                object result = command.ExecuteScalar();
                nb_bouquet = Convert.IsDBNull(result) ? 0 : Convert.ToInt32(result);

                if (nb_bouquet >= 1 && nb_bouquet < 5)
                {
                    statut_fidelite = "BRONZE";
                }
                else if (nb_bouquet >= 5)
                {
                    statut_fidelite = "OR";
                }
                else
                {
                    statut_fidelite = null;
                }
                command.Parameters.Clear();
                command.CommandText = "UPDATE client set statut_fidelite=@statut_fidelite where id_client=@id_client;";
                command.Parameters.AddWithValue("@statut_fidelite", statut_fidelite);
                command.Parameters.AddWithValue("@id_client", i);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        private void RefreshButton_magasin(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM magasin";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable("Magasin");
            adapter.Fill(dataTable);
            MagasinDataGrid.ItemsSource = dataTable.DefaultView;
        }
        private void RefreshButton_produit(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM produit";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable("Produit");
            adapter.Fill(dataTable);
            ProduitDataGrid.ItemsSource = dataTable.DefaultView;
        }
        private void RefreshButton_bouquet(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM bouquet";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable("Bouquet");
            adapter.Fill(dataTable);
            BouquetDataGrid.ItemsSource = dataTable.DefaultView;
        }
        private void RefreshButton_commande(object sender, RoutedEventArgs e)
        {
            MySqlCommand command = new MySqlCommand();
            connection.Open();
            command.Connection = connection;
            if (email!="bozo" && email != "root")
            {      
                DataTable dataTable = new DataTable("Commande");
                command.CommandText = "SELECT * FROM commande where id_client=@id_client;";
                command.Parameters.AddWithValue("@id_client", id_client);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);
                CommandeDataGrid.ItemsSource = dataTable.DefaultView;
                command.CommandText = "SELECT * FROM contenant_produit NATURAL JOIN commande where commande.id_client = @id_client;";
                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable("Contenant_produit");
                adapter.Fill(dataTable);
                Contenant_produitDataGrid.ItemsSource = dataTable.DefaultView;
                command.CommandText = "SELECT * FROM contenant_bouquet NATURAL JOIN commande where commande.id_client = @id_client;";
                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable("Contenant_bouquet");
                adapter.Fill(dataTable);
                Contenant_bouquetDataGrid.ItemsSource = dataTable.DefaultView;
                command.CommandText = ("SELECT count(*) from commande;");
                nb_tt_commande = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT date_livraison from commande where num_commande=@num_commande;";
            }
            else
            {
                string query = "SELECT * FROM commande";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable("Commande");
                adapter.Fill(dataTable);
                CommandeDataGrid.ItemsSource = dataTable.DefaultView;
                query = "SELECT * FROM contenant_produit";
                adapter = new MySqlDataAdapter(query, connection);
                dataTable = new DataTable("Contenant_produit");
                adapter.Fill(dataTable);
                Contenant_produitDataGrid.ItemsSource = dataTable.DefaultView;
                query = "SELECT * FROM contenant_bouquet";
                adapter = new MySqlDataAdapter(query, connection);
                dataTable = new DataTable("Contenant_bouquet");
                adapter.Fill(dataTable);
                Contenant_bouquetDataGrid.ItemsSource = dataTable.DefaultView;
            }       
            command.CommandText ="SELECT count(*) from commande;";
            nb_tt_commande = Convert.ToInt32(command.ExecuteScalar());
            command.CommandText = "SELECT date_livraison from commande where num_commande=@num_commande;";
            for (int i = 1; i <= nb_tt_commande; i++)
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@num_commande", i);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    DateTime date_livraison = (DateTime)result;
                    if (date_livraison < DateTime.Now)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@num_commande", i);
                        command.CommandText = "UPDATE commande SET etat_commande = 'CL' WHERE num_commande = @num_commande";//à revoir
                        command.ExecuteNonQuery();
                    }
                }
            }
            for (int i = 1; i <= nb_tt_commande; i++)
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@num_commande", i);
                command.CommandText = "SELECT  SUM((cb.quantite_bouquet * b.prix_bouquet)) FROM commande c LEFT JOIN contenant_bouquet cb ON c.num_commande = cb.num_commande LEFT JOIN bouquet b ON cb.nom_bouquet = b.nom_bouquet WHERE c.num_commande = @num_commande; ";
                prix_bouquet = 0;
                object result = command.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    prix_bouquet = Convert.ToSingle(result);
                }
                command.CommandText = "SELECT id_client from commande where num_commande=@num_commande;";
                id_client = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "SELECT statut_fidelite from client where id_client=@id_client;";
                command.Parameters.AddWithValue("@id_client", id_client);
                result = command.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    statut_fidelite = (string)result;
                    if (statut_fidelite == "OR")
                    {
                        prix_bouquet = Convert.ToSingle(prix_bouquet * 0.85);
                    }
                    if (statut_fidelite == "BRONZE")
                    {
                        prix_bouquet = Convert.ToSingle(prix_bouquet * 0.95);
                    }
                }
                command.CommandText = "SELECT  SUM(cp.quantite_produit * p.prix_produit) FROM commande c LEFT JOIN contenant_produit cp ON c.num_commande = cp.num_commande LEFT JOIN produit p ON cp.nom_produit = p.nom_produit WHERE c.num_commande = @num_commande;";
                prix_produit = 0;
                result = command.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    prix_produit = Convert.ToSingle(result);
                }
                command.CommandText = "UPDATE commande set prix_total=@prix_total where num_commande=@num_commande;";
                command.Parameters.AddWithValue("@prix_total", prix_produit+prix_bouquet);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
