using HolaMundo.Services;
using HolaMundo.Utils;

namespace HolaMundo;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();
        //Util._servicioApi=new ServicioApi();
        MainPage = new NavigationPage(new LoginPage());
	}
}
