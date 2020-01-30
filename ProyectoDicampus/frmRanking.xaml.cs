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
    public partial class frmRanking : Window
    {
        private List<Usuario> lUsuarios { get; set; }
        private const string PUNTUACION = "Puntuación: ";

        public frmRanking()
        {
            InitializeComponent();
        }

        //Cargamos las puntuaciones
        private void Ventana_Ranking_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new DAOUsuarios())
                {
                    List<Usuario> lUsuarios = context.SacarRanking();
                    if (lUsuarios != null)
                    {
                        this.lUsuarios = lUsuarios;     //Guardamos la instancia
                        foreach (Usuario usuario in lUsuarios)
                        {
                            lbxRanking.Items.Add(usuario.Username);
                        }
                        if (lbxRanking.HasItems == true)
                        {
                            lbxRanking.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        throw new Exception("Ha ocurrido un error en el cargado del ranking");
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        //Seleccionamos en el ranking y mostramos la puntuación de la persona
        private void lbxRanking_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lbxRanking.SelectedItem == null)
                {
                    return;
                }

                //Sacamos al usuario...
                string username = lbxRanking.SelectedItem.ToString();
                Usuario usuario = this.lUsuarios.Where(user => user.Username == username).Single();
                tbScore.Text = PUNTUACION + usuario.Puntuacion;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }          
        }

        //Volvemos
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}