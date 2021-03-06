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
            UCGestionEtudiants.etudiants.Add(new Etudiant()
            {
                Matricule = tbMatricule.Text,
                Prenom = tbPrenom.Text,
                Nom = tbNom.Text,
                Email = tbEmail.Text
            });

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
    }
}
