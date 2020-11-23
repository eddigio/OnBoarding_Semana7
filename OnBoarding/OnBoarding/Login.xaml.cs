using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using Xamarin.Forms.Internals;
using OnBoarding.Models;


namespace OnBoarding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        private void btn_login_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, usuario.Text, contra.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Verifique su usuario/contraseña", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");

            }

            }

        


        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db,string usuario, string contra)
        {
            return db.Query<Estudiante>("SELECT * FROM estudiante where Usuario = ? and Contrasenia = ?", usuario, contra);
        }

        private async void btn_registrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registrar());


        }
    }
}