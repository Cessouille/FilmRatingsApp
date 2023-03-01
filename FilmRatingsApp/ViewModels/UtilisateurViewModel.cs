using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilmRatingsApp.Models;
using FilmRatingsApp.Services;
using Microsoft.UI.Xaml.Controls;

namespace FilmRatingsApp.ViewModels;

public class UtilisateurViewModel : ObservableObject
{
    public IRelayCommand BtnSearchUtilisateurCommand { get; }
    public IRelayCommand BtnModifyUtilisateurCommand { get; }
    public IRelayCommand BtnClearUtilisateurCommand { get; }
    public IRelayCommand BtnAddUtilisateurCommand { get; }

    public UtilisateurViewModel()
    {
        UtilisateurSearch = new Utilisateur();
        BtnSearchUtilisateurCommand = new RelayCommand(SearchUserOnAction);
        BtnModifyUtilisateurCommand = new RelayCommand(ModifyUserOnAction);
        BtnClearUtilisateurCommand = new RelayCommand(ClearUserOnAction);
        BtnAddUtilisateurCommand = new RelayCommand(AddUserOnAction);
    }

    private string searchMail;

    public string SearchMail
    {
        get { return searchMail; }
        set { searchMail = value; OnPropertyChanged(); }
    }

    private Utilisateur utilisateurSearch;

    public Utilisateur UtilisateurSearch
    {
        get { return utilisateurSearch; }
        set { utilisateurSearch = value; OnPropertyChanged(); }
    }

    public async void SearchUserOnAction()
    {
        WSService service = new WSService("https://localhost:7275");
        var result = await service.GetUtilisateurByEmailAsync("api/Utilisateurs/GetByEmail", SearchMail);
        if (result == null)
            DisplayDialog("Utilisateur non trouvé !", "Erreur");
        else
            UtilisateurSearch = result.Value;
    }

    public async void ModifyUserOnAction()
    {
        WSService service = new WSService("https://localhost:7275");
        if (String.IsNullOrEmpty(UtilisateurSearch.Mail) || String.IsNullOrEmpty(UtilisateurSearch.Pwd))
            DisplayDialog("Email et mot de passe obligatoire !", "Erreur");
        else
        {
            var result = await service.PutUtilisateurAsync("api/Utilisateurs/PutUtilisateur", UtilisateurSearch.UtilisateurId, UtilisateurSearch);
            if (result == false)
                DisplayDialog("Utilisateur non modifié !", "Erreur");
            else
                DisplayDialog("Utilisateur " + UtilisateurSearch.Nom + " modifié avec succès !", "Information");
        }
    }

    public void ClearUserOnAction()
    {
        SearchMail = "";
        UtilisateurSearch = new Utilisateur();
        DisplayDialog("Champs vidés avec succès !", "Zer gut");
    }

    public async void AddUserOnAction()
    {

        WSService service = new WSService("https://localhost:7275");
        if (String.IsNullOrEmpty(UtilisateurSearch.Mail) || String.IsNullOrEmpty(UtilisateurSearch.Pwd))
            DisplayDialog("Email et mot de passe obligatoire !", "Erreur");
        else
        {
            var result = await service.PostUtilisateurAsync("api/Utilisateurs/PostUtilisateur", UtilisateurSearch);
            if (result == false)
                DisplayDialog("Utilisateur non créé !", "Erreur");
            else
                DisplayDialog("Utilisateur " + UtilisateurSearch.Nom + " créé avec succès !", "Information");
        }
    }

    public async void DisplayDialog(string content, string title)
    {
        ContentDialog erreur = new ContentDialog()
        {
            Title = title,
            Content = content,
            CloseButtonText = "Ok"
        };

        erreur.XamlRoot = App.MainRoot.XamlRoot;
        await erreur.ShowAsync();
    }
}
