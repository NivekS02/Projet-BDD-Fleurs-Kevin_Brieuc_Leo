﻿using System;
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
                Add_contenu_bouquet.Visibility = Visibility.Visible;
                Add_contenu_produit.Visibility = Visibility.Visible;
                Add_magasin.Visibility = Visibility.Visible;
                Add_produit.Visibility = Visibility.Visible;
                Del_bouquet.Visibility = Visibility.Visible;
                Del_client.Visibility = Visibility.Visible;
                Del_commande.Visibility = Visibility.Visible;
                Del_contenu_bouquet.Visibility = Visibility.Visible;
                Del_contenu_produit.Visibility = Visibility.Visible;
                Del_magasin.Visibility = Visibility.Visible;
                Del_produit.Visibility = Visibility.Visible;
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
                Add_contenu_bouquet.Visibility = Visibility.Collapsed;
                Add_contenu_produit.Visibility = Visibility.Collapsed;
                Add_magasin.Visibility = Visibility.Collapsed;
                Add_produit.Visibility = Visibility.Collapsed;
                Del_bouquet.Visibility = Visibility.Collapsed;
                Del_client.Visibility = Visibility.Collapsed;
                Del_commande.Visibility = Visibility.Collapsed;
                Del_contenu_bouquet.Visibility = Visibility.Collapsed;
                Del_contenu_produit.Visibility = Visibility.Collapsed;
                Del_magasin.Visibility = Visibility.Collapsed;
                Del_produit.Visibility = Visibility.Collapsed;
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
                Add_contenu_bouquet.Visibility = Visibility.Visible;
                Add_contenu_produit.Visibility = Visibility.Visible;
                Add_magasin.Visibility = Visibility.Collapsed;
                Add_produit.Visibility = Visibility.Collapsed;
                Del_bouquet.Visibility = Visibility.Collapsed;
                Del_client.Visibility = Visibility.Collapsed;
                Del_commande.Visibility = Visibility.Collapsed;
                Del_contenu_bouquet.Visibility = Visibility.Collapsed;
                Del_contenu_produit.Visibility = Visibility.Collapsed;
                Del_magasin.Visibility = Visibility.Collapsed;
                Del_produit.Visibility = Visibility.Collapsed;
            }
            else
            {
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


        private void ButtonDel_client(object sender, RoutedEventArgs e)
        {
            /*
            connection.Open();
            string query = "DELETE from client where id_client=@id_client";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_client", id_client);
            */
        }

        private void ButtonAdd_magasin(object sender, RoutedEventArgs e)
        {
            var w = new AddEdit_magasin();
            w.Show();
        }


        private void ButtonDel_magasin(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonAdd_produit(object sender, RoutedEventArgs e)
        {
            var w = new AddEdit_produit();
            w.Show();
        }

        private void ButtonDel_produit(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonAdd_bouquet(object sender, RoutedEventArgs e)
        {
            var w = new AddEdit_bouquet();
            w.Show();
        }

        private void ButtonDel_bouquet(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonAdd_commande(object sender, RoutedEventArgs e)
        {
            var w = new AddEdit_commande();
            w.Show();
        }

        private void ButtonDel_commande(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonAdd_contenuproduit(object sender, RoutedEventArgs e)
        {
            var w = new AddEdit_contenuproduit();
            w.Show();
        }

        private void ButtonDel_contenuproduit(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonAdd_contenubouquet(object sender, RoutedEventArgs e)
        {
            var w = new AddEdit_contenubouquet();
            w.Show();
        }

        private void ButtonDel_contenubouquet(object sender, RoutedEventArgs e)
        {

        }
    }
}
