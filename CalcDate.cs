using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CalcWorkTime
{
    public partial class CalcDate : Form
    {
        public CalcDate()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            Action();
        }
        private bool EnterInt(char symbol)
        {
            bool result = false;
            string tmp;
            tmp = "0123456789" + ((char)8).ToString();
            if (tmp.Contains(symbol)) 
                result = true;
            return result;
        }
        private void Action()
        {
            int yyyy = 0;
            int mm = 0;
            int dd = 0;
            if (textBox1.Text != "") yyyy = int.Parse(textBox1.Text);
            if (textBox2.Text != "") mm = int.Parse(textBox2.Text);
            if (textBox3.Text != "") dd = int.Parse(textBox3.Text);
            DateTime date;
            date = dateTimePicker1.Value;
            date = date.AddYears(yyyy);
            date = date.AddMonths(mm);
            date = date.AddDays(dd);
            textBox4.Text = date.ToLongDateString();
        }
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !EnterInt(e.KeyChar);
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !EnterInt(e.KeyChar);
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !EnterInt(e.KeyChar);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Action();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Action();
        }
    }
}
