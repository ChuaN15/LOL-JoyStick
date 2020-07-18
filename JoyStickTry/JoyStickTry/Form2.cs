using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoyStickTry
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;

            label3.Parent = pictureBox2;
            label3.BackColor = Color.Transparent;
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
