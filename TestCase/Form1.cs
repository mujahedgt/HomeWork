using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnHer_Click(object sender, EventArgs e)
        {
            string userNAme = textBox1.Text;
            string passowr = textBox2.Text;
            string text = "Fuck YOu "+userNAme+" i know your pass "+passowr;
            label4.Text = text; 
        }
    }
}
