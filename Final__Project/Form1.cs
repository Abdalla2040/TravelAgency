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
        string[] file = File.ReadAllLines("TextFile1.txt");
        List<decimal> cal = new List<decimal>();
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (!radioButton1.Checked)
            //  //  form5.ShowDialog();
            
            if(radioButton1.Checked && comboBox1.SelectedIndex > -1)
            {
                
                Form2 form2 = new Form2();
                selecteditem = comboBox1.SelectedItem.ToString();

                form2.ShowDialog();
                
                foreach (var s in file)
                {
                    decimal n = decimal.Parse(s);
                    cal.Add(n);
                    
                }
                for(int i = 0; i < cal.Count; i++)
                {
                    if(comboBox1.SelectedIndex == 0)
                    {
                        txtSub1.Text = cal[0].ToString("c");
                        txtTax1.Text = cal[1].ToString("c");
                        txtTotal1.Text = cal[2].ToString("c");
                        //form8.lblDest.Text = "Beaches";
                        //form8.lblPack.Text = "Surfing";
                    }
                    if(comboBox1.SelectedIndex == 1)
                    {
                        txtSub1.Text = cal[3].ToString("c");
                        txtTax1.Text = cal[4].ToString("c");
                        txtTotal1.Text = cal[5].ToString("c");
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        txtSub1.Text = cal[6].ToString("c");
                        txtTax1.Text = cal[7].ToString("c");
                        txtTotal1.Text = cal[8].ToString("c");
                    }

                }
 
            }

            
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!radioButton2.Checked)
                //form6.ShowDialog();
            //List<decimal> cal = new List<decimal>();
            if (radioButton2.Checked && comboBox2.SelectedIndex > -1)
            {
                Form2 form2 = new Form2();
                selecteditem = comboBox2.SelectedItem.ToString();
                form2.ShowDialog();

                foreach (var s in file)
                {
                    decimal n = decimal.Parse(s);
                    cal.Add(n);
                }

                for (int i = 0; i < cal.Count; i++)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        txtSub2.Text = cal[9].ToString("c");
                        txtTax2.Text = cal[10].ToString("c");
                        txtTotal2.Text = cal[11].ToString("c");
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        txtSub2.Text = cal[12].ToString("c");
                        txtTax2.Text = cal[13].ToString("c");
                        txtTotal2.Text = cal[14].ToString("c");
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        txtSub2.Text = cal[15].ToString("c");
                        txtTax2.Text = cal[16].ToString("c");
                        txtTotal2.Text = cal[17].ToString("c");
                    }
                }

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!radioButton3.Checked)
                    //form7.ShowDialog();
            //string[] file = File.ReadAllLines("TextFile1.txt");
            //List<decimal> cal = new List<decimal>();
            if (radioButton3.Checked && comboBox3.SelectedIndex > -1)
            {
                

                Form2 form2 = new Form2();
                selecteditem = comboBox3.SelectedItem.ToString();
                
                form2.ShowDialog();

                foreach (var s in file)
                {
                    decimal n = decimal.Parse(s);
                    cal.Add(n);

                }
                for (int i = 0; i < cal.Count; i++)
                {
                    if (comboBox3.SelectedIndex == 0)
                    {
                        txtSub3.Text = cal[18].ToString("c");
                        txtTax3.Text = cal[19].ToString("c");
                        txtTotal3.Text = cal[20].ToString("c");
                    }
                    if (comboBox3.SelectedIndex == 1)
                    {
                        txtSub3.Text = cal[21].ToString("c");
                        txtTax3.Text = cal[22].ToString("c");
                        txtTotal3.Text = cal[23].ToString("c");
                    }
                    if (comboBox3.SelectedIndex == 2)
                    {
                        txtSub3.Text = cal[24].ToString("c");
                        txtTax3.Text = cal[25].ToString("c");
                        txtTotal3.Text = cal[26].ToString("c");
                    }
                }

            }
        }
    }
}
