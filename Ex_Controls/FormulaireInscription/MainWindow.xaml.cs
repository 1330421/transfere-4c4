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

namespace FormulaireInscription
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TxtNom_Focus(object sender, RoutedEventArgs e)
        {
            txtNom.Focus();
        }

        private void TxtPrenom_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNom.Text == "")
            {
                MessageBox.Show("Veuillez saisir votre nom", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                txtNom.Focus();
            }
        }

        private void TxtEmail_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Text = "";
            txtEmail.Foreground = Brushes.Blue;
        }

        private void TxtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!ValidateEmail(txtEmail.Text))
            {
                // Message d'erreur
                MessageBox.Show("L'adresse courriel doit respecter le format \"exemple@exemple.ex\"", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateEmail(string email)
        {
            //Validation de l'adresse courriel (string@string.string)

            string[] splitedEmail = email.Split('@');
            if (splitedEmail.Length != 2 || splitedEmail[0].Length == 0 || splitedEmail[1].Length == 0)
                return false;

            string[] splitedEndEmail = splitedEmail[1].Split('.');
            if (splitedEndEmail.Length != 2 || splitedEndEmail[0].Length == 0 || splitedEndEmail[1].Length == 0)
                return false;

            return true;
        }

        private void BtnCopier_Click(object sender, RoutedEventArgs e)
        {
            if (lsbInit.SelectedItems.Count < 2 || lsbInit.SelectedItems.Count > 4)
                MessageBox.Show("Le nombre d'élément sélectionné doit être entre 2 et 4", "Erreur", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            else
                foreach (object item in lsbInit.SelectedItems)
                {
                    lsbFin.Items.Add(item.ToString().Split(':')[1].TrimStart());
                }
        }

        private void BtnVider_Click(object sender, RoutedEventArgs e)
        {
            lsbFin.Items.Clear();
        }

        private void BtnValider_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder res = new StringBuilder();

            res.AppendLine("Prénom et nom : " + txtPrenom.Text + " " + txtNom.Text);
            res.AppendLine("Date de naissance : " + cld1.SelectedDate);
            res.Append("Adresse courriel : " + txtEmail.Text).AppendLine();

            if (cboRegion.SelectedIndex != -1)
                res.Append("Région : " + cboRegion.SelectedItem.ToString().Split(':')[1]).AppendLine();

            res.Append("Satut professionnel : ");
            if (chk1.IsChecked == true) res.Append(" " + chk1.Content);
            if (chk2.IsChecked == true) res.Append(" " + chk2.Content);
            if (chk3.IsChecked == true) res.Append(" " + chk3.Content);
            res.AppendLine();

            res.Append("État matrimonial : ");
            if (rdb1.IsChecked == true) res.Append(" " + rdb1.Content);
            if (rdb2.IsChecked == true) res.Append(" " + rdb2.Content);
            if (rdb3.IsChecked == true) res.Append(" " + rdb3.Content);
            res.AppendLine();

            MessageBox.Show(res.ToString(), "Validation des données");
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtEmail.Text = "";

            cboRegion.SelectedIndex = -1;

            chk1.IsChecked = false;
            chk2.IsChecked = false;
            chk3.IsChecked = false;

            rdb1.IsChecked = false;
            rdb2.IsChecked = false;
            rdb3.IsChecked = false;

            lsbInit.SelectedItems.Clear();
            lsbFin.Items.Clear();
        }
    }
}
