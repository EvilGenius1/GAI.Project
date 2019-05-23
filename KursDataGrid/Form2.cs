using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
//using System.Data.Entity;

namespace KursDataGrid
{
    public partial class Form2 : Form
    {
        GAI g = new GAI();
        public char[] choosenCar = new char[8];
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                g.carNumber = textBox1.Text;
                g.count = dataGridView1.RowCount;
                g.mark = textBox2.Text;
                g.regYear = Convert.ToInt32(textBox3.Text);
                if (g.regYear < 1919)
                {
                    g.regYear = 2019;
                }
                g.color = textBox5.Text;
                g.threeN = textBox6.Text;
                g.homeAdress = textBox4.Text;
                
            }
            catch (System.FormatException)
            {
                g.carNumber = "01";
                g.mark = "01";
                g.threeN = "01";

                g.color = "01";
                g.regYear = 1999;
                g.homeAdress = "0";
            }
            dataGridView1.Rows.Add(g.count, g.carNumber.ToUpper(),  g.mark, g.regYear, g.color, g.threeN, g.homeAdress);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string trueRegisterNumber = textBox7.Text;

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (String.Equals(trueRegisterNumber, dataGridView1.Rows[i].Cells[0]))
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                    else
                    {

                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream mystr = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((mystr = openFileDialog1.OpenFile()) != null)
                {
                    StreamReader myread = new StreamReader(mystr);
                    string[] str;
                    int num = 0;
                    try
                    {
                        string[] str1 = myread.ReadToEnd().Split('\n');
                        num = str1.Count();
                        dataGridView1.RowCount = num;
                        for(int i = 0; i < num; i++)
                        {
                            str = str1[i].Split(' ');
                            for(int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                try
                                {
                                    dataGridView1.Rows[i].Cells[j].Value = str[j];
                                }
                                catch
                                { }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myread.Close();
                    }
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 s = new Form3();
            s.Show();
            this.Hide();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter myWriter = new StreamWriter(myStream);
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++) {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                myWriter.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + " ");
                            }
                            myWriter.WriteLine();
                        }
                    } catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myWriter.Close();
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string choosenOneColor = textBox8.Text;
            for(int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for(int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (String.Equals(choosenOneColor, dataGridView1.Rows[i].Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("# " + dataGridView1.RowCount + ".Registration car number, mark and reliased year: " + dataGridView1.Rows[i].Cells[0].Value + " " + dataGridView1.Rows[i].Cells[1].Value + " and " + dataGridView1.Rows[i].Cells[2].Value + ". \n" + "Color, person and his home adress: " + dataGridView1.Rows[i].Cells[3].Value + ", " + dataGridView1.Rows[i].Cells[4].Value + " and  " + dataGridView1.Rows[i].Cells[5].Value);
                        break;
                    }
                }
            }
        }//

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string choosenOneMark = textBox9.Text; 

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (String.Equals(choosenOneMark, dataGridView1.Rows[i].Cells[2].Value.ToString()))
                    {
                        MessageBox.Show("# " + dataGridView1.RowCount + ".Registration car number, mark and reliased year: " + dataGridView1.Rows[i].Cells[0].Value + " " + dataGridView1.Rows[i].Cells[1].Value + " and " + dataGridView1.Rows[i].Cells[2].Value + ". \n" + "Color, person and his home adress: " + dataGridView1.Rows[i].Cells[3].Value + ", " + dataGridView1.Rows[i].Cells[4].Value + " and  " + dataGridView1.Rows[i].Cells[5].Value);
                        break;
                    }
                }
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            g.choosenCar = textBox10.Text;
            Regex regex = new Regex(choosenCar + @"(\w*)");
            
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for(int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    MatchCollection matches = regex.Matches(g.choosenCar);
                    if (matches.Count > 0)
                    {
                        MessageBox.Show("# " + dataGridView1.RowCount + ".Registration car number, mark and reliased year: " + dataGridView1.Rows[i].Cells[0].Value + " " + dataGridView1.Rows[i].Cells[1].Value + " and " + dataGridView1.Rows[i].Cells[2].Value + ". \n" + "Color, person and his home adress: " + dataGridView1.Rows[i].Cells[3].Value + ", " + dataGridView1.Rows[i].Cells[4].Value + " and  " + dataGridView1.Rows[i].Cells[5].Value);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Совпадений не найдено");
                    }
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
