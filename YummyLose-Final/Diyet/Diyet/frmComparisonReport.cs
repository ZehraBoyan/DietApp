using Diet_BL.Services;
using Diet_Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diyet
{
    public partial class frmComparisonReport : Form
    {
        CategoryServices categoryService;
        MainTableServices mainTableService;
        UserService userService;
        public frmComparisonReport()
        {
            InitializeComponent();
            categoryService = new CategoryServices();
            mainTableService = new MainTableServices();
            userService = new UserService();

        }
        private void frmComparisonReport_Load(object sender, EventArgs e)
        {

            FillCmbMeal();
            FillCmbCategory();
        }
        private void FillCmbCategory()
        {
            cmbTypeFood.DataSource = categoryService.GetList();
            cmbTypeFood.DisplayMember = "CategoryName";
            cmbTypeFood.ValueMember = "ID";
        }
        private void FillCmbMeal()
        {
            string[] mealname = Enum.GetNames(typeof(MealName));
            cmbMeals.DataSource = mealname;

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Hide();
                Login frmlog = new Login();
                frmlog.Show();
            }
            else
            {
                MessageBox.Show("Haydi kalori eklemeye devam edelim!");
            }
        }

        private void rprOlustur_Click_1(object sender, EventArgs e)
        {
            MealName meals = (MealName)cmbMeals.SelectedIndex;
            int food = (int)cmbTypeFood.SelectedValue;
            //MealName foo = (MealName)Enum.Parse(typeof(MealName), meals);
            var tarih = DateTime.Now;
            if (radioButton1.Checked == true)
            {
                var startDate = tarih.AddDays(-30);
                string startdate1 = startDate.ToString().Substring(0, 10);
                var endDate = tarih;
                string endDate1 = endDate.ToString().Substring(0, 10);
                mainTableService.GetRaport(food, meals, Convert.ToDateTime(startdate1), Convert.ToDateTime(endDate1), chart1);
            }
            else
            {
                var startDate = tarih.AddDays(-7);
                string startdate1 = startDate.ToString().Substring(0, 10);
                var endDate = tarih;
                string endDate1 = endDate.ToString().Substring(0, 10);
                mainTableService.GetRaport(food, meals, Convert.ToDateTime(startdate1), Convert.ToDateTime(endDate1), chart1);

            }
        }
    }
}
