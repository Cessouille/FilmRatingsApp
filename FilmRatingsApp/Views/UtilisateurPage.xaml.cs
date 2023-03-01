using FilmRatingsApp.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace FilmRatingsApp.Views;

public sealed partial class UtilisateurPage : Page
{
    public UtilisateurViewModel ViewModel
    {
        get;
    }

    public UtilisateurPage()
    {
        this.InitializeComponent();
        DataContext = ((App)Application.Current).UtilisateurVM;
    }
}
