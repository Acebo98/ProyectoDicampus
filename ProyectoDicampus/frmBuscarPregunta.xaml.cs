using ProyectoDicampus.Entidades;
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

            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }
        }

        //Seleccionamos una respuesta
        private void cbSeleccionarRespuesta(object sender, RoutedEventArgs e)
        {
            CheckBox cbSeleccionado = (CheckBox)sender;
        }
    }
}