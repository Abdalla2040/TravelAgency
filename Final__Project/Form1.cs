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
            if (comboBox1.SelectedIndex == -1)
                comboBox1.Text = "Options";
            if (comboBox2.SelectedIndex == -1)
                comboBox2.Text = "Options";
            if (comboBox3.SelectedIndex == -1)
                comboBox3.Text = "Options";

             PackageCalculations();



        }
        public delegate void PackCal(object sender, EventArgs e);

        public void PackageCalculations()
        {

            if (readPackage() != null)
            {
                string name = "";
                decimal price = 0m;
                decimal tax = 0m;
                var data = readPackage();
                foreach (var vac in data)
                {
                    name = vac.destination;
                    price = vac.price;
                    tax = vac.tax;

                    if (name.Contains("Surfing") || name.Contains("Scuba") || name.Contains("Jet"))
                    {
                        decimal sub1 = data.Sum(x => x.price);
                        txtSub1.Text = sub1.ToString("C");
                        decimal tax1 = data.Sum(x => x.tax);
                        txtTax1.Text = tax1.ToString("C");
                        txtTotal1.Text = (sub1 + tax1).ToString("C");
                    }
                }
            }
            
                
        }

        public static event EventHandler SelectedChanged;
        public static event EventHandler backButtonChanged;
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
       
        public List<VacationPackage> readPackage()
        {
            List<VacationPackage> vacationList3 = new List<VacationPackage>();
            string path2 = @"TextFile3.txt";
            
            var lines = File.ReadAllLines(path2).ToList();

            for(int i = 0; i < lines.Count; i++)
            {
                VacationPackage vacation = new VacationPackage();
                var s = lines[i].Split(',');
                vacation.destination = s[0];
                vacation.price = decimal.Parse(s[1]);
                vacation.tax = decimal.Parse(s[2]);
                vacationList3.Add(vacation);
            }
            return vacationList3;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<VacationPackage> vacationList2 = new List<VacationPackage>();
            
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
                addPackage(surfing);
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            else if(radioButton1.Checked && comboBox1.SelectedIndex == 1)
            {
                VacationPackage ScubaDiving = new VacationPackage();
                ScubaDiving.destination = comboBox1.SelectedItem.ToString();
                ScubaDiving.price = 88.00m;
                ScubaDiving.tax = 6.05m;
                addPackage(ScubaDiving);
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            else 
            {
                VacationPackage JetSkiing = new VacationPackage();
                JetSkiing.destination = comboBox1.SelectedItem.ToString();
                JetSkiing.price = 135.00m;
                JetSkiing.tax = 9.28m;
                addPackage(JetSkiing);
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            if (SelectedChanged != null)
            {
                var selectedVacationPackage = readPackage();
                txtSub1.Text = selectedVacationPackage.Sum(x => x.price).ToString();
            }
            //if (backButtonChanged != null)
            //{
            //    PackageCalculations();

            //}
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<VacationPackage> vacationList2 = new List<VacationPackage>();
            vacationList2.Clear();
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
                    txtTotal2.Text = (decimal.Parse(txtSub1.Text) + decimal.Parse(txtTax1.Text)).ToString();
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
                   // readPackage(vacationList2, HelicopterTour, txtSub2, txtTax2, txtTotal2);
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
                   // readPackage(vacationList2, SnowMobiling, txtSub2, txtTax2, txtTotal2);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<VacationPackage> vacationList2 = new List<VacationPackage>();
            vacationList2.Clear();
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
                   // readPackage(vacationList2, HorseBackRiding, txtSub3, txtTax3, txtTotal3);
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
                  //  readPackage(vacationList2, WhiteWaterRafting, txtSub3, txtTax3, txtTotal3);
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
                  //  readPackage(vacationList2, GuidedHike, txtSub3, txtTax3, txtTotal3);
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
