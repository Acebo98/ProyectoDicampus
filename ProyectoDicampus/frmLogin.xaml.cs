using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoDicampus
{
    public partial class frmLogin : Window
    {
        public AccionLogin AccionLogin { get; set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        //Cargamos el componente
        private void ventanaLogin_Loaded(object sender, RoutedEventArgs e)
        {
            labFecha.Text = "Fecha: " + DateTime.Today.ToString("dd, MMM yyyy");
        }

        //Click
        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button btnClicado = (Button)sender;
            
            switch(btnClicado.Content)
            {
                case "Registrarse":
                    {

                    }
                    break;
                case "Conectarse":
                    {

                    }
                    break;
                case "Salir":
                    {
                        this.AccionLogin = AccionLogin.Salir;
                        this.Close();
                    }
                    break;
            }
        }
    }

    public enum AccionLogin
    {
        Registrarse,
        Conectarse,
        Salir
    }
}
