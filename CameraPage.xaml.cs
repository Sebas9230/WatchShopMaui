using Camera.MAUI;

namespace HolaMundo;

public partial class CameraPage : ContentPage
{
    public string CapturedImagePath { get; private set; }

    public CameraPage()
    {
        InitializeComponent();
    }

    public event EventHandler<ImageSource> PhotoCaptured;//Envia foto
    private async void CameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.NumCamerasDetected > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                if (await cameraView.StartCameraAsync() == CameraResult.Success)
                {
                }
            });
        }
    }


    public async void onClickTomarFoto(object sender, EventArgs e)
    {
        var stream = await cameraView.TakePhotoAsync();
        if (stream != null)
        {
            ImageSource fotoSource = ImageSource.FromStream(() => stream);

            // Genera un nombre de archivo único utilizando un GUID
            string uniqueFileName = $"{Guid.NewGuid()}.png";
            string imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), uniqueFileName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }

            CapturedImagePath = imagePath;

            // Activar el evento PhotoCaptured y pasar la imagen capturada
            PhotoCaptured?.Invoke(this, fotoSource);

            // Mostrar un mensaje de éxito en la plataforma
            await Application.Current.MainPage.DisplayAlert("Éxito", "La foto se ha guardado correctamente.", "Aceptar");

            // Asignar la imagen capturada al ImageView
            capturedImage.Source = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);

            //Te devuelve a la pantalla NewContact
            await Navigation.PopAsync();
        }
    }

    private async void onClickCambiarCamara(object sender, EventArgs e)
    {
        if (cameraView.NumCamerasDetected > 1)
        {
            var currentCamera = cameraView.Camera;
            var availableCameras = cameraView.Cameras;

            // Obtener el índice de la cámara actual
            var currentIndex = availableCameras.IndexOf(currentCamera);

            // Calcular el índice de la siguiente cámara
            var nextIndex = (currentIndex + 1) % availableCameras.Count;

            // Establecer la siguiente cámara como la cámara actual
            cameraView.Camera = availableCameras[nextIndex];

            // Reiniciar la cámara con la nueva configuración
            await cameraView.StopCameraAsync();
            await cameraView.StartCameraAsync();
        }
    }
}