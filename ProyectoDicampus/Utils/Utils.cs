using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoDicampus.Utils
{
    public class Utils
    {
        //Comprobamos campos de texto
        public static bool VerificarCampos(List<string> lCampos)
        {
            bool vof = true;
            foreach (string campo in lCampos)
            {
                if (string.IsNullOrWhiteSpace(campo) == true)
                {
                    vof = !vof;
                    break;
                }
            }
            return vof;
        }

        //Limpiar campos de texto
        public static void LimpiarCampos(List<TextBox> lCampos)
        {
            lCampos.ForEach(campo => campo.Clear());
        }

        //Centralizar mensajes
        public static void CentralizarMensajes(string mensaje)
        {
            MessageBox.Show(mensaje, "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
