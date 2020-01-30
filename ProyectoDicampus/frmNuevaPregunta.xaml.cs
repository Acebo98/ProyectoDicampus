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
    public partial class frmNuevaPregunta : Window
    {
        private Usuario Usuario { get; set; }

        public frmNuevaPregunta(Usuario usuario)
        {
            this.Usuario = usuario;
            InitializeComponent();
        }

        //Clicamos
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btnClicado = (Button)sender;

            switch(btnClicado.Content)
            {
                case "Añadir":  //Nueva pregunta...
                    {
                        if (Utils.Utils.VerificarCampos(new List<string>() { tbNombre.Text,
                            tbOp1.Text, tbOp2.Text, tbOp3.Text, tbOp4.Text }) == true)
                        {
                            try
                            {
                                //Opción correcta
                                int correcta = -1;
                                if (rbOp1.IsChecked == true)
                                {
                                    correcta = 0;
                                }
                                else if (rbOp2.IsChecked == true)
                                {
                                    correcta = 1;
                                }
                                else if (rbOp3.IsChecked == true)
                                {
                                    correcta = 2;
                                }
                                else if (rbOp4.IsChecked == true)
                                {
                                    correcta = 3;
                                }

                                //Pregunta nueva
                                Pregunta nueva = new Pregunta()
                                {
                                    Nombre = tbNombre.Text.Trim(),
                                    Respuesta1 = tbOp1.Text.Trim(),
                                    Respuesta2 = tbOp2.Text.Trim(),
                                    Respuesta3 = tbOp3.Text.Trim(),
                                    Respuesta4 = tbOp4.Text.Trim(),
                                    Correcta = correcta,
                                    UsuarioID = this.Usuario.ID,    //Usuario que la introdujo
                                };

                                //Insertamos...
                                using(var context = new DAOPreguntas())
                                {
                                    if (context.InsertPregunta(nueva) == true)
                                    {
                                        Utils.Utils.CentralizarMensajes("Pregunta insertada satisfactoriamente");
                                        this.Close();
                                    }
                                    else
                                    {
                                        throw new Exception("Error en el insertado de la pregunta");
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
                            Utils.Utils.CentralizarMensajes("Introduzca todos los campos de texto");
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