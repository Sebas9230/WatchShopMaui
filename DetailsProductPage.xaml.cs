using HolaMundo.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using HolaMundo.Services;

namespace HolaMundo;

public partial class DetailsProductPage : ContentPage
{
    readonly IServicioApi _servicioApi = new ServicioApi(); //API
    public DetailsProductPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        //Write the code of your page here
        base.OnAppearing();

        Producto producto = BindingContext as Producto;
        imagen.Source = producto.picture;
        nombre.Text = producto.name;
        precio.Text = producto.price;
        cantidad.Text = producto.quantity;
    }

    private async void onClickAgregarCarrito(object sender, EventArgs e)
    {
        Producto producto = BindingContext as Producto;

        // Aqu� puedes agregar la l�gica para agregar el producto al carrito
        // por ejemplo, utilizando una lista o alg�n servicio

        // Ejemplo utilizando una lista est�tica en la clase CarritoComprasPage
        CarritoComprasPage.Carrito.Add(producto);

        await DisplayAlert("�xito", "El producto ha sido agregado al carrito de compras", "Aceptar");
    }

    private async void onClickIrCarrito(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CarritoComprasPage());
    }
}