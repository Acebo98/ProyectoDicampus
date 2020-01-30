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
    public partial class frmPerfil : Window
    {
        private Usuario Usuario { get; set; }

        public frmPerfil(Usuario usuario)
        {
            this.Usuario = usuario;
            InitializeComponent();
        }

        //Cargamos y mostramos los datos del usuario
        private void Window_Perfil_Loaded(object sender, RoutedEventArgs e)
        {
            tbUsuario.Text = this.Usuario.Username;
            tbScore.Text = this.Usuario.Puntuacion.ToString();
            tbContra.Text = this.Usuario.Password;
            cbGenero.SelectedIndex = (this.Usuario.Genero == true) ? 0 : 1;
        }

        //Volvemos
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}