using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DSS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e)
        {
            int constraintsCount = int.Parse(textBox3.Text);
            int variablesCount = int.Parse(textBox1.Text);
            this.dataGridView1.RowCount = variablesCount;
            this.dataGridView1.ColumnCount = constraintsCount;
            this.dataGridView2.RowCount = variablesCount;
            this.dataGridView2.ColumnCount = constraintsCount + 1;
            for (int i = 0; i <= constraintsCount; i++)
            {
                int c = i + 1;
                if (i < constraintsCount)
                {
                    dataGridView1.Columns[i].HeaderText = "Condition " + c;
                    dataGridView2.Columns[i].HeaderText = "Condition " + c;
                }
                else
                {
                    dataGridView2.Columns[i].HeaderText = "Chosen Values";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = label5.Text = "";
            int constraintsCount = int.Parse(textBox3.Text);
            int variablesCount = int.Parse(textBox1.Text);
            for (int i = 0; i < variablesCount; i++)
            {
                double max_val = -99999999;
                for (int j = 0; j <= constraintsCount; j++)
                {
                    if (j < constraintsCount)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j].Value;
                        double valu = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                        if (valu > max_val)
                        {
                            max_val = valu;
                        }
                    }
                    if (j == constraintsCount)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = max_val.ToString();
                    }

                }
                max_val = -99999999;
            }
            double maxx = -99999999;
            for (int i = 0; i < variablesCount; i++)
            {
                double valu = Convert.ToDouble(dataGridView2.Rows[i].Cells[constraintsCount].Value);
                if (valu > maxx)
                {
                    maxx = valu;
                    int num = i + 1;
                    label2.Text = "Maximax chose project number " + num;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = label5.Text = "";
            int constraintsCount = int.Parse(textBox3.Text);
            int variablesCount = int.Parse(textBox1.Text);
            for (int i = 0; i < variablesCount; i++)
            {
                double min_val = 99999999;
                for (int j = 0; j <= constraintsCount; j++)
                {
                    if (j < constraintsCount)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j].Value;
                        double valu = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                        if (valu < min_val)
                        {
                            min_val = valu;
                        }
                    }
                    if (j == constraintsCount)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = min_val.ToString();
                    }

                }
                min_val = 99999999;
            }
            double maxx = -99999999;
            for (int i = 0; i < variablesCount; i++)
            {
                double valu = Convert.ToDouble(dataGridView2.Rows[i].Cells[constraintsCount].Value);
                if (valu > maxx)
                {
                    maxx = valu;
                    int num = i + 1;
                    label2.Text = "Maximin chose project number " + num;
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = label5.Text = "";
            int constraintsCount = int.Parse(textBox3.Text);
            int variablesCount = int.Parse(textBox1.Text);
            for (int i = 0; i < constraintsCount; i++)
            {
                double max = -9999999;
                for (int j = 0; j < variablesCount; j++)
                {
                    double valu = Convert.ToDouble(dataGridView1.Rows[j].Cells[i].Value);
                    if (valu > max)
                    {
                        max = valu;
                    }
                }
                for (int j = 0; j < variablesCount; j++)
                {
                    double valu = Convert.ToDouble(dataGridView1.Rows[j].Cells[i].Value);
                    valu = max - valu;
                    dataGridView2.Rows[j].Cells[i].Value = valu;
                }
            }
            for (int i = 0; i < variablesCount; i++)
            {
                double max_val = -99999999;
                for (int j = 0; j <= constraintsCount; j++)
                {
                    if (j < constraintsCount)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = dataGridView2.Rows[i].Cells[j].Value;
                        double valu = Convert.ToDouble(dataGridView2.Rows[i].Cells[j].Value);
                        if (valu > max_val)
                        {
                            max_val = valu;
                        }
                    }
                    if (j == constraintsCount)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = max_val.ToString();
                    }

                }
                max_val = -99999999;
            }
            double min = 99999999;
            for (int i = 0; i < variablesCount; i++)
            {
                double valu = Convert.ToDouble(dataGridView2.Rows[i].Cells[constraintsCount].Value);
                if (valu < min)
                {
                    min = valu;
                    int num = i + 1;
                    label5.Text = "Mini max regret chose project number " + num;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = label5.Text = "";
            int constraintsCount = int.Parse(textBox3.Text);
            int variablesCount = int.Parse(textBox1.Text);
            for (int i = 0; i < variablesCount; i++)
            {
                for (int j = 0; j < constraintsCount; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            for (int i = 0; i < variablesCount; i++)
            {
                double emv = 0;
                for (int j = 0; j <= constraintsCount; j++)
                {
                    if (j < constraintsCount)
                    {
                        double valu = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                        double prob = Convert.ToDouble(dataGridView1.Rows[variablesCount].Cells[j].Value);
                        emv=emv+(valu*prob);
                    }
                    if (j == constraintsCount)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = emv.ToString();
                    }

                }
                emv = 0;
            }
            double maxx = -99999999;
            for (int i = 0; i < variablesCount; i++)
            {
                double valu = Convert.ToDouble(dataGridView2.Rows[i].Cells[constraintsCount].Value);
                if (valu > maxx)
                {
                    maxx = valu;
                    int num = i + 1;
                    label2.Text = "EMV chose project number " + num;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label2.Text = label5.Text = "";
            int constraintsCount = int.Parse(textBox3.Text);
            int variablesCount = int.Parse(textBox1.Text);
            for (int i = 0; i < constraintsCount; i++)
            {
                double max = -9999999;
                for (int j = 0; j < variablesCount; j++)
                {
                    double valu = Convert.ToDouble(dataGridView1.Rows[j].Cells[i].Value);
                    if (valu > max)
                    {
                        max = valu;
                    }
                }
                for (int j = 0; j < variablesCount; j++)
                {
                    double valu = Convert.ToDouble(dataGridView1.Rows[j].Cells[i].Value);
                    valu = max - valu;
                    dataGridView2.Rows[j].Cells[i].Value = valu;
                }
            }
            for (int i = 0; i < variablesCount; i++)
            {
                double eol = 0;
                for (int j = 0; j <= constraintsCount; j++)
                {
                    if (j < constraintsCount)
                    {
                        double valu = Convert.ToDouble(dataGridView2.Rows[i].Cells[j].Value);
                        double prob = Convert.ToDouble(dataGridView1.Rows[variablesCount].Cells[j].Value);
                        eol = eol + (valu * prob);
                    }
                    if (j == constraintsCount)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = eol.ToString();
                    }

                }
                eol = 0;
            }

            double min = 99999999;
            for (int i = 0; i < variablesCount; i++)
            {
                double valu = Convert.ToDouble(dataGridView2.Rows[i].Cells[constraintsCount].Value);
                if (valu < min)
                {
                    min = valu;
                    int num = i + 1;
                    label5.Text = "EOL chose project number " + num;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Text = label5.Text = "";
            int constraintsCount = int.Parse(textBox3.Text);
            int variablesCount = int.Parse(textBox1.Text);
            for (int i = 0; i < variablesCount; i++)
            {
                double sum = 0;
                for (int j = 0; j <= constraintsCount; j++)
                {
                    if (j < constraintsCount)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j].Value;
                        double valu = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                        sum += valu;
                    }
                    if (j == constraintsCount)
                    {
                        sum = sum / constraintsCount;
                        dataGridView2.Rows[i].Cells[j].Value = sum.ToString();
                    }

                }
                sum = 0;
            }
            double maxx = -99999999;
            for (int i = 0; i < variablesCount; i++)
            {
                double valu = Convert.ToDouble(dataGridView2.Rows[i].Cells[constraintsCount].Value);
                if (valu > maxx)
                {
                    maxx = valu;
                    int num = i + 1;
                    label5.Text = "Equally like chose project number " + num;
                }
            }
        }
    }
}
