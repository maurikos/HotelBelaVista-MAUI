
using System.Globalization;

namespace testeMAUI.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada(
        string suite,
        int adultos,
        int criancas,
        DateTime checkin,
        DateTime checkout,
        int noites,
        decimal total)
    {
        InitializeComponent();

        lbl_suite.Text = $"Suíte: {suite}";

        lbl_hospedes.Text =
            $"Adultos: {adultos} | Crianças: {criancas}";

        lbl_checkin.Text =
            $"Check-in: {checkin:dd/MM/yyyy}";

        lbl_checkout.Text =
            $"Check-out: {checkout:dd/MM/yyyy}";

        lbl_diarias.Text =
            $"Quantidade de diárias: {noites}";

        lbl_total.Text =
            total.ToString("C", new CultureInfo("pt-BR"));
    }

    private async void OnVoltarClicked(
        object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
