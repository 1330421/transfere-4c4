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

namespace Ex_DataGrid
{
    /// <summary>
    /// Logique d'interaction pour UCAjoutEtudiant.xaml
    /// </summary>
    public partial class UCAjoutEtudiant : UserControl
    {
        public UCAjoutEtudiant()
        {
            InitializeComponent();
        }

        private void Click_Valider(object sender, RoutedEventArgs e)
        {
            Etudiant etu = new Etudiant
            {
                Matricule = tbMatricule.Text,
                Prenom = tbPrenom.Text,
                Nom = tbNom.Text,
                Email = tbEmail.Text
            };

            UCGestionEtudiants.etudiants.Add(etu);

            // Réécriture du fichier de données
            //MainWindow.ReecrireFichier();

            // Appel de la méthode qui permet d'indérer les données dans la base
            IsererNouvEtudBD(etu.Matricule, etu.Nom, etu.Prenom, etu.Email);

            MainWindow mw = (MainWindow)Application.Current.MainWindow;
            mw.gPrincipal.Children.Remove(mw.ContenuEcran);
            mw.ContenuEcran = mw.GestionEtudiant;
            Grid.SetRow(mw.ContenuEcran, 1);
            mw.gPrincipal.Children.Add(mw.ContenuEcran);

            tbMatricule.Text = "";
            tbPrenom.Text = "";
            tbNom.Text = "";
            tbEmail.Text = "";
        }

        public void IsererNouvEtudBD(string matricule, string nom, string prenom, string email)
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=gestionetudiants;UID=root;PASSWORD=;");

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO etudiant (Matricule, Prenom, Nom, Email) " +
                    "Values " +
                    "( '" + matricule + "'" +
                    ", '" + prenom + "'" +
                    ", '" + nom + "'" +
                    ", '" + email + "'" +
                    ")", conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Les données ont été inséré avec succès");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
