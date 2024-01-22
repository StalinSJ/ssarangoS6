using Newtonsoft.Json;
using ssarangoS6.Modelos;
using System.Collections.ObjectModel;

namespace ssarangoS6.Vistas;

public partial class Inicio : ContentPage
{
	private const string Url = "http://172.24.176.1/moviles/post.php";
	private  readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiantes> estud;

    public Inicio()
	{
		InitializeComponent();
		Obtener();
	}
	public async void Obtener()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiantes> mostrarEstu = JsonConvert.DeserializeObject<List<Estudiantes>>(content);
		estud = new ObservableCollection<Estudiantes>(mostrarEstu);
		ListaEstudiantes.ItemsSource = estud;
	}
}