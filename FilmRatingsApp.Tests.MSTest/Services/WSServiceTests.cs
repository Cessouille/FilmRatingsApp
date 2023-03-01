using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmRatingsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmRatingsApp.Models;

namespace FilmRatingsApp.Services.Tests;

[TestClass()]
public class WSServiceTests
{
    private static WSService service;

    public WSServiceTests()
    {
        service = new WSService("https://localhost:7275");
    }

    [TestMethod()]
    public void GetUtilisateursAsyncTest_Ok()
    {
        //Arrange
        List<Utilisateur> lesUtilisateurs = new List<Utilisateur>();
        //Act
        var result = service.GetUtilisateursAsync("api/Utilisateurs").Result.Where(s => s.UtilisateurId <= 3).ToList();
        lesUtilisateurs.Add(new Utilisateur
        {
            UtilisateurId = 1,
            Nom = "Calida",
            Prenom = "Lilley",
            Mobile = "0653930778",
            Mail = "clilleymd@last.fm",
            Pwd = "Toto12345678!",
            Rue = "Impasse des bergeronnettes",
            CodePostal = "74200",
            Ville = "Allinges",
            Pays = "France",
            Latitude = 46.344795F,
            Longitude = 6.4885845F
        });

        lesUtilisateurs.Add(new Utilisateur
        {
            UtilisateurId = 2,
            Nom = "Gwendolin",
            Prenom = "Dominguez",
            Mobile = "0724970555",
            Mail = "gdominguez0@washingtonpost.com",
            Pwd = "Toto12345678!",
            Rue = "Chemin de gom",
            CodePostal = "73420",
            Ville = "Voglans",
            Pays = "France",
            Latitude = 45.622154F,
            Longitude = 5.8853216F
        });

        lesUtilisateurs.Add(new Utilisateur
        {
            UtilisateurId = 3,
            Nom = "Randolph",
            Prenom = "Richings",
            Mobile = "0630271158",
            Mail = "rrichings1@naver.com",
            Pwd = "Toto12345678!",
            Rue = "Route des charmottes d'en bas",
            CodePostal = "74890",
            Ville = "Bons-en-Chablais",
            Pays = "France",
            Latitude = 46.25732F,
            Longitude = 6.367676F
        });
        //Assert
        Assert.IsInstanceOfType(result, typeof(IEnumerable<Utilisateur>), "Pas un IEnumerable");
        CollectionAssert.AreEqual(lesUtilisateurs, result, "Pas la même liste d'utilisateurs");
    }

    /*[TestMethod()]
    public void GetUtilisateursByIdAsyncTest()
    {


        Utilisateur Utilisateur = new Utilisateur(1, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");


        var getUtilisateur = service.GetUtilisateurByIdAsync(1).Result;

        Assert.AreEqual(Utilisateur, getUtilisateur);

        Assert.IsNotNull(getUtilisateur);
    }


    [TestMethod()]
    public void PostUtilisateursAsyncTest()
    {
        Utilisateur Utilisateur = new Utilisateur(1234, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");

        var getUtilisateur = service.PostUtilisateurAsync(Utilisateur).Result;

        Assert.IsTrue(getUtilisateur);

        _ = service.DeleteUtilisateurAsync(Utilisateur).Result;
    }

    [TestMethod()]
    public void DeleteUtilisateursAsyncTest()
    {
        Utilisateur Utilisateur = new Utilisateur(1235, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");

        _ = service.PostUtilisateurAsync(Utilisateur).Result;

        var getUtilisateur = service.DeleteUtilisateurAsync(Utilisateur).Result;

        Assert.IsTrue(getUtilisateur);
    }

    [TestMethod()]
    public void PutUtilisateursAsyncTest()
    {
        Utilisateur Utilisateur = new Utilisateur(1236, "Scrum", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");

        _ = service.PostUtilisateurAsync(Utilisateur).Result;

        Utilisateur UtilisateurModif = new Utilisateur(1236, "Scrummy", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");

        var getUtilisateur = service.PutUtilisateurAsync(UtilisateurModif).Result;

        _ = service.DeleteUtilisateurAsync(Utilisateur).Result;

        Assert.IsTrue(getUtilisateur);
    }*/
}