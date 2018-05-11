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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void registro_Click(object sender, EventArgs e)
        {
            Registro reg = new Registro();
            reg.Show();
            this.Hide();
        }

        private void entrar_Click(object sender, EventArgs e)
        {
            string cuenta = textcuenta.Text;
            string password = textcontra.Text;

            bool resultado = Clase_Controladora.Login(cuenta, password);
            if(resultado == true)
            {
                MessageBox.Show("Bienvenido " + Clase_Controladora.getNombre() + " " + Clase_Controladora.getApellido());
                textcuenta.Clear();
                textcontra.Clear();
                Perfil perfil = new Perfil(this);
                perfil.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ERROR\nEl nombre de usuario o el password son incorrectos");
                textcontra.Clear();
                textcuenta.Clear();
            }
        }
    }
}
