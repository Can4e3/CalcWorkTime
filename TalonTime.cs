using System;
using System.Windows.Forms;

namespace CalcWorkTime
{
    public partial class TalonTime : Form
    {
        public TalonTime()
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
                comboBox5.Items.Add(tmp);
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
                comboBox6.Items.Add(tmp);
            }
            comboBox1.Text = "08";
            comboBox2.Text = "45";
            comboBox3.Text = "18";
            comboBox4.Text = "00";
            comboBox5.Text = "01";
            comboBox6.Text = "00";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int h1 = 0;
            int h2 = 0;
            int h3 = 0;
            int m1 = 0;
            int m2 = 0;
            int m3 = 0;
            float t1 = 0;
            float t2 = 0;
            float t3 = 0;
            bool result=false;
            int resH = 0;
            int resM = 0;
            float resT = 0;
            
            h1 = Convert.ToInt32(comboBox1.Text);
            m1 = Convert.ToInt32(comboBox2.Text);
            h2 = Convert.ToInt32(comboBox3.Text);
            m2 = Convert.ToInt32(comboBox4.Text);
            h3 = Convert.ToInt32(comboBox5.Text);
            m3 = Convert.ToInt32(comboBox6.Text);
            t1 = (float)h1 + (float)m1 / 60;
            t2 = (float)h2 + ((float)m2 / 60);
            t3 = (float)h3 + (float)m3 / 60;
            if (t2 - t1 > 0)
            {
                if (t2 - t1 - t3 > 0)
                {
                    resH = h2 - h1 - h3;
                    resM = m2 - m1 - m3;
                    while (resM < 0)
                    {
                        resH -= 1;
                        resM += 60;
                    }
                    resT = (float)resH + ((float)resM / 60);
                    result = true;
                }
                else
                {
                    MessageBox.Show("Обеденный перерыв превышает время нахождения на работе, проверьте введенные данные!");
                    result = false;
                }
            }
            else
            {
                MessageBox.Show("Время выхода на работу должно предшествовать времени ухода с работы!");
                result = false;
            }

            if (result)
            {
                textBox2.Text = resT.ToString();
                textBox3.Text = Math.Round(resT, 2).ToString();
            }
        }
    }
}
