using ProyectoDicampus.Entidades;
using ProyectoDicampus.Modelos;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoDicampus
{
    public partial class MainWindow : Window
    {
        public Usuario Usuario { get; set; }    //Datos del usuario conectado

        public MainWindow()
        {
            InitializeComponent();
        }

        //Cargamos el componente
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();

            //Acción realizada en el formulario de inicio de sesión
            if (frmLogin.AccionLogin == AccionLogin.Salir)
            {
                this.Close();
            }
            else if (frmLogin.AccionLogin == AccionLogin.Conectarse)
            {
                try
                {
                    using (var context = new DAOUsuarios())
                    {
                        //Sacamos todos los datos del usuario que se acaba de conectar...
                        Usuario buscado = context.SacarInfo(frmLogin.Username);
                        if (buscado != null)
                        {
                            this.Usuario = buscado;
                        }
                        else
                        {
                            throw new Exception("Ha ocurrido un error en el cargado de datos");
                        }
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }              
            }
        }

        //Seleccionamos una sección
        private void btnSeccion_Click(object sender, RoutedEventArgs e)
        {
            Button btnClicado = (Button)sender;

            //Botón clicado...
            if (btnClicado == btnBuscar)
            {
                try 
                { 
                    using (var context = new DAOPreguntas())
                    {
                        //Mostramos una pregunta...
                        if (context.HayPreguntas == true)
                        {
                            frmBuscarPregunta frmBuscarPregunta = new frmBuscarPregunta(this.Usuario);
                            frmBuscarPregunta.ShowDialog();
                        }
                        else
                        {
                            throw new Exception("Desgraciadamente no hay preguntas almacenadas en estos momentos");
                        }
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, 
                        MessageBoxImage.Error);
                }
            }
            else if (btnClicado == btnNuevaPregunta)
            {
                frmNuevaPregunta frmNuevaPregunta = new frmNuevaPregunta(this.Usuario);
                frmNuevaPregunta.ShowDialog();
            }
            else if (btnClicado == btnPerfil)
            {
                frmPerfil frmPerfil = new frmPerfil(this.Usuario);
                frmPerfil.ShowDialog();
            }
        }
    }
}