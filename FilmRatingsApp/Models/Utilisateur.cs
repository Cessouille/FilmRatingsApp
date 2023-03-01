using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRatingsApp.Models;
public partial class Utilisateur
{
    public Utilisateur()
    { }
    public Utilisateur(int utilisateurId, string? nom, string? prenom, string? mobile, string? mail, string? pwd, string? rue, string? codePostal, string? ville, string? pays, float? latitude, float? longitude, DateTime dateCreation, ICollection<Notation>? notesUtilisateur)
    {
        UtilisateurId = utilisateurId;
        Nom = nom;
        Prenom = prenom;
        Mobile = mobile;
        Mail = mail;
        Pwd = pwd;
        Rue = rue;
        CodePostal = codePostal;
        Ville = ville;
        Pays = pays;
        Latitude = latitude;
        Longitude = longitude;
        DateCreation = dateCreation;
        NotesUtilisateur = notesUtilisateur;
    }

    public int UtilisateurId { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Mobile { get; set; }

    public string? Mail { get; set; }

    public string? Pwd { get; set; }

    public string? Rue { get; set; }

    public string? CodePostal { get; set; }

    public string? Ville { get; set; }

    public string? Pays { get; set; }
  
    public float? Latitude { get; set; }

    public float? Longitude { get; set; }

    public DateTime DateCreation { get; set; }

    public ICollection<Notation>? NotesUtilisateur { get; set; }
}
