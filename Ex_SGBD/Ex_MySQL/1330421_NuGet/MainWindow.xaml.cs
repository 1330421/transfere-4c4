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
using System.IO;

using Newtonsoft.Json;

namespace Ex_DataGrid
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserControl ContenuEcran { get; set; }

        public UserControl ContenuColonne2 { get; set; }

        public UCGestionEtudiants GestionEtudiant = new UCGestionEtudiants();

        public UCSmiley Smile = new UCSmiley();
        public MainWindow()
        {
            InitializeComponent();

            ContenuEcran = GestionEtudiant;

            Grid.SetRow(ContenuEcran, 0);
            Grid.SetColumn(ContenuEcran, 0);

            gPrincipal.Children.Add(ContenuEcran);



            ContenuColonne2 = Smile;

            Grid.SetRow(ContenuColonne2, 0);
            Grid.SetColumn(ContenuColonne2, 1);

            gPrincipal.Children.Add(ContenuColonne2);
        }

        public static void ReecrireFichier()
        {
            string json = JsonConvert.SerializeObject(UCGestionEtudiants.etudiants);

            System.IO.File.WriteAllText("fEtudiants.json", json);
        }
    }
}
