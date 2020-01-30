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
using ProyectoDicampus.Utils;

namespace ProyectoDicampus
{
    public partial class frmLogin : Window
    {
        public AccionLogin AccionLogin { get; set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        //Load pantalla
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
                        frmRegistro frmRegistro = new frmRegistro();
                        frmRegistro.ShowDialog();
                    }
                    break;
                case "Conectarse":
                    {
                        if (Utils.Utils.VerificarCampos(new List<string>() { tbUsuario.Text, pwContra.Password }) == true)
                        {

                        }
                        else
                        {
                            Utils.Utils.CentralizarMensajes("Introduzca el nombre y la contraseña");
                        }
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