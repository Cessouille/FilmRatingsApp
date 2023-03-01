using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FilmRatingsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmRatingsApp.Services;
public interface IService
{
    public Task<List<Utilisateur>> GetUtilisateursAsync(string nomControlleur);
    public Task<ActionResult<Utilisateur>> GetUtilisateurByIdAsync(string nomControlleur, int id);
    public Task<ActionResult<Utilisateur>> GetUtilisateurByEmailAsync(string nomControlleur, string email);
    public Task<bool> PutUtilisateurAsync(string nomControlleur, int id, Utilisateur utilisateur);
    public Task<ActionResult<bool>> PostUtilisateurAsync(string nomControlleur, Utilisateur utilisateur);
    public Task<bool> DeleteUtilisateurAsync(string nomControlleur, int id);
}
