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
using System.Data.SqlClient;

namespace Final__Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string path = @"TextFile2.txt";
        List<string> list = new List<string>();
        StreamReader reader;
       
        


        private void btnAdd_Click(object sender, EventArgs e)
        {
            // reader = File.OpenText(@"TextFile2.txt");
            //int length = list.Count-1;
            //foreach(string item in list)
            //    listBox1.Items.Add(item);
            //listBox1.Items.Add(list[length]);
            foreach (string item in list)
            {
                string lastItem = list[list.Count - 1];
                if (item == list[list.Count - 1])
                {
                    if (listBox1.Items.Contains(lastItem))
                    {
                        MessageBox.Show("Item already in the list");
                        return;

                    }

                    listBox1.Items.Add(lastItem);

                    
                }
                 
            }








        }

        private void Form2_Load(object sender, EventArgs e)
        {
            reader = File.OpenText(@"TextFile2.txt");
            while (!reader.EndOfStream)
            {
                
                list.Add(reader.ReadLine());
                
            }
            reader.Close();
            foreach(string item in list)
            {
                if(list[list.Count - 1] != item)
                    listBox1.Items.Add(item);
            }
            //int length = list.Count - 1;
            
            //if (list.Count < length)
            //    
         
                
            

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (form1.radioButton1.Checked)
            //{
            //    MessageBox.Show("yes");
            //    //form8.lblDest.Text = "Beach";
                
            //    //form8.lblPack.Text = "Surfing";
                

                
                    
            //}
            //else if (form1.radioButton2.Checked)
            //{
            //    //form8.lblDest.Text = "Mountains";

            //}
            //if (form1.radioButton3.Checked)
            //{
            //    //form8.lblDest.Text = "Desert";

            //}
            //form8.ShowDialog();

            
        }
    }
}
