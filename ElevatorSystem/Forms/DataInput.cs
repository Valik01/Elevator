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
    public partial class DataInput : Form
    {
        public DataInput()
        {
            InitializeComponent();
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

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int numberFloor = 0, numberPerson = 0;

            if (IsDigitsOnly(textBox1.Text) && IsDigitsOnly(textBox2.Text))
            {
                numberFloor = Convert.ToInt32(textBox1.Text);
                numberPerson = Convert.ToInt32(textBox2.Text);
            }

            if (!IsDigitsOnly(textBox1.Text) || !IsDigitsOnly(textBox2.Text))
            {
                error.Text = "Неправильно введены данные";
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else {
                ((MainForm)this.Tag).setNumberOfPerson(numberPerson);
                ((MainForm)this.Tag).setNumberOfFloor(numberFloor);
               // ((MainForm)this.Tag).createBuild();
                this.Close();
            }
       
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
