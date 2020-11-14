using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana6SCondor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vistaInsertar : ContentPage
    {
        private const string Url = "http://uisrael-semana6.webcindario.com/post.php";
        public vistaInsertar()
        {
            InitializeComponent();
        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient cliente = new HttpClient();

                var parametros = new Dictionary<string, string>();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                var req = new HttpRequestMessage(HttpMethod.Post, Url) { Content = new FormUrlEncodedContent(parametros) };
                var res = await cliente.SendAsync(req);
                await DisplayAlert("Alerta", "Dato ingresado correctamente", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error: " + ex.Message, "ok");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}