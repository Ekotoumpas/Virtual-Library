using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telikhergasia_allhlepidrash
{
    public partial class Form2 : Form
    {
        public Form2() //kentriko menu
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
             this.Close(); //anoigma ths formas 4 kata thn epilogh ths 
            Form4 frm4 = new Form4(radioButton1.Checked, radioButton2.Checked);
            frm4.Show();
      
            
        }

        private void button2_Click(object sender, EventArgs e)
        {//anoigma ths formas 3 kata thn epilogh ths
           
            Form3 frm3 = new Form3(radioButton1.Checked,radioButton2.Checked);
            frm3.Show();
            this.Close();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.AutoCheck = true; //radiobutton gia epilogh customer
            if (radioButton1.Checked) {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) //radiobutton gia epilogh employee
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void radioButton1_MouseDown(object sender, MouseEventArgs e)
        {
            radioButton1.AutoCheck = true;

        }

        private void radioButton2_MouseDown(object sender, MouseEventArgs e)
        {
            radioButton2.AutoCheck = true;

        }

        private void button3_Click(object sender, EventArgs e)
        { //anoigma ths formas 7 kata thn epilogh ths
            Form7 frm7 = new Form7(radioButton1.Checked, radioButton2.Checked);
            frm7.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have to choose customer or employee based on your. Then just enter wherever you want by clicking on the right option. ");
        }
    }
}
