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


        public MainWindow()
        {

            InitializeComponent();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=Projet_fleurs;UID=root;PASSWORD=root;";
            connection = new MySqlConnection(connectionString);

        }
        private void ConnexionButton_Click(object sender, RoutedEventArgs e)
        {
            email = Email.Text;
            password = Mot_de_passe.Password;
            connection.Open();
            string query = "SELECT count(*) FROM client WHERE courriel = @email and mdp=@password";
            MySqlCommand command = new MySqlCommand(query, connection);
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
                Refresh_client.Visibility = Visibility.Visible;
                Refresh_bouquet.Visibility = Visibility.Visible;
                Refresh_produit.Visibility = Visibility.Visible;
                Refresh_commande.Visibility = Visibility.Visible;
                Refresh_magasin.Visibility = Visibility.Visible;
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
            string query = "SELECT * FROM client";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable("Client");
            adapter.Fill(dataTable);
            ClientDataGrid.ItemsSource = dataTable.DefaultView;
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
    }
}
