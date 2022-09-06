using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CalcWorkTime
{
    public partial class EndDay : Form
    {
        public EndDay()
        {
            InitializeComponent();
            string tmp = "";
            for (int x = 0; x < 24; x++)
            {
                if (x.ToString().Length < 2)
                {
                    tmp = ("0" + x.ToString());
                }
                else
                {
                    tmp = (x.ToString());
                }
                comboBox1.Items.Add(tmp);
                comboBox3.Items.Add(tmp);
            }
            for (int x = 0; x < 60; x++)
            {
                if (x.ToString().Length < 2)
                {
                    tmp = ("0" + x.ToString());
                }
                else
                {
                    tmp = (x.ToString());
                }
                comboBox2.Items.Add(tmp);
                comboBox4.Items.Add(tmp);
            }
            comboBox1.Text = "08";
            comboBox2.Text = "45";
            comboBox3.Text = "01";
            comboBox4.Text = "00";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tmp;
            if (textBox2.Text.Contains(','))
            {
                tmp = "0123456789"+((char)8).ToString();
            }
            else
            {
                tmp = "0123456789," + ((char)8).ToString();
            }
            if (!tmp.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int h1;
            int m1;
            int h2;
            int m2;
            float worktime;
            string part1 = "";
            string part2 = "";
            h1 = Convert.ToInt32(comboBox1.Text);
            m1 = Convert.ToInt32(comboBox2.Text);
            h2 = Convert.ToInt32(comboBox3.Text);
            m2 = Convert.ToInt32(comboBox4.Text);
            if (float.TryParse(textBox2.Text, out worktime))
            {
                worktime=h1 * 60 + m1 + h2 * 60 + m2 + worktime * 60;
                part1 = ((worktime - worktime % 60) / 60).ToString();
                part2 = System.Math.Round((worktime % 60),0).ToString();
                while (int.Parse(part1) >= 24) part1 = (int.Parse(part1) - 24).ToString();
                while (part1.Length < 2) part1 = "0" + part1;
                while (part2.Length < 2) part2 = "0" + part2;
                textBox3.Text = part1+ ":" + part2;
            }
            else
            {
                MessageBox.Show("Ошибка ввода рабочего времени!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
