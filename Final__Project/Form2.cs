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
        //public static Form2 form2;
        //public ListBox listbox;
        public Form2()
        {
            InitializeComponent();
            //form2 = this;
            //listbox = listBox1;
        }
        
        string path = @"TextFile2.txt";
        string path2 = @"TextFile3.txt";
        StreamReader reader;
        StreamWriter writer;
        List<VacationPackage> vacationList = new List<VacationPackage>();
        VacationPackage vacationSpots = new VacationPackage();
        VacationPackage vacationSpots2 = new VacationPackage();
        List<VacationPackage> temp = new List<VacationPackage>();
        List<VacationPackage> selectedPackages = new List<VacationPackage>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ///DO NOT DELETE!!!
            for (int i = 0; i <= vacationList.Count; i++)
            {
                if (i == vacationList.Count - 1)
                {
                    writer = File.AppendText(path2);
                    writer.WriteLine($"{vacationList[i].destination}, {vacationList[i].price}, {vacationList[i].tax}, {vacationList[i].total}, {vacationList[i].scenery}");
                    vacationSpots2.destination = vacationList[i].destination;
                    vacationSpots2.price = vacationList[i].price;
                    vacationSpots2.tax = vacationList[i].tax;
                    vacationSpots2.total = vacationList[i].total;
                    vacationSpots2.scenery = vacationList[i].scenery;
                    temp.Add(vacationSpots2);
                    selectedPackages.Add(vacationSpots2);
                    writer.Close();
                    listBox1.Items.Add(vacationList[i].destination);

                }
            }
            Form1.SelectedChanged += new EventHandler(btnAdd_Click);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //foreach (var s in selectedPackages)
            //        MessageBox.Show($"{s.destination}, {s.price}, {s.tax}");
            reader = File.OpenText(path);
            while (!reader.EndOfStream)
            {
                string[] delimiter = reader.ReadLine().Split(',');
                //foreach (var s in delimiter)
                //    MessageBox.Show($"{s}");
                vacationSpots.destination = delimiter[0];
                vacationSpots.price = decimal.Parse(delimiter[1]);
                vacationSpots.tax = decimal.Parse(delimiter[2]);
                vacationSpots.total = decimal.Parse(delimiter[3]);
                vacationSpots.scenery = delimiter[4];
                vacationList.Add(vacationSpots);
            }
            reader.Close();
            
                reader = File.OpenText(path2);
            while (!reader.EndOfStream)
            {
                string[] delim = reader.ReadLine().Split(',');
                vacationSpots2.destination = delim[0];
                vacationSpots2.price = decimal.Parse(delim[1]);
                vacationSpots2.tax = decimal.Parse(delim[2]);
                vacationSpots2.total = decimal.Parse(delim[3]);
                vacationSpots2.scenery = delim[4];
                listBox1.Items.Add(vacationSpots2.destination);
            }
            reader.Close();

        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            //Form1 form1 = new Form1();
            //Form1.PackCal pack = form1.PackageCalculations;
            //pack();
            //System.Diagnostics.Debug.Write(pack);
            //form1.backButtonChanged += form1.PackageCalculations;
            // Form1.backButtonChanged += refreshData;
            // var data = RefreshData();
            //foreach(var s in data)
            // {
            //     MessageBox.Show($"{s.destination}, {s.price}, {s.tax}");
            // }
            //var lines = File.ReadAllLines(path2).ToList();
            //foreach(var s in lines)
            //{
            //    string[] strArray = s.Split(',');
            Form1 form1 = new Form1();
            Form1.backButtonChanged += new Form1.PackCal(form1.PackageCalculations);
            //}
            
            this.Close();
        }
      

        public void RefreshData()
        {
            List<VacationPackage> whatsLeft = new List<VacationPackage>();
            if (NotificationMessages.Deletion() == DialogResult.Yes && listBox1.Items.Count > 0)
            {
                var deletedItem = listBox1.SelectedItem;
                var delete = listBox1.SelectedIndex;
                listBox1.Items.Remove(deletedItem);
                VacationPackage package = new VacationPackage();
                temp.Clear();
                List<string> lineToRemove = File.ReadAllLines(path2).Where(arg =>
                                !string.IsNullOrWhiteSpace(arg)).ToList();
                lineToRemove.RemoveAll(x => x.Split(',')[0].Equals(deletedItem));
                //foreach (var s in lineToRemove) 
                //{
                //    string[] strArray = s.Split(',');
                //    package.destination = strArray[0];
                //    package.price = decimal.Parse(strArray[1]);
                //    package.tax = decimal.Parse(strArray[2]);
                //    whatsLeft.Add(package);
                //}

                File.WriteAllLines(@"TextFile3.txt", lineToRemove);
                NotificationMessages.recordDeleted();
                
                this.Close();
               
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Form1.PackCal pack = refreshData;
            //pack();
            //Form1 form1 = new Form1();
            RefreshData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
