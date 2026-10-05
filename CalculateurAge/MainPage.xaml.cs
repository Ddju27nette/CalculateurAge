namespace CalculateurAge;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCalculerClicked(object sender, EventArgs e)
    {
        // 1. Validation : nom non vide
        if (string.IsNullOrWhiteSpace(entryNom.Text))
        {
            DisplayAlert("Erreur", "Entrez un nom", "OK");
            return;
        }

        // 2. Calcul de l'âge
        DateTime d = pickerDate.Date;
        int age = DateTime.Today.Year - d.Year;
        if (d.Date > DateTime.Today.AddYears(-age))
        {
            age--;
        }

        // 3. Modification directe des contrôles de l'interface
        lblResultat.Text = $"{entryNom.Text}, vous avez {age} ans";
        lblResultat.IsVisible = true;
    }
}