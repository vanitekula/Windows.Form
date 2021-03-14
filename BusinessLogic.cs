using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class BusinessLogic
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder cmb;
        DataRow row;
        DataSet ds;
        public BusinessLogic()
        {
            con = new SqlConnection(@"Data Source=OJAS-DD252\SQLEXPRESS;Initial Catalog=EmpDb;Persist Security Info=True;User ID=sa;Password=Ojas@15251525");
            da = new SqlDataAdapter("select * from Employee", con);
            cmb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds,"Employee");
            da.Update(ds.Tables["Employee"]);
            ds.Tables["Employee"].Constraints.Add("Empid_pk",ds.Tables["Employee"].Columns["Empid"],true);
        }
        public bool ADD(Employee emp)
        {
            row = ds.Tables["Employee"].NewRow();
            row["Empid"] = emp.Eid;
            row["Empname"] = emp.Ename;
            row["Empsal"] = emp.Esal;
            ds.Tables["Employee"].Rows.Add(row);
            return da.Update(ds.Tables["Employee"]) == 1;
        }
        public bool Delete(Employee emp)
        {
            ds.Tables["Employee"].Rows.Find(emp.Eid).Delete(); 
            return da.Update(ds.Tables["Employee"]) == 1;
        }
        public bool Update(Employee emp)
        {
            row = ds.Tables["Employee"].Rows.Find(emp.Eid);
            row.BeginEdit();
            row["Empid"] = emp.Eid;
            row["Empname"] = emp.Ename;
            row["Empsal"] = emp.Esal;
            row.EndEdit();
            return da.Update(ds.Tables["Employee"]) == 1;
        }
        public DataView Show()
        {
            return ds.Tables["Employee"].DefaultView;
        }
        public Employee GetEmployee(Employee emp)
        {
            row = ds.Tables["Employee"].Rows.Find(emp.Eid);
            emp.Ename = row["Empname"].ToString();
            emp.Esal = int.Parse(row["Empsal"].ToString());
            return emp;
        }
    }
}
