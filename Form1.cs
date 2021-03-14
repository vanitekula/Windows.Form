using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Display()
        {
            dataGridView1.DataSource = new BusinessLogic().Show();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (new BusinessLogic().ADD(new Employee() { Eid = int.Parse(textBox1.Text), Ename = textBox2.Text, Esal = int.Parse(textBox3.Text) }))
            {
                Display();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (new BusinessLogic().Delete(new Employee() { Eid = int.Parse(textBox1.Text) }))
            {
                Display();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (new BusinessLogic().Update(new Employee() { Eid = int.Parse(textBox1.Text), Ename = textBox2.Text, Esal = int.Parse(textBox3.Text) }))
            {
                Display();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Employee emp = new BusinessLogic().GetEmployee(new Employee() { Eid = int.Parse(textBox1.Text) });
            textBox2.Text = emp.Ename;
            textBox3.Text = emp.Esal.ToString();
        }
    }
           
}
