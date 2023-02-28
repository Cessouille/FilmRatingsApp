using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRatingsApp.Models;
public partial class Notation
{
    public int UtilisateurId { get; set; }

    public int FilmId { get; set; }

    public int Note { get; set; }

    public Utilisateur? UtilisateurNotant { get; set; }

    public Film? FilmNote { get; set; }
}
