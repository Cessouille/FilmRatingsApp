using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FilmRatingsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmRatingsApp.Services;
public class WSService : IService
{
    private HttpClient client;

    public WSService(string url)
    {
        client = new HttpClient();
        client.BaseAddress = new Uri(url); //"http://localhost:7153/"
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Utilisateur>> GetUtilisateursAsync(string nomControlleur)
    {
        try
        {
            return await client.GetFromJsonAsync<List<Utilisateur>>(nomControlleur);
        }

        catch (Exception)
        {
            return null;
        }
    }

    public async Task<ActionResult<Utilisateur>> GetUtilisateurByIdAsync(string nomControlleur, int id)
    {
        try
        {
            return await client.GetFromJsonAsync<Utilisateur>(nomControlleur + "/" + id);
        }

        catch (Exception)
        {
            return null;
        }
    }

    public async Task<ActionResult<Utilisateur>> GetUtilisateurByEmailAsync(string nomControlleur, string email)
    {
        try
        {
            return await client.GetFromJsonAsync<Utilisateur>(nomControlleur + "/" + email);
        }

        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> PutUtilisateurAsync(string nomControlleur, int id, Utilisateur utilisateur)
    {
        try
        {
            var reponse = await client.PutAsJsonAsync(nomControlleur + "/" + id, utilisateur);
            reponse.EnsureSuccessStatusCode();
            if (reponse.IsSuccessStatusCode)
                return true;
            return false;
        }

        catch (Exception)
        {
            return false;
        }
    }

    public async Task<ActionResult<bool>> PostUtilisateurAsync(string nomControlleur, Utilisateur utilisateur)
    {
        try
        {
            var reponse = await client.PostAsJsonAsync(nomControlleur, utilisateur);
            reponse.EnsureSuccessStatusCode();
            if (reponse.IsSuccessStatusCode)
                return true;
            return false;
        }

        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteUtilisateurAsync(string nomControlleur, int id)
    {
        try
        {
            var reponse = await client.DeleteAsync(nomControlleur + "/" + id);
            reponse.EnsureSuccessStatusCode();
            if (reponse.IsSuccessStatusCode)
                return true;
            return false;
        }

        catch (Exception)
        {
            return false;
        }
    }
}
