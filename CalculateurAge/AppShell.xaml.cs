using CalculateurAge.Views;

namespace CalculateurAge;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Enregistre la route pour pouvoir naviguer vers ResultatPage
        Routing.RegisterRoute(nameof(ResultatPage), typeof(ResultatPage));
    }
}