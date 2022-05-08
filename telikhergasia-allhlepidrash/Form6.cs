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
    public partial class Form6 : Form
    {
        List<string> BooksToCart2 = new List<string>(); //orismos ths listas me ta vivlia tou kalathiou
        decimal TB = 0; // metavlhth gia to totalprice twn agorwn
        public Form6(List<string> BooksToCart,decimal TB)
        {
            InitializeComponent();
            maskedTextBox1.Mask = "00/0000";
            this.BooksToCart2 = BooksToCart; 
            this.TB = TB;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            richTextBox1.Lines = BooksToCart2.ToArray(); //eisagwgh twn stoixeiwn ths listas sto richtextbox
            textBox3.Text = TB.ToString(); //eisagwgh ths timhs twn vivliwn 
            if (richTextBox1.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true; //emfanish twn groopbox gia ta xtoixeia ths paragelias
            groupBox2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox6.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox7.Text != "" && textBox2.Text != "")
                MessageBox.Show("Your order has been succesfully procedeed");
            else
                MessageBox.Show("Invalid info");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            textBox3.Text = "";
        }

        private void label10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is your cart where you can see the books you have add and the total price for them.If you are ready to check out click the button and then you just type your adress info and then your cart's name and number to proceed. ");
        }
    }
}
