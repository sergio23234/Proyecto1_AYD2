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
    public partial class Transferir : Form
    {
        public Transferir()
        {
            InitializeComponent();

           // Clase_Controladora getUsrs = new Clase_Controladora();
            DataTable tabla = Clase_Controladora.getcuentas();
            listBox1.DisplayMember = "No_Cuenta";
            listBox1.DataSource = tabla;

            listBox2.DisplayMember = "Nombre";
            listBox2.DataSource = tabla;




        }

        private void button1_Click(object sender, EventArgs e)
        {

            label1.Text = Clase_Controladora.getCuenta();
            label3.Text = Clase_Controladora.Retornar_saldo(Clase_Controladora.usr_cuenta);



            String NoCuenta  = listBox1.GetItemText(listBox1.SelectedItem);
            String montotra = textBox1.Text;

            MessageBox.Show(NoCuenta+ " -- "+ montotra);

            Clase_Controladora.UpdateMoney(NoCuenta, montotra, Clase_Controladora.getCuenta(), Clase_Controladora.Retornar_saldo(Clase_Controladora.usr_cuenta));

        }

        private void Transferir_Load(object sender, EventArgs e)
        {
          


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
