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
using ProyectoDicampus.Entidades;
using ProyectoDicampus.Modelos;
using ProyectoDicampus.Utils;

namespace ProyectoDicampus
{
    public partial class frmRegistro : Window
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        //Click
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btnClicado = (Button)sender;

            switch(btnClicado.Content)
            {
                case "Aceptar":
                    {
                        if (Utils.Utils.VerificarCampos(new List<string>() { tbUsuario.Text, pwConfirmarContra.Password, pwContra.Password }) == true)
                        {
                            //Verificar contraseña
                            if (pwContra.Password.Trim() == pwConfirmarContra.Password.Trim())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Username = tbUsuario.Text;
                                usuario.Password = pwContra.Password;
                                usuario.Genero = (cbGenero.SelectedIndex == 0) ? true : false;

                                try
                                {
                                    using (var context = new DAOUsuarios())
                                    {
                                        //Comprobamos si el nombre de usuario está pillado
                                        if (context.ComprobarExistencia(usuario.Username) == false)
                                        {
                                            if (context.Insert(usuario) == false)
                                            {
                                                throw new Exception("Ha ocurrido un error durante el registro");
                                            }
                                        }
                                        else
                                        {
                                            throw new Exception("Dicho nombre de usuario no está disponible");
                                        }
                                    }
                                }
                                catch(Exception err)
                                {
                                    MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                Utils.Utils.CentralizarMensajes("Las contraseñas no coincides");
                            }
                        }
                        else
                        {
                            Utils.Utils.CentralizarMensajes("Rellene todos los campos");
                        }
                    }
                    break;
                case "Cancelar":
                    this.Close();
                    break;
            }
        }
    }
}
