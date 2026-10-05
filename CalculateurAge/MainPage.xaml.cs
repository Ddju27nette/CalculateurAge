using CalculateurAge.Views;

namespace CalculateurAge;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCalculerClicked(object sender, EventArgs e)
    {
        // 1. Validation : vérifier que le champ nom n'est pas vide
        if (string.IsNullOrWhiteSpace(entryNom.Text))
        {
            await DisplayAlert("Erreur", "Entrez un nom", "OK");
            return;
        }

        // 2. Calcul de l'âge
        DateTime d = pickerDate.Date;
        int age = DateTime.Today.Year - d.Year;
        if (d.Date > DateTime.Today.AddYears(-age))
        {
            age--;
        }

        // 3. Navigation vers ResultatPage avec passage des données par l'URL
        await Shell.Current.GoToAsync($"{nameof(ResultatPage)}?nom={entryNom.Text}&age={age}");
    }
}