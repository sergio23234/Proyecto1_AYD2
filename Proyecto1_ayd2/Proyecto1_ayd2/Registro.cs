using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_ayd2
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 forma = new Form1();
            forma.Show();
            this.Hide();
        }

        private void entrar_Click(object sender, EventArgs e)
        {
            // Confirmar y registrarse!
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            String contra = txtContra.Text;
            String dpi = txtDPI.Text;
            String correo = txtCorreo.Text;
            String saldo = txtSaldo.Text;
            if(nombre.Equals("") || apellido.Equals("") || contra.Equals("") || dpi.Equals("") || correo.Equals("")
                || saldo.Equals("")){
                    MessageBox.Show("Llene todos los campos para registrarse!");
                }
            else
            {
                // Validar correo
                if (!Clase_Controladora.validarCorreo(correo))
                {
                    MessageBox.Show("Ingrese un correo valido!");
                    return;
                }
                // Validar saldo
                if (!Clase_Controladora.validarSaldo(saldo))
                {
                    MessageBox.Show("El saldo es de tipo numerico!");
                    return;
                }
                String cuenta = Clase_Controladora.registrarse(nombre,apellido,contra,dpi,correo,saldo);
                if (cuenta != null)
                {
                    MessageBox.Show("Se ha registrado correctamente!");
                    MessageBox.Show("Su numero de cuenta es: "+cuenta);
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar, intente nuevamente!");
                }
                    
            }
        }
    }
}
