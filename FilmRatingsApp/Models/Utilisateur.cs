using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRatingsApp.Models;
public partial class Utilisateur
{
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

    public override bool Equals(object? obj) => obj is Utilisateur utilisateur && UtilisateurId == utilisateur.UtilisateurId && Nom == utilisateur.Nom && Prenom == utilisateur.Prenom && Mobile == utilisateur.Mobile && Mail == utilisateur.Mail && Pwd == utilisateur.Pwd && Rue == utilisateur.Rue && CodePostal == utilisateur.CodePostal && Ville == utilisateur.Ville && Pays == utilisateur.Pays && Latitude == utilisateur.Latitude && Longitude == utilisateur.Longitude && DateCreation == utilisateur.DateCreation && EqualityComparer<ICollection<Notation>?>.Default.Equals(NotesUtilisateur, utilisateur.NotesUtilisateur);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(UtilisateurId);
        hash.Add(Nom);
        hash.Add(Prenom);
        hash.Add(Mobile);
        hash.Add(Mail);
        hash.Add(Pwd);
        hash.Add(Rue);
        hash.Add(CodePostal);
        hash.Add(Ville);
        hash.Add(Pays);
        hash.Add(Latitude);
        hash.Add(Longitude);
        hash.Add(DateCreation);
        hash.Add(NotesUtilisateur);
        return hash.ToHashCode();
    }
}
