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
        //public static Form1 form1;
        //public ComboBox combo;
        public Form1()
        {
            InitializeComponent();
            //form1 = this;
            //combo = comboBox1;
        }
        public static string selecteditem;
        StreamWriter writer;
        StreamReader reader;
        //public delegate void DeliPackage(VacationPackage vacation);
        public delegate void Data(object obj, EventArgs e);
        private void Form1_Load(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                comboBox1.Text = "Options";
            if (comboBox2.SelectedIndex == -1)
                comboBox2.Text = "Options";
            if (comboBox3.SelectedIndex == -1)
                comboBox3.Text = "Options";
           
        }
        VacationPackage vacationSpots2 = new VacationPackage();
        List<VacationPackage> vacationList2 = new List<VacationPackage>();
        public static event Data SelectedChanged;
       
        public void addPackage(VacationPackage vacationPackage)
        {


            ///DO NOT DELETE!!!
            string path = @"TextFile2.txt";
            if (File.Exists(path))
                File.Delete(path);
            writer = File.CreateText(path);
            writer.WriteLine($"{vacationPackage.destination}, {vacationPackage.price}, {vacationPackage.tax}");
            writer.Close();
        }
        public void readPackage(List<VacationPackage> vacationPackages, VacationPackage vacation, TextBox txtSub, TextBox txtTax, TextBox txtTotal )
        {
            string path2 = @"TextFile3.txt";
            List<string> lines = File.ReadAllLines(path2).ToList();
           
            foreach(var s in lines)
            {
                string[] delim = s.Split(',');
                vacation.destination = delim[0];
                vacation.price = decimal.Parse(delim[1]);
                vacation.tax = decimal.Parse(delim[2]);
                vacationPackages.Add(vacation);

            }
            

            if (SelectedChanged != null)
            {
                
                ///DO NOT DELETE!!!
                txtSub.Text = vacation.price.ToString();
                txtTax.Text = vacation.tax.ToString();
                txtTotal.Text = (vacation.price + vacation.tax).ToString();
                //someFunc();
            }

        }

        public List<VacationPackage> vacationsList = new List<VacationPackage>();
        public void someFunc()
        {
            List<string> line = File.ReadAllLines("TextFile3.txt").ToList();
            foreach (var l in line)
            {
                string[] arr = l.Split(',');
                vacationSpots2.destination = arr[0];
                vacationSpots2.price = decimal.Parse(arr[1]);
                vacationSpots2.tax = decimal.Parse(arr[2]);
                vacationsList.Add(vacationSpots2);


            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                NotificationMessages.SceneryNotSelected("Beach");
                return;

            }
                
            if(radioButton1.Checked && comboBox1.SelectedIndex == 0)
            {
                VacationPackage surfing = new VacationPackage();
                surfing.destination = comboBox1.SelectedItem.ToString();
                surfing.price = 78.00m;
                surfing.tax = 5.36m;
                vacationList2.Add(surfing);
                addPackage(surfing);
                Form2 form2 = new Form2();
                form2.ShowDialog();
                if(SelectedChanged != null)
                {
                    readPackage(vacationList2, surfing, txtSub1, txtTax1, txtTotal1);
                  
                }
            }
            else if(radioButton1.Checked && comboBox1.SelectedIndex == 1)
            {
                VacationPackage ScubaDiving = new VacationPackage();
                ScubaDiving.destination = comboBox1.SelectedItem.ToString();
                ScubaDiving.price = 88.00m;
                ScubaDiving.tax = 6.05m;
                vacationList2.Add(ScubaDiving);
                addPackage(ScubaDiving);
                Form2 form2 = new Form2();
                form2.ShowDialog();
                if (SelectedChanged != null)
                {
                    readPackage(vacationList2, ScubaDiving, txtSub1, txtTax1, txtTotal1);
                    

                }
            }
            else 
            {
                VacationPackage JetSkiing = new VacationPackage();
                JetSkiing.destination = comboBox1.SelectedItem.ToString();
                JetSkiing.price = 135.00m;
                JetSkiing.tax = 9.28m;
                vacationList2.Add(JetSkiing);
                addPackage(JetSkiing);
                Form2 form2 = new Form2();
                form2.ShowDialog();
                if (SelectedChanged != null)
                {
                    readPackage(vacationList2, JetSkiing, txtSub1, txtTax1, txtTotal1);
                    

                }
            }
            
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!radioButton2.Checked)
            {
                NotificationMessages.SceneryNotSelected("Mountain");
                return;

            }
            if (radioButton2.Checked && comboBox2.SelectedIndex == 0)
            {

                VacationPackage Skiing = new VacationPackage();
                Skiing.destination = comboBox2.SelectedItem.ToString();
                Skiing.price = 118.68m;
                Skiing.tax = 8.16m;
                vacationList2.Add(Skiing);
                addPackage(Skiing);
                Form2 form2 = new Form2();
                form2.ShowDialog();
                if (SelectedChanged != null)
                {
                    readPackage(vacationList2, Skiing, txtSub2, txtTax2, txtTotal2);
                }

            }
            else if (radioButton2.Checked && comboBox2.SelectedIndex == 1)
            {
                VacationPackage HelicopterTour = new VacationPackage();
                HelicopterTour.destination = comboBox2.SelectedItem.ToString();
                HelicopterTour.price = 168.99m;
                HelicopterTour.tax = 11.62m;
                vacationList2.Add(HelicopterTour);
                addPackage(HelicopterTour);
                Form2 form2 = new Form2();
                form2.ShowDialog();
                if (SelectedChanged != null)
                {
                    readPackage(vacationList2, HelicopterTour, txtSub2, txtTax2, txtTotal2);
                }
            }
            else
            {
                VacationPackage SnowMobiling = new VacationPackage();
                SnowMobiling.destination = comboBox2.SelectedItem.ToString();
                SnowMobiling.price = 138.89m;
                SnowMobiling.tax = 9.55m;
                vacationList2.Add(SnowMobiling);
                addPackage(SnowMobiling);
                Form2 form2 = new Form2();
                form2.ShowDialog();
                if (SelectedChanged != null)
                {
                    readPackage(vacationList2, SnowMobiling, txtSub2, txtTax2, txtTotal2);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!radioButton3.Checked)
            {
                NotificationMessages.SceneryNotSelected("Desert");
                return;

            }
            if (radioButton3.Checked && comboBox3.SelectedIndex == 0)
            {

                VacationPackage HorseBackRiding = new VacationPackage();
                HorseBackRiding.destination = comboBox3.SelectedItem.ToString();
                HorseBackRiding.price = 68.99m;
                HorseBackRiding.tax = 4.74m;
                vacationList2.Add(HorseBackRiding);
                addPackage(HorseBackRiding);
                Form2 form2 = new Form2();
                form2.ShowDialog();
                if (SelectedChanged != null)
                {
                    readPackage(vacationList2, HorseBackRiding, txtSub3, txtTax3, txtTotal3);
                }

            }
            else if (radioButton3.Checked && comboBox3.SelectedIndex == 1)
            {
                VacationPackage WhiteWaterRafting = new VacationPackage();
                WhiteWaterRafting.destination = comboBox3.SelectedItem.ToString();
                WhiteWaterRafting.price = 88.99m;
                WhiteWaterRafting.tax = 6.12m;
                vacationList2.Add(WhiteWaterRafting);
                addPackage(WhiteWaterRafting);
                Form2 form2 = new Form2();
                form2.ShowDialog();
                if (SelectedChanged != null)
                {
                    readPackage(vacationList2, WhiteWaterRafting, txtSub3, txtTax3, txtTotal3);
                }
            }
            else
            {
                VacationPackage GuidedHike = new VacationPackage();
                GuidedHike.destination = comboBox3.SelectedItem.ToString();
                GuidedHike.price = 78.89m;
                GuidedHike.tax = 5.43m;
                vacationList2.Add(GuidedHike);
                addPackage(GuidedHike);
                Form2 form2 = new Form2();
                form2.ShowDialog();
                if (SelectedChanged != null)
                {
                    readPackage(vacationList2, GuidedHike, txtSub3, txtTax3, txtTotal3);
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
