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
    public partial class Form1 : Form
    {
        Queue<char> queue;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    queue = new Queue<char>(Convert.ToInt32(textBox1.Text));
                    panel1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                queue.Push(Convert.ToChar(textBox2.Text));
            }
            catch(QueueOverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = queue.Pop().ToString();
            }
            catch (QueueEmptyException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = !textBox1.Enabled;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = queue.Top.ToString();
            }
            catch (QueueEmptyException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (queue.IsEmpty)
                MessageBox.Show("Очередь пуста");
            else
                MessageBox.Show("Очередь не пуста");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            queue.Clear();
            MessageBox.Show("Очередь очищена");
        }

        
        private void button7_Click(object sender, EventArgs e)
        {
            new Sberbank().ShowDialog();
        }
    }
}
