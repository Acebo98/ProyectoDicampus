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
using System.Windows.Shapes;

namespace ProyectoDicampus
{
    public partial class frmBuscarPregunta : Window
    {
        private Usuario Usuario { get; set; }
        private Pregunta Pregunta { get; set; }

        public frmBuscarPregunta(Usuario usuario)
        {
            this.Usuario = usuario;
            InitializeComponent();
        }

        //Cargamos y mostramos una pregunta
        private void Ventana_BuscarPregunta_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new DAOPreguntas())
                {
                    Pregunta pregunta = context.PreguntaAzar();
                    if (pregunta != null)
                    {
                        this.Pregunta = pregunta;   //Guardamos su instancia

                        //Mostramos los datos de la pregunta en el interfazs
                        tbNombrePregunta.Text = pregunta.Nombre;
                        tbOp1.Text = pregunta.Respuesta1;
                        tbOp2.Text = pregunta.Respuesta2;
                        tbOp3.Text = pregunta.Respuesta3;
                        tbOp4.Text = pregunta.Respuesta4;
                    }
                    else
                    {
                        throw new Exception("Error en la búsqueda de una pregunta");
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                this.Close();
            }
        }

        //Seleccionamos una respuesta y vemos si es correcta
        private void cbSeleccionarRespuesta(object sender, RoutedEventArgs e)
        {
            CheckBox cbSeleccionado = (CheckBox)sender;
            int tag = Convert.ToInt32(cbSeleccionado.Tag);

            //Miramos si es correcta
            if (tag == this.Pregunta.Correcta)
            {
                Utils.Utils.CentralizarMensajes("¡Ha acertado la pregunta!");
                try
                {
                    //Aumentamos en 1 la puntuación del usuario...
                    using (var context = new DAOUsuarios())
                    {
                        if (context.AumentarPuntuacion(this.Usuario.Username, 1) == false)
                        {
                            throw new Exception("Se ha producido un error");
                        }
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message, "Aviso", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("¡No es correcto!", "Aviso", MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }

            this.Close();
        }
    }
}