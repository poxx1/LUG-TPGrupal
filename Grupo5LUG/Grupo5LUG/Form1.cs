using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo5LUG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LinqToDataset lq = new LinqToDataset();

            var ds = lq.consulta();

            dataGridView1.DataSource = null;
            //dataGridView1.DataSource = ds;

            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
