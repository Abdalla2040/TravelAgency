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

            PackCal pack = PackageCalculations;
            pack();


        }
        public delegate void PackCal();

        public void comboBoxTotals(List<VacationPackage> package, TextBox txtSub, TextBox txtTax, TextBox txtTotal)
        {
            foreach (var vac in package)
            {
                string name = "";
                decimal price = 0m;
                decimal tax = 0m;
                string scenery = "";
                name = vac.destination;
                price = vac.price;
                tax = vac.tax;
                scenery = vac.scenery;
                var sub = from p in package
                            group p by p.scenery into groupPrice
                            select groupPrice.Sum(x => x.price);
                var taxes = from p in package
                            group p by p.scenery into groupTax
                            select groupTax.Sum(x => x.tax);
                foreach (var s in sub)
                    txtSub.Text = s.ToString();
                foreach (var s in taxes)
                    txtTax.Text = s.ToString();
                txtTotal.Text = (decimal.Parse(txtSub.Text) + decimal.Parse(txtTax.Text)).ToString();

            }
        }

        public void PackageCalculations()
        {
            var package = readPackage();
            
            if (package.Count > 0)
            {
               
                var query = package.GroupBy(x => x.scenery).ToList();
                foreach (var group in query)
                {
                    if (group.Key.Contains("Beach"))
                    {
                        //MessageBox.Show("group key: " + group.Key);
                        comboBoxTotals(package, txtSub1, txtTax1, txtTotal1);
                    }
                    else if (group.Key.Contains("Mountain"))
                    {
                        comboBoxTotals(package,txtSub2, txtTax2, txtTotal2);
                    }
                    else if (group.Key.Contains("Desert"))
                    {
                        comboBoxTotals(package, txtSub3, txtTax3, txtTotal3);
                    }
                }
            
            }
            else
            {
                txtSub1.Text = "";
                txtTax1.Text = "";
                txtTotal1.Text = "";
                txtSub2.Text = "";
                txtTax2.Text = "";
                txtTotal2.Text = "";
                txtSub3.Text = "";
                txtTax3.Text = "";
                txtTotal3.Text = "";

            }
        }

        public static event EventHandler SelectedChanged;
        public static event PackCal backButtonChanged;
        public void addPackage(VacationPackage vacationPackage)
        {
            string path = @"TextFile2.txt";
            if (File.Exists(path))
                File.Delete(path);
            writer = File.CreateText(path);
            writer.WriteLine(vacationPackage.ToString(vacationPackage));
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
                vacation.total = decimal.Parse(s[3]);
                vacation.scenery = s[4];
                vacationList3.Add(vacation);
            }
            
            return vacationList3;

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
                surfing.total = surfing.GetTotal(surfing);
                surfing.scenery = "Beach";
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
                ScubaDiving.total = ScubaDiving.GetTotal(ScubaDiving);
                ScubaDiving.scenery = "Beach";
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
                JetSkiing.total = JetSkiing.GetTotal(JetSkiing);
                JetSkiing.scenery = "Beach";
                addPackage(JetSkiing);
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            if (SelectedChanged != null || backButtonChanged != null)
            {

                PackageCalculations();
                //txtSub1.Text = selectedVacationPackage.Sum(x => x.price).ToString();
                //txtTax1.Text = selectedVacationPackage.Sum(x => x.tax).ToString();
                //txtTotal1.Text = (decimal.Parse(txtSub1.Text) + decimal.Parse(txtTax1.Text)).ToString();
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
                Skiing.total = Skiing.GetTotal(Skiing);
                Skiing.scenery = "Mountain";
                addPackage(Skiing);
                Form2 form2 = new Form2();
                form2.ShowDialog();
                

            }
            else if (radioButton2.Checked && comboBox2.SelectedIndex == 1)
            {
                VacationPackage HelicopterTour = new VacationPackage();
                HelicopterTour.destination = comboBox2.SelectedItem.ToString();
                HelicopterTour.price = 168.99m;
                HelicopterTour.tax = 11.62m;
                HelicopterTour.total = HelicopterTour.GetTotal(HelicopterTour);
                HelicopterTour.scenery = "Mountain";
                addPackage(HelicopterTour);
                Form2 form2 = new Form2();
                form2.ShowDialog();
                
            }
            else
            {
                VacationPackage SnowMobiling = new VacationPackage();
                SnowMobiling.destination = comboBox2.SelectedItem.ToString();
                SnowMobiling.price = 138.89m;
                SnowMobiling.tax = 9.55m;
                SnowMobiling.total = SnowMobiling.GetTotal(SnowMobiling);
                SnowMobiling.scenery = "Mountain";
                addPackage(SnowMobiling);
                Form2 form2 = new Form2();
                form2.ShowDialog();
              
            }
            if (SelectedChanged != null || backButtonChanged != null)
            {

                var selectedVacationPackage = readPackage();
                txtSub2.Text = selectedVacationPackage.Sum(x => x.price).ToString();
                txtTax2.Text = selectedVacationPackage.Sum(x => x.tax).ToString();
                txtTotal2.Text = (decimal.Parse(txtSub2.Text) + decimal.Parse(txtTax2.Text)).ToString();
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
                HorseBackRiding.total = HorseBackRiding.GetTotal(HorseBackRiding);
                HorseBackRiding.scenery = "Desert";
                addPackage(HorseBackRiding);
                Form2 form2 = new Form2();
                form2.ShowDialog();
               

            }
            else if (radioButton3.Checked && comboBox3.SelectedIndex == 1)
            {
                VacationPackage WhiteWaterRafting = new VacationPackage();
                WhiteWaterRafting.destination = comboBox3.SelectedItem.ToString();
                WhiteWaterRafting.price = 88.99m;
                WhiteWaterRafting.tax = 6.12m;
                WhiteWaterRafting.total = WhiteWaterRafting.GetTotal(WhiteWaterRafting);
                WhiteWaterRafting.scenery = "Desert";
                addPackage(WhiteWaterRafting);
                Form2 form2 = new Form2();
                form2.ShowDialog();
               
            }
            else
            {
                VacationPackage GuidedHike = new VacationPackage();
                GuidedHike.destination = comboBox3.SelectedItem.ToString();
                GuidedHike.price = 78.89m;
                GuidedHike.tax = 5.43m;
                GuidedHike.total = GuidedHike.GetTotal(GuidedHike);
                GuidedHike.scenery = "Desert";
                addPackage(GuidedHike);
                Form2 form2 = new Form2();
                form2.ShowDialog();
               
            }
            if (SelectedChanged != null || backButtonChanged != null)
            {

                var selectedVacationPackage = readPackage();
                txtSub3.Text = selectedVacationPackage.Sum(x => x.price).ToString();
                txtTax3.Text = selectedVacationPackage.Sum(x => x.tax).ToString();
                txtTotal3.Text = (decimal.Parse(txtSub3.Text) + decimal.Parse(txtTax3.Text)).ToString();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            //PackCal pack = new PackCal(PackageCalculations);
            //pack();
            PackageCalculations();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
