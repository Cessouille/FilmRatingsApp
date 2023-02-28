using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRatingsApp.Models;
public partial class Film
{
    public int FilmId { get; set; }

    public string Titre { get; set; }

    public string? Resume { get; set; }

    public DateTime? DateSortie { get; set; }

    public decimal? Duree { get; set; }

    public string? Genre { get; set; }

    public ICollection<Notation>? NotesFilm { get; set; }
}
