namespace AS2223_4G_INF_Cangiotti_RubricaCSVMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

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
        switch (cmbRicerca.SelectedItem)
		{
            case "stampa CSV":
                break;
            case "contiene":
                break;
            case "inizia":
                break;
            case "finisce":
                break;
            default:
                await DisplayAlert("Errore", "Filtro di ricerca inesistente", "OK");
                break;
        }
    }
}