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
using System.Collections.ObjectModel;

// Manipulation d'une base de données MySQL
using System.Data;
using MySql.Data.MySqlClient;


namespace Ex_DataGrid
{
    /// <summary>
    /// Logique d'interaction pour UCGestionEtudiants.xaml
    /// </summary>
    public partial class UCGestionEtudiants : UserControl
    {
        public static ObservableCollection<Etudiant> etudiants = new ObservableCollection<Etudiant>();

        UCAjoutEtudiant EcranAjoutEtudiant = new UCAjoutEtudiant();

        public UCGestionEtudiants()
        {
            InitializeComponent();

            {
                //etudiants.Add(new Etudiant()
                //{
                //    Matricule = "1330421",
                //    Prenom = "Kevin",
                //    Nom = "St-Pierre",
                //    Email = "1330421@cstj.qc.ca"
                //});
                //etudiants.Add(new Etudiant()
                //{
                //    Matricule = "2033444",
                //    Prenom = "Bob",
                //    Nom = "Lachance",
                //    Email = "2033444@cstj.qc.ca"
                //});
                //etudiants.Add(new Etudiant()
                //{
                //    Matricule = "2103343",
                //    Prenom = "Sonia",
                //    Nom = "Demers",
                //    Email = "2103343@cstj.qc.ca"
                //});
            }

            // Appel de la méthode que charge le contenu du fichier de données
            //Etudiant.ChargerFichier();

            dgEtudiant.ItemsSource = etudiants;

            DataContext = this;
            ConnecterBD();
            MessageBox.Show("Connexion à la base de données");
        }

        public void ConnecterBD()
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=gestionetudiants;UID=root;PASSWORD=;");

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM etudiant", conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet(); // using System.Data

                string table = "etudiant";

                adp.Fill(ds, table);

                var dt = ds.Tables[table];

                //var etudiantsList = new ObservableCollection<Etudiant>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var etu = new Etudiant
                    {
                        Matricule = dt.Rows[i]["Matricule"].ToString(),
                        Prenom = dt.Rows[i]["Prenom"].ToString(),
                        Nom = dt.Rows[i]["Nom"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString()
                    };

                    //etudiantsList.Add(etu);
                    etudiants.Add(etu);
                }

                //etudiants = etudiantsList;

                dgEtudiant.ItemsSource = etudiants;
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

        public string mat, nom, pre, ema;

        private void LigneDG_dblClick(object sender, MouseButtonEventArgs e)
        {
            mat = (dgEtudiant.SelectedItem as Etudiant).Matricule;
            nom = (dgEtudiant.SelectedItem as Etudiant).Nom;
            pre = (dgEtudiant.SelectedItem as Etudiant).Prenom;
            ema = (dgEtudiant.SelectedItem as Etudiant).Email;
        }

        private void BtnAjouterEtudiant_Click(object sender, RoutedEventArgs e)
        {
            //etudiants.Add(new Etudiant()
            //{
            //    Matricule = "2093243",
            //    Prenom = "Gino",
            //    Nom = "Lapointe",
            //    Email = "2093243@cstj.qc.ca"
            //});

            {
                //InputDialog inputdialog0 = new InputDialog("Ajout d'un étudiant", "veuillez entrer le matricule : ", "0000000");
                //string matriculeAj = "";
                //if (inputdialog0.ShowDialog() == true)
                //{
                //    matriculeAj = inputdialog0.Reponse;
                //}

                //InputDialog inputdialog1 = new InputDialog("Ajout d'un étudiant", "veuillez entrer le prénom : ", "Simon");
                //string prenomAj = "";
                //if (inputdialog1.ShowDialog() == true)
                //{
                //    prenomAj = inputdialog1.Reponse;
                //}

                //InputDialog inputdialog2 = new InputDialog("Ajout d'un étudiant", "veuillez entrer le nom : ", "St-Pierre");
                //string nomAj = "";
                //if (inputdialog2.ShowDialog() == true)
                //{
                //    nomAj = inputdialog2.Reponse;
                //}

                //InputDialog inputdialog3 = new InputDialog("Ajout d'un étudiant", "veuillez entrer l'adresse courriel : ", "0000000@cstj.qc.ca");
                //string emailAj = "";
                //if (inputdialog3.ShowDialog() == true)
                //{
                //    emailAj = inputdialog3.Reponse;
                //}

                //etudiants.Add(new Etudiant()
                //{
                //    Matricule = matriculeAj,
                //    Prenom = prenomAj,
                //    Nom = nomAj,
                //    Email = emailAj
                //});
            }

            MainWindow mw = (MainWindow)Application.Current.MainWindow;

            mw.gPrincipal.Children.Remove(mw.ContenuEcran);

            // ici, afficher le UserControl UCAjoutEtudiant dans MainWindow
            mw.ContenuEcran = EcranAjoutEtudiant;
            Grid.SetRow(mw.ContenuEcran, 1);

            mw.gPrincipal.Children.Add(mw.ContenuEcran);
        }

        private void BtnModifierEtudiant_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Matricule : " + (dgEtudiant.SelectedItem as Etudiant).Matricule
            //    + "\nPrénom : " + (dgEtudiant.SelectedItem as Etudiant).Prenom
            //    + "\nNom : " + (dgEtudiant.SelectedItem as Etudiant).Nom
            //    + "\nEmail : " + (dgEtudiant.SelectedItem as Etudiant).Email);

            string valMat = (dgEtudiant.SelectedItem as Etudiant).Matricule;
            string valNom = (dgEtudiant.SelectedItem as Etudiant).Nom;
            string valPre = (dgEtudiant.SelectedItem as Etudiant).Prenom;
            string valEma = (dgEtudiant.SelectedItem as Etudiant).Email;

            if (mat != valMat)
            {
                MessageBox.Show("Le matricul ne peut être modifié");

                (dgEtudiant.SelectedItem as Etudiant).Matricule = mat;
                (dgEtudiant.SelectedItem as Etudiant).Nom = nom;
                (dgEtudiant.SelectedItem as Etudiant).Prenom = pre;
                (dgEtudiant.SelectedItem as Etudiant).Email = ema;
            }
            else
            {
                MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=gestionetudiants;UID=root;PASSWORD=;");

                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("UPDATE etudiant " +
                        "SET Nom = '" + valNom + "'" +
                        ", Prenom = '" + valPre + "'" +
                        ", Email = '" + valEma + "'" +
                        " WHERE Matricule = '" + mat + "'", conn);

                    MySqlDataReader myReader;

                    myReader = cmd.ExecuteReader();

                    MessageBox.Show("Les données ont été modifiées avec succès");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            //MainWindow.ReecrireFichier();
        }

        private void BtnSupprimerEtudiant_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(etudiants.Count.ToString());

            if (dgEtudiant.SelectedItem != null)
                etudiants.Remove(dgEtudiant.SelectedItem as Etudiant);

            //MessageBox.Show(etudiants.Count.ToString());

            //MainWindow.ReecrireFichier();
        }
    }
}
