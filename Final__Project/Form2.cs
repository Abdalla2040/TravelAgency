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
                    writer.WriteLine($"{vacationList[i].destination}, {vacationList[i].price}, {vacationList[i].tax}");
                    vacationSpots2.destination = vacationList[i].destination;
                    vacationSpots2.price = vacationList[i].price;
                    vacationSpots2.tax = vacationList[i].tax;
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
            foreach (var s in selectedPackages)
                    MessageBox.Show($"{s.destination}, {s.price}, {s.tax}");
            reader = File.OpenText(path);
            while (!reader.EndOfStream)
            {
                string[] delimiter = reader.ReadLine().Split(',');
                vacationSpots.destination = delimiter[0];
                vacationSpots.price = decimal.Parse(delimiter[1]);
                vacationSpots.tax = decimal.Parse(delimiter[2]);
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
                listBox1.Items.Add(vacationSpots2.destination);
            }
            reader.Close();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1.backButtonChanged += new EventHandler(btnBack_Click);
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (NotificationMessages.Deletion() == DialogResult.Yes)
            {
                var deletedItem = listBox1.SelectedItem;
                var delete = listBox1.SelectedIndex;
                listBox1.Items.Remove(deletedItem);
                VacationPackage package = new VacationPackage();
                temp.Clear();
                List<string> lineToRemove = File.ReadAllLines(path2).Where(arg =>
                                !string.IsNullOrWhiteSpace(arg)).ToList();
                lineToRemove.RemoveAll(x => x.Split(',')[0].Equals(deletedItem));
                File.WriteAllLines(@"TextFile3.txt", lineToRemove);
                
            }
            else
            {
                return;
            }
            Form1.backButtonChanged += new EventHandler(btnDelete_Click);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
