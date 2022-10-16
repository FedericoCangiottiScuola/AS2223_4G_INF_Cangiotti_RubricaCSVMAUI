using System.Collections.ObjectModel;

namespace AS2223_4G_INF_Cangiotti_RubricaCSVMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	public class Item
	{
		public string nomeCognome{ get; set; }
		public string citta{ get; set; }
	}

    ObservableCollection<Item> dsContatti = new ObservableCollection<Item>();
    static int nRecord = 0;
	Contatto[] contatti = new Contatto[nRecord];

	void CaricaFileCSV()
	{
		using (StreamReader sr = new StreamReader(txtFile.Text))
		{
			string riga;
			int i = 0;
			while (!sr.EndOfStream)
			{
				riga = sr.ReadLine();
				Contatto contatto = new Contatto(riga);
				contatti[i] = contatto;

				i++;
			}
		}
    }

	void StampaCSV()
	{
        dsContatti.Clear();
        for (int i = 0; i < nRecord; i++)
        {
            dsContatti.Add(
				new Item() {
					nomeCognome = $"{contatti[i].Nome} {contatti[i].Cognome}",
					citta = $"{contatti[i].Citta}"
				}
			);
        }
		
		lstRisultati.ItemsSource = dsContatti;
    }

    void StampaCognomiContiene()
    {
        dsContatti.Clear();
        for (int i = 0; i < nRecord; i++)
        {
			if (contatti[i].Cognome.ToLower().Contains(txtCognome.Text.ToLower()))
			{
				dsContatti.Add(
                    new Item()
                    {
                        nomeCognome = $"{contatti[i].Nome} {contatti[i].Cognome}",
                        citta = $"{contatti[i].Citta}"
                    }
                );
			}
        }

        lstRisultati.ItemsSource = dsContatti;
    }

    void StampaCognomiInizia()
    {
        dsContatti.Clear();
        for (int i = 0; i < nRecord; i++)
        {
            if (contatti[i].Cognome.ToLower().StartsWith(txtCognome.Text.ToLower()))
            {
                dsContatti.Add(
                    new Item()
                    {
                        nomeCognome = $"{contatti[i].Nome} {contatti[i].Cognome}",
                        citta = $"{contatti[i].Citta}"
                    }
                );
            }
        }

        lstRisultati.ItemsSource = dsContatti;
    }

    void StampaCognomiFinisce()
    {
        dsContatti.Clear();
        for (int i = 0; i < nRecord; i++)
        {
            if (contatti[i].Cognome.ToLower().EndsWith(txtCognome.Text.ToLower()))
            {
                dsContatti.Add(
                    new Item()
                    {
                        nomeCognome = $"{contatti[i].Nome} {contatti[i].Cognome}",
                        citta = $"{contatti[i].Citta}"
                    }
                );
            }
        }

        lstRisultati.ItemsSource = dsContatti;
    }

    private async void btnCaricaFile_Clicked(object sender, EventArgs e)
	{
		try
		{
			var file = await FilePicker.PickAsync();
			if (file == null)
			{
				return;
			}
			txtFile.Text = file.FullPath;
            nRecord = File.ReadLines(txtFile.Text).Count();
            Array.Resize(ref contatti, nRecord);

            CaricaFileCSV();
		}
		catch
		{
            await DisplayAlert("Errore", "Impossibile caricare il file", "OK");
        }
	}

	private async void btnVisualizza_Clicked(object sender, EventArgs e)
	{
        if (txtFile.Text == null)
        {
            await DisplayAlert("Errore", "Nessun file selezionato", "OK");
            return;
        }

        if ((txtCognome.Text == null || txtCognome.Text == "") && (string)cmbRicerca.SelectedItem != "stampa CSV")
        {
            await DisplayAlert("Errore", "Nessun cognome inserito", "OK");
            return;
        }

        switch (cmbRicerca.SelectedItem)
		{
            case "stampa CSV":
				StampaCSV();
                break;
            case "contiene":
				StampaCognomiContiene();
                break;
            case "inizia":
				StampaCognomiInizia();
                break;
            case "finisce":
                StampaCognomiFinisce();
                break;
            default:
                await DisplayAlert("Errore", "Filtro di ricerca inesistente", "OK");
                break;
        }
    }
}