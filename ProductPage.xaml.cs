using HolaMundo.Models;
using HolaMundo.Services;
using HolaMundo.Utils;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HolaMundo;

public partial class ProductPage : ContentPage
{
    readonly IServicioApi _servicioApi = new ServicioApi(); //API
    public ProductPage()
    {
        InitializeComponent();
        //listaContactos.ItemsSource = Util.listContacto;
    }

    private async void DetalleItem(object sender, SelectedItemChangedEventArgs e)
    {
        Producto producto = (Producto)e.SelectedItem;
        await Navigation.PushAsync(new DetailsProductPage()
        {
            BindingContext = producto
        });
    }

    //protected override void OnAppearing()
    protected async override void OnAppearing()
    {
        //Write the code of your page here
        base.OnAppearing();
        //var productos = new ObservableCollection<Producto>(UtilsReloj.listProducto); //Toma relojes de utils
        var listaProducto = await _servicioApi.ListarProductos(); //Toma relojes de API
        var productos = new ObservableCollection<Producto>(listaProducto);
        Console.WriteLine("###################consulta");
        listaProductos.ItemsSource = productos;


        if (Preferences.ContainsKey("Contacto"))
        {
            string contactoJson = Preferences.Get("Contacto", string.Empty);
            Contacto contacto = JsonConvert.DeserializeObject<Contacto>(contactoJson); //Deserializa el contacto que envié
            //BindingContext = contacto; // Actualiza el BindingContext

            //imagenPerfil.Source = contacto.imagen;

        }

    }

    private async void onClickMiCuenta (object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetailsPage());
    }

}