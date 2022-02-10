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
        //string itemsToCollect = Form1.selecteditem + "\n";
        List<string> list = new List<string>();
        StreamReader reader;
            
           
            
        Form1 form1 = new Form1();
        //Form8 form8 = new Form8();
        public List<string> coll = new List<string>();
        //DataSet1TableAdapters.CalculationsTableAdapter cal = new DataSet1TableAdapters.CalculationsTableAdapter();
        


        private void btnAdd_Click(object sender, EventArgs e)
        {
            // reader = File.OpenText(@"TextFile2.txt");
            //int length = list.Count-1;
            //foreach(string item in list)
            //    listBox1.Items.Add(item);
            //listBox1.Items.Add(list[length]);
            foreach (string item in list)
                listBox1.Items.Add(item);







        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Form1.selecteditem + "\n");
            //string path = @"TextFile2.txt";
            //File.WriteAllText(path, itemsToCollect);
            // //string[] file2 = File.WriteAllLines(path, itemsList)
            //File.AppendAllText(path, Form1.selecteditem + "\n");
            //string[] file = File.ReadAllLines(path);
            //foreach(var n in file)
            //    listBox1.Items.Add(n);
            reader = File.OpenText(@"TextFile2.txt");
            while (!reader.EndOfStream)
            {
                
                list.Add(reader.ReadLine());
                //
                //for(int i = 0; i < length; i++)
                //{
                //    listBox1.Items.Add(list[i]);
                //}
                
                
            }
            reader.Close();
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
            if (form1.radioButton1.Checked)
            {
                MessageBox.Show("yes");
                //form8.lblDest.Text = "Beach";
                
                //form8.lblPack.Text = "Surfing";
                

                
                    
            }
            else if (form1.radioButton2.Checked)
            {
                //form8.lblDest.Text = "Mountains";

            }
            if (form1.radioButton3.Checked)
            {
                //form8.lblDest.Text = "Desert";

            }
            //form8.ShowDialog();

            
        }
    }
}
