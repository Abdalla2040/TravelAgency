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

namespace Final__Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string selecteditem;
        StreamWriter writer;
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Calculations' table. You can move, or remove it, as needed.
           
            if (comboBox1.SelectedIndex == -1)
                comboBox1.Text = "Options";
            if (comboBox2.SelectedIndex == -1)
                comboBox2.Text = "Options";
            if (comboBox3.SelectedIndex == -1)
                comboBox3.Text = "Options";
            

            
        }
        //string[] file = File.ReadAllLines("TextFile1.txt");
        List<decimal> cal = new List<decimal>();
        
        public void comboSelector(ComboBox combo)
        {
            Form2 form2 = new Form2();
            writer = File.AppendText(@"TextFile2.txt");
            writer.WriteLine(combo.Text);
            writer.Close();
            form2.ShowDialog();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked && comboBox1.SelectedIndex > -1)
            {
                comboSelector(comboBox1);
            }
            
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked && comboBox2.SelectedIndex > -1)
            {
                comboSelector(comboBox2);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked && comboBox3.SelectedIndex > -1)
            {
                comboSelector(comboBox3);
            }
        }
    }
}
