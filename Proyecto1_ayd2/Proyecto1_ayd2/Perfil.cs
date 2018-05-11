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
    public partial class Perfil : Form
    {
        Form parent;
        public Perfil(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            lb_datos.Text = Clase_Controladora.getNombre() + " " + Clase_Controladora.getApellido() + " - " + Clase_Controladora.getCuenta();
            lb_nombres.Text = Clase_Controladora.getNombre();
            lb_apellidos.Text = Clase_Controladora.getApellido();
            lb_cuenta.Text = Clase_Controladora.getCuenta();
            lb_dpi.Text = Clase_Controladora.getDpi();
            lb_correo.Text = Clase_Controladora.getCorreo();
        }

        private void Perfil_Load(object sender, EventArgs e)
        {

        }

        private void bt_Consultar_Click(object sender, EventArgs e)
        {
            consultar_saldo cons = new consultar_saldo();
            cons.Show();
            this.Hide();
        }

        private void btTransferencia_Click(object sender, EventArgs e)
        {
            Transferir transferencia = new Transferir();
            transferencia.Show();
            this.Hide();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha cerrado la sesion");
            this.Hide();
            this.parent.Show();
        }
    }
}
