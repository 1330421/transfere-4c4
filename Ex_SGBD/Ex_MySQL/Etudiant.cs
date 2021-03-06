using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Collections.ObjectModel;

// Bibliothèque externe pour la gestion des données des étudiants
//using Newtonsoft.Json;


namespace Ex_DataGrid
{
    public class Etudiant : INotifyPropertyChanged
    {
        //private const string NOM_FICHIER = "fEtudiants.json";

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private string matricule;
        public string Matricule
        {
            get
            {
                return matricule;
            }
            set
            {
                if (this.matricule != value)
                {
                    this.matricule = value;
                    this.NotifyPropertyChanged("Matricule");
                }
            }
        }

        private string prenom;
        public string Prenom
        {
            get
            {
                return prenom;
            }
            set
            {
                if (this.prenom != value)
                {
                    this.prenom = value;
                    this.NotifyPropertyChanged("Prenom");
                }
            }
        }

        private string nom;
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                if (this.nom != value)
                {
                    this.nom = value;
                    this.NotifyPropertyChanged("Nom");
                }
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    this.NotifyPropertyChanged("Email");
                }
            }
        }

        //public string Prenom { get; set; }
        //public string Nom { get; set; }
        //public string Email { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //public static void ChargerFichier()
        //{
        //    StreamReader fichierEtudiants;
        //    string json;

        //    fichierEtudiants = new StreamReader(File.OpenRead(NOM_FICHIER));

        //    json = fichierEtudiants.ReadLine();

        //    fichierEtudiants.Close();

        //    UCGestionEtudiants.etudiants = JsonConvert.DeserializeObject<ObservableCollection<Etudiant>>(json);
        //}
    }
}
