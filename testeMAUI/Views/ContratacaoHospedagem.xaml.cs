
using System.Globalization;

namespace testeMAUI.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        dtpck_checkout.Date = DateTime.Today.AddDays(1);
    }

    private async void OnCalcularClicked(object? sender, EventArgs e)
    {
        if (pck_quarto.SelectedIndex == -1)
        {
            await DisplayAlertAsync(
                "Atenção",
                "Selecione uma suíte.",
                "OK");
            return;
        }

        DateTime checkin = dtpck_checkin.Date ?? DateTime.Today;
        DateTime checkout = dtpck_checkout.Date ?? DateTime.Today.AddDays(1);

        int noites = (checkout - checkin).Days;

        if (noites <= 0)
        {
            await DisplayAlertAsync(
                "Data inválida",
                "O check-out deve ser posterior ao check-in.",
                "OK");
            return;
        }

        string suite = pck_quarto.SelectedItem.ToString()!;

        decimal diaria = suite switch
        {
            "Suíte Standard" => 180m,
            "Suíte Luxo" => 280m,
            "Suíte Premium" => 420m,
            _ => 0m
        };

        decimal total = diaria * noites;

        int adultos = (int)stp_adultos.Value;
        int criancas = (int)stp_criancas.Value;


        await Navigation.PushModalAsync(
            new HospedagemContratada(
                suite,
                adultos,
                criancas,
                checkin,
                checkout,
                noites,
                total));

    }
}
