using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilmRatingsApp.Models;
using FilmRatingsApp.Services;
using Microsoft.UI.Xaml.Controls;

namespace FilmRatingsApp.ViewModels;

public class UtilisateurViewModel : ObservableObject
{
    public IRelayCommand BtnSearchUtilisateurCommand { get; }

    public UtilisateurViewModel()
    {
        UtilisateurSearch = new Utilisateur();
        BtnSearchUtilisateurCommand = new RelayCommand(SearchUserOnAction);
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
        var result = await service.GetUtilisateurByEmailAsync("api/Utilisateurs/GetByEmail/GetByEmail", SearchMail);
        if (result == null)
            DisplayErreurDialog("Utilisateur non trouvé !", "Erreur");
        else
            UtilisateurSearch = result.Value;
    }

    public async void DisplayErreurDialog(string content, string title)
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
