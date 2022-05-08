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
    public partial class Form5 : Form
    {
        SqlConnection connection; // orismo tou coonection 
        string connectionS; // orismos tous connection string
        DataTable bookstable = new DataTable(); //orismos tou datable gia thn eisagwgh twn stoixeiwn ths vashs
        public List<string> BooksToCart = new List<string>(); //orismos ths listas gia ta vivlia pros agora
        Image[] images = new Image[20]; //orismos tou pinaka gia a images
        int x = 0;
        int counter = 0;
        decimal totalBill = 0;
        bool rb1, rb2;
        int kr = 12;
       
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        //dimiourgia tou antikemenou cn gia thn syndesh
        public Form5(bool rb1,bool rb2)
        {
            InitializeComponent();
            connectionS = ConfigurationManager.ConnectionStrings["telikhergasia_allhlepidrash.Properties.Settings.Database1ConnectionString"].ConnectionString;
            this.rb1 = rb1; // bool gia eisodo ws customer/emplyee
            this.rb2 = rb2;
        }
        public void Books()
        {
            using (connection = new SqlConnection(connectionS)) //xrhs ths syndesh me thn vash
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM BOOKS", connection)) // epilogh olws thn stoixeiwn apo ton pinaka books ths vashs
            {
                connection.Open();
               
                adapter.Fill(bookstable); //eisoso twn epilegontwn stoixeiwn apo ton pinaka boos ths vashs sto datable
                Console.WriteLine(bookstable.Rows[0][1].ToString());

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;  //button gia na pas sto prohgoumeno vivliou kai meiwsh tou counter kata 1
            if (counter > 0)
            {
                counter = counter - 1;
            }
            Image image4 = images[counter];
            this.pictureBox1.Image = image4;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (counter == 8) //koumpi gia na pas sto epomeno vivlio me elegxo an einai ti teleftaio kai metavolh tou counter
                button2.Enabled = false;
            counter++;

            Image image4 = images[counter];
            this.pictureBox1.Image = image4;
            // next = true;

            numericUpDown1.Value = 0;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (rb1 == true) //sto load analoga to bool apo thn forma tou menu xrhsimopoioume to analogo groopbox
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                button3.Visible = false;
            }
            Books(); //kalesma ths synarthsh books kata to load 
            images[0] = Properties.Resources.book1; //eisagwgh olwn twn images ton pinaka
            images[1] = Properties.Resources.book2;
            images[2] = Properties.Resources.book3;
            //
            images[3] = Properties.Resources.book4;
            images[4] = Properties.Resources.book5;
            images[5] = Properties.Resources.book6;
            //
            images[6] = Properties.Resources.book7;
            images[7] = Properties.Resources.book8;
            images[8] = Properties.Resources.book9;
            images[9] = Properties.Resources.book10;
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bookstable.Rows[counter][1].ToString() + Environment.NewLine + bookstable.Rows[counter][2].ToString() + Environment.NewLine + bookstable.Rows[counter][3].ToString() + Environment.NewLine +"price: " +bookstable.Rows[counter][4].ToString());
            //mhnyma gia ta stoixeia kathe vivliou 
       
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                for (int z = 1; z <= numericUpDown1.Value; z++) //eisos tou epilegmenou vivliou sto kalathi agorwn sthn katallhlh posothta
                {
                    BooksToCart.Add(bookstable.Rows[counter][1].ToString());

                    totalBill = totalBill + Convert.ToDecimal(bookstable.Rows[counter][4].ToString());
                    MessageBox.Show("The book has benn added to your cart!");
                }
            }
            else
            {
                MessageBox.Show("Please enter quantity");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6(BooksToCart,totalBill); // anoigma tou kalathiou agorwn
            frm6.Show();
            
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Search")
                textBox1.Text ="";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool find = false; //diadikasia anazhths vivliou

            for (int y = 0; y <= 12; y++)
            {

                // MessageBox.Show(bookstable.Rows[x][1].ToString());
                if (textBox1.Text.ToString() == "name" + y)
                {
                    find = true;
                    Image image4 = images[y-1];
                    this.pictureBox1.Image = image4;
                    MessageBox.Show(bookstable.Rows[y-1][1].ToString() + Environment.NewLine + bookstable.Rows[y-1][2].ToString() + Environment.NewLine + bookstable.Rows[y-1][3].ToString());
                    break;
                }

            }
            
            if(find==false)
                MessageBox.Show("We don't have this book!");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string imageLocation = ""; // diadikasia eisagwghs eikonas gia to neo vivliou
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox2.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured.");
            }
        }
        private void UpdateData()
        {
            kr++; //diadika gia thn eisagwgh twn stoixeiwn tou neou vivliou sthn vash
            
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            
            SqlCommand Cmd = new SqlCommand("INSERT INTO BOOKS " +
        "(id, bookname, bookauthor, description, price) " +
                "VALUES(@ID, @bookname, @bookauthor, @description, @price)",
        Con);


            
            Cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@bookname", System.Data.SqlDbType.Char);
            Cmd.Parameters.Add("@bookauthor", System.Data.SqlDbType.Char);
            Cmd.Parameters.Add("@description", System.Data.SqlDbType.Char);
            Cmd.Parameters.Add("@price", System.Data.SqlDbType.Int);
            

            
            Cmd.Parameters["@ID"].Value = kr;
            Cmd.Parameters["@bookname"].Value = textBox2.Text;
            Cmd.Parameters["@bookauthor"].Value = textBox3.Text;
            Cmd.Parameters["@description"].Value = textBox4.Text;
            Cmd.Parameters["@price"].Value = Convert.ToInt32(textBox5.Text);

            
            Con.Open();

            
            int RowsAffected = Cmd.ExecuteNonQuery();
            MessageBox.Show("Saved syccesfully");

            
            Con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4(rb1,rb2); //button gia emfanish ths prohgoumenhs formas
            frm4.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible == true)
            {
                MessageBox.Show("Here you can see our book collection and buy whichever you want by adding to your cart.Also you can access your cart from the button 'CART', or go back from the button 'BACK'.");
            }else if (groupBox2.Visible==true)
            {
                MessageBox.Show("Here you can add a new book to our collection by giving the book's info.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox5.Text!= "" )
            {

                UpdateData();
            }
            else
            {
                MessageBox.Show("book name and price required!");
            }
            

        }
    }
}
