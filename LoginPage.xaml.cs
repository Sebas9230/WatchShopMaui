using System.Collections.ObjectModel;
using HolaMundo.Models;
using HolaMundo.Services;
using Microsoft.Maui.Graphics;
using Newtonsoft.Json;

namespace HolaMundo;

public partial class LoginPage : ContentPage
{
    private ContactosDb _contactosDb = new ContactosDb();
    public Contacto contactoAutentificado;

    readonly IServicioApi _servicioApi = new ServicioApi(); //Con este funciona Base de datos


    public event EventHandler<Contacto> ContactCaptured;// Evento que envía contacto
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // Mostramos el ActivityIndicator (espera)
        loginIndicator.IsRunning = true;
        loginIndicator.IsVisible = true;

        //var listaContacto = await _contactosDb.GetContactosAsync();
        var listaContacto = await _servicioApi.ListarContactos();
        var contactos = new ObservableCollection<Contacto>(listaContacto);

        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        bool isCredentialsCorrect = false;

        foreach (var contacto in contactos)
        {
            if (contacto.UserName == username && contacto.Password == password)
            {
                isCredentialsCorrect = true;
                contactoAutentificado = contacto;
                ContactCaptured?.Invoke(this, contactoAutentificado);
                Preferences.Set("Contacto", JsonConvert.SerializeObject(contactoAutentificado)); //Guarda contacto en la memoria
                break;
            }
        }

        // Ocultamos el ActivityIndicator (Espera)
        loginIndicator.IsRunning = false;
        loginIndicator.IsVisible = false;

        if (isCredentialsCorrect || (username == "admin" && password == "admin"))
        {
            // El nombre de usuario y la contraseña son correctos, puedes navegar a la página de administrador o realizar acciones específicas para el administrador.
            await Navigation.PushAsync(new ProductPage());

        }
        else
        {
            // El nombre de usuario o la contraseña son incorrectos, puedes mostrar un mensaje de error o realizar otras acciones.
            await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
        }
    }


    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewContactPage());
    }

}