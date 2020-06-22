using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queue
{
    public partial class Sberbank : Form
    {
        int number = 1;
        int max_time_1 = 90;
        int max_time_2 = 60;
        int max_time_3 = 30;
        int time_1, time_2, time_3;

        Queue<int> queue1 = new Queue<int>(100);
        Queue<int> queue2 = new Queue<int>(100);
        Queue<int> queue3 = new Queue<int>(100);

        Random rnd = new Random();

        public Sberbank()
        {
            InitializeComponent();
        }

        private void Sberbank_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time_1 > 0)
                time_1 -= 1 * trackBar1.Value;
            if (time_1 < 0)
                time_1 = 0;
            if (time_2 > 0)
                time_2 -= 1 * trackBar1.Value;
            if (time_2 < 0)
                time_2 = 0;
            if (time_3 > 0)
                time_3 -= 1 * trackBar1.Value;
            if (time_3 < 0)
                time_3 = 0;
            if (time_1 <= 0)
            {
                if (!queue1.IsEmpty)
                {
                    textBox1.Text = queue1.Pop().ToString();
                    listBox1.Items.Remove("Клиент №" + textBox1.Text + " - очередь 1");
                    time_1 = max_time_1;
                }
                else
                {
                    textBox1.Text = "";
                    label1.Text = "00:00";
                }
                    
            }
            if (time_2 <= 0)
            {
                if (!queue2.IsEmpty)
                {
                    textBox2.Text = queue2.Pop().ToString();
                    listBox1.Items.Remove("Клиент №" + textBox2.Text + " - очередь 2");
                    time_2 = max_time_2;
                }
                else
                {
                    textBox2.Text = "";
                    label2.Text = "00:00";
                }
            }
            if (time_3 <= 0)
            {
                if (!queue3.IsEmpty)
                {
                    textBox3.Text = queue3.Pop().ToString();
                    listBox1.Items.Remove("Клиент №" + textBox3.Text + " - очередь 3");
                    time_3 = max_time_3;
                }
                else
                {
                    textBox3.Text = "";
                    label3.Text = "00:00";
                }
                    
            }
            label1.Text = TimeConvert(time_1);
            label2.Text = TimeConvert(time_2);
            label3.Text = TimeConvert(time_3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            queue1.Push(number);
            listBox1.Items.Add("Клиент №" + number + " - очередь 1");
            number++;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            queue2.Push(number);
            listBox1.Items.Add("Клиент №" + number + " - очередь 2");
            number++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            queue3.Push(number);
            listBox1.Items.Add("Клиент №" + number + " - очередь 3");
            number++;
        }

        private string TimeConvert(int value)
        {
            return $"{value / 60 / 10}{value / 60 % 10}:" +
                $"{value % 60 / 10}{value % 60 % 10}";
        }
    }
}
