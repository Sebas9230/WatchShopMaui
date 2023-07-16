using HolaMundo.Models;
using HolaMundo.Services;
//using Java.Lang;
using Newtonsoft.Json;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HolaMundo
{
    public partial class CarritoComprasPage : ContentPage
    {
        ClienteCompra clienteCompra;

        readonly IServicioApi _servicioApi = new ServicioApi(); //Usar API
        public static List<Producto> Carrito { get; set; } = new List<Producto>();

        public static readonly BindableProperty TotalProperty =
            BindableProperty.Create(nameof(Total), typeof(decimal), typeof(CarritoComprasPage));


        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    //Coge los datos del contacto logeado
        //    if (Preferences.ContainsKey("Contacto"))
        //    {
        //        string contactoJson = Preferences.Get("Contacto", string.Empty);
        //        Contacto contacto = JsonConvert.DeserializeObject<Contacto>(contactoJson); //Deserializa el contacto que envié
        //    }
        //}

        public decimal Total
        {
            get { return (decimal)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }

        public CarritoComprasPage()
        {
            InitializeComponent();
            listaCarrito.ItemsSource = Carrito;
            BindingContext = this; // Establecer el contexto de datos como la propia instancia de CarritoComprasPage
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (var producto in Carrito)
            {
                if (decimal.TryParse(producto.price, out decimal price))
                {
                    // Se pudo convertir el valor de Price a decimal
                    total += price;
                }
                else
                {
                    // No se pudo convertir el valor de Price a decimal
                    // Aquí puedes manejar el caso de error o mostrar un mensaje al usuario
                }
            }
            Total = total;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Aquí puedes implementar la lógica para manejar la selección de un producto en el carrito
        }

        // Metodo para generar el codigo de compra
        public static int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        private async void OnClickPagar(object sender, EventArgs e)
        {
            // Muestra una ventana emergente
            await DisplayAlert("Gracias", "Gracias por su compra", "OK");

            //Coge los datos del contacto logeado
            if (Preferences.ContainsKey("Contacto"))
            {
                string contactoJson = Preferences.Get("Contacto", string.Empty);
                Contacto contacto = JsonConvert.DeserializeObject<Contacto>(contactoJson); //Deserializa el contacto que envié

                //Crea la compra con nombre y valor
                clienteCompra = new ClienteCompra()
                {
                    codigoCompra = GenerateRandomNumber().ToString(),
                    nombreCliente = contacto.nombre,
                    valorCompra = Total.ToString(),
                    cedula = contacto.cedula,
                };
                await _servicioApi.GuardarClienteCompra(clienteCompra);
            }

            // Limpia el carrito
            //Carrito.Clear();
            Carrito = new List<Producto>();

            //Te devuelve a la anterior pantalla
            await Navigation.PopAsync();
        }
    }
}
