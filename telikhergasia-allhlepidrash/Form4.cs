using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace telikhergasia_allhlepidrash
{
    public partial class Form4 : Form
    {
        bool rb1, rb2;
       
        
        public Form4(bool rb1, bool rb2)
        {
            InitializeComponent();
            this.rb1 = rb1; //bool apo thn forma 2 gia thn eisodo ws customer/employee
            this.rb2 = rb2;
        }
       
        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void Form4_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 frm5 = new Form5(rb1, rb2); //anoigma ths formas  5(e-shop) kai kleisimo ths parousas formas
            frm5.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); //anoigma ths formas 2(menu) kai kleisomo ths paroushs
            Form2 frm2 = new Form2();
            frm2.Show();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is our library please click 'enter e shop' to start shooping or back to return to the menu! ");
        }

        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
           

        }
    }
}
