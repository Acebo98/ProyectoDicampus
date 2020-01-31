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
using ProyectoDicampus.Utils;
using ProyectoDicampus.Modelos;

namespace ProyectoDicampus
{
    public partial class frmPerfil : Window
    {
        private Usuario Usuario { get; set; }
        public ResultadoPerfil ResultadoPerfil { get; set; }

        public frmPerfil(int idenfiticador)
        {
            try
            {
                //Sacamos los datos del perfil
                using (var context = new DAOUsuarios())
                {
                    this.Usuario = context.SacarInfo(idenfiticador);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                this.Close();
            }
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
            Button btnClicado = (Button)sender;

            switch(btnClicado.Content)
            {
                case "Modificar":
                    {
                        if (Utils.Utils.VerificarCampos(new List<string>() { tbContra.Text, tbUsuario.Text }) == true)
                        {
                            try
                            {
                                using (var context = new DAOUsuarios())
                                {
                                    //Comprobamos que el nuevo nombre esté disponible
                                    if (context.ComprobarExistencia(tbUsuario.Text.Trim(), this.Usuario.Username) == false)
                                    {
                                        Usuario nuevo = new Usuario()
                                        {
                                            ID = this.Usuario.ID,
                                            Username = tbUsuario.Text.Trim(),
                                            Password = tbContra.Text.Trim(),
                                            Genero = (cbGenero.SelectedIndex == 0) ? true : false,
                                        };

                                        //Modificamos
                                        if (context.ModificarPerfil(nuevo) == false)
                                        {
                                            throw new Exception("Ha ocurrido un error al modificar el perfil");
                                        }
                                        else
                                        {
                                            this.ResultadoPerfil = ResultadoPerfil.Modificar;   //Hemos modificado

                                            Utils.Utils.CentralizarMensajes("Los nuevos datos han sido guardados");
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Ya existe dicho nombre de usuario");
                                    }
                                }
                            }
                            catch(Exception err)
                            {
                                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, 
                                    MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            Utils.Utils.CentralizarMensajes("Para modificar el perfil se deben de introducir todos los datos");
                        }
                    }
                    break;
                case "Volver":
                    {
                        this.ResultadoPerfil = ResultadoPerfil.Volver;
                        this.Close();
                    }                   
                    break;
            }
        }
    }

    public enum ResultadoPerfil
    {
        Modificar,
        Volver
    }
}