﻿using System;
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
    public partial class consultar_saldo : Form
    {
        public consultar_saldo()
        {
            InitializeComponent();
            lb_name.Text = Clase_Controladora.retornar_nombre();
            lb_saldo.Text = Clase_Controladora.retornar_saldo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
