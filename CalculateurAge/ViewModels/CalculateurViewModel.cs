namespace CalculateurAge.ViewModels;

public class CalculateurViewModel : BaseViewModel
{
    private string _nom = string.Empty;
    private DateTime _dateNaissance = DateTime.Today.AddYears(-20);
    private string _resultat = string.Empty;
    private string _statut = string.Empty;
    private string _joursRestants = string.Empty;
    private bool _resultatVisible;

    public string Nom
    {
        get => _nom;
        set
        {
            if (SetField(ref _nom, value))
            {
                CalculerCommand.Rafraichir();
            }
        }
    }

    public DateTime DateNaissance
    {
        get => _dateNaissance;
        set => SetField(ref _dateNaissance, value);
    }

    public string Resultat
    {
        get => _resultat;
        set => SetField(ref _resultat, value);
    }

    public string Statut
    {
        get => _statut;
        set => SetField(ref _statut, value);
    }

    public string JoursRestants
    {
        get => _joursRestants;
        set => SetField(ref _joursRestants, value);
    }

    public bool ResultatVisible
    {
        get => _resultatVisible;
        set => SetField(ref _resultatVisible, value);
    }

    public RelayCommand CalculerCommand { get; }
    public RelayCommand EffacerCommand { get; }

    public CalculateurViewModel()
    {
        CalculerCommand = new RelayCommand(Calculer, () => !string.IsNullOrWhiteSpace(Nom));
        EffacerCommand = new RelayCommand(Effacer);
    }

    private void Calculer()
    {
        // 1. Contrôle : refus d'une date future
        if (DateNaissance.Date > DateTime.Today)
        {
            Resultat = "Erreur : La date de naissance ne peut pas être dans le futur !";
            Statut = string.Empty;
            JoursRestants = string.Empty;
            ResultatVisible = true;
            return;
        }

        // Calcul exact de l'âge
        int age = DateTime.Today.Year - DateNaissance.Year;
        if (DateNaissance.Date > DateTime.Today.AddYears(-age))
        {
            age--;
        }

        Resultat = $"{Nom}, vous avez {age} ans";

        // Fonctionnalité 1 : Statut Majeur / Mineur
        Statut = age >= 18 ? "Statut : Majeur" : "Statut : Mineur";

        // Fonctionnalité 2 : Jours restants avant le prochain anniversaire
        DateTime prochainAnniv = new DateTime(DateTime.Today.Year, DateNaissance.Month, DateNaissance.Day);
        if (prochainAnniv < DateTime.Today)
        {
            prochainAnniv = prochainAnniv.AddYears(1);
        }
        int jours = (prochainAnniv - DateTime.Today).Days;
        JoursRestants = jours == 0
            ? "Joyeux anniversaire aujourd'hui !"
            : $"Prochain anniversaire dans {jours} jour(s)";

        ResultatVisible = true;
    }

    // Fonctionnalité 3 : Remise à zéro
    private void Effacer()
    {
        Nom = string.Empty;
        DateNaissance = DateTime.Today.AddYears(-20);
        Resultat = string.Empty;
        Statut = string.Empty;
        JoursRestants = string.Empty;
        ResultatVisible = false;
        CalculerCommand.Rafraichir();
    }
}