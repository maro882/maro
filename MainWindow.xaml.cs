using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CompanyEntities db = new CompanyEntities();

        public MainWindow()
        {
            InitializeComponent();
            dg.ItemsSource = db.Employee.ToList();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {

            Employee employee = new Employee();
            employee.EmpName = txtn.Text;
            employee.EmpPostion = txts.Text;    
            db.Employee.Add(employee);
            db.SaveChanges();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Employee r = new Employee();
            int empid = int.Parse(txtid.Text);
            r = db.Employee.First(x => x.EmpID == empid);
            r.EmpName = txtn.Text;
            r.EmpPostion = txts.Text;

            db.Employee.AddOrUpdate(r);
            db.SaveChanges();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int idText = int.Parse(txtid.Text);
            db.Employee.Select(x => x.EmpID == idText);
            Employee r = db.Employee.Remove(db.Employee.First(x => x.EmpID == idText));
            db.SaveChanges();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = db.Employee.ToList();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            string name = txtn.Text;
            dg.ItemsSource = db.Employee.Where(s => s.EmpName == name).ToList();
        }

       
    }
}
