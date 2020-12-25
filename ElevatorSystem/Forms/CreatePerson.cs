using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorSystem
{
    public partial class CreatePerson : Form
    {
        private int firstFloor;
        private int endFloor;
        private int weight;

        public CreatePerson()
        {
            InitializeComponent();
            firstFloor = 0;
            endFloor = 0;
            weight = 0;
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (IsDigitsOnly(textBox1.Text) && IsDigitsOnly(textBox2.Text) && IsDigitsOnly(textBox3.Text))
            {
                firstFloor = Convert.ToInt32(textBox1.Text);
                endFloor = Convert.ToInt32(textBox2.Text);
                weight = Convert.ToInt32(textBox3.Text);
            }

            if (!IsDigitsOnly(textBox1.Text) || !IsDigitsOnly(textBox2.Text) || !IsDigitsOnly(textBox3.Text))
            {
                label3.Text = "Данные введены неверно!";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else {
                this.Close();
            }    
        }

        public int FirstFloor { 
            get {
                return firstFloor;
            }
        }

        public int EndFloor
        {
            get
            {
                return endFloor;
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
