using HolaMundo.Models;
using HolaMundo.Services;
using HolaMundo.Utils;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace HolaMundo;

public partial class DetailsPage : ContentPage
{
    readonly IServicioApi _servicioApi = new ServicioApi(); //API
    //private ContactosDb _contactosDb = new ContactosDb(); //SQLite
    public Contacto contactoAuth;

    float totalCompras = 0; //Sirve para calcular el total gastado por un cliente
    public DetailsPage()
	{
		InitializeComponent();
        // _servicioApi = servicioApi;
        LoginPage loginPage = Application.Current.MainPage as LoginPage;
        if (loginPage != null)
        {
            loginPage.ContactCaptured += OnContactCaptured;
        }
        BindingContext = contactoAuth;
    }

    private void OnContactCaptured(object sender, Contacto contactoAutentificado)
    {
        this.contactoAuth = contactoAutentificado;
    }

    protected async override void OnAppearing()
    {
        //Write the code of your page here
        base.OnAppearing();
        //Contacto contacto = BindingContext as Contacto;


        if (Preferences.ContainsKey("Contacto"))
        {
            string contactoJson = Preferences.Get("Contacto", string.Empty);
            Contacto contacto = JsonConvert.DeserializeObject<Contacto>(contactoJson); //Deserializa el contacto que envié
            BindingContext = contacto; // Actualiza el BindingContext

            // Va confirmar cuanto ha gastado en total el usuario en la plataforma
            var listaClienteCompra = await _servicioApi.ListarClienteCompras();
            var clienteCompras = new ObservableCollection<ClienteCompra>(listaClienteCompra);

            foreach (var clienteCompra in clienteCompras)
            {
                if (clienteCompra.cedula == contacto.cedula)
                {
                    totalCompras += float.Parse(clienteCompra.valorCompra);
                }
            }

            compras.Text = totalCompras.ToString() + " USD";

            imagen.Source = contacto.imagen;
            nombre.Text = contacto.nombre;
            telefono.Text = contacto.telefono;
            direccion.Text = contacto.direccion;
            cedula.Text = contacto.cedula;
        }
    }

    private async void onClickEliminarContacto(object sender, EventArgs e)
	{
        Contacto contacto = BindingContext as Contacto;
        //await _contactosDb.DeleteContactoAsync(contacto);
        await  _servicioApi.BorrarContacto(contacto.cedula);
        //Util.listContacto.Remove(contacto);
        //await Navigation.PopAsync();
        await DisplayAlert("Alerta", "Su usuario se ha eliminado correctamente", "OK");
        await Navigation.PushAsync(new LoginPage());
    }

	private async void onClickModificarContacto(Object sender, EventArgs e)
	{

		await Navigation.PushAsync(new NewContactPage()
		{
			BindingContext = BindingContext as Contacto,
		}) ;
    }
}