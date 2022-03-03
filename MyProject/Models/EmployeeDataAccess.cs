using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;

namespace MyProject.Models
{
    public class EmployeeDataAccess
    {
        DBConnection Dbconnection;
        public EmployeeDataAccess()
        {
            Dbconnection = new DBConnection();
        }
        public List<Employees> GetEmployees()
        {
            string Sp = "SP_Employee";
            SqlCommand sql = new SqlCommand(Sp,Dbconnection.Connection);
            sql.Parameters.AddWithValue("@action", "SELECT");
            if(Dbconnection.Connection.State==ConnectionState.Closed)
            {
                Dbconnection.Connection.Open();
            }
            SqlDataReader dr = sql.ExecuteReader();
            List<Employees> employees = new List<Employees>();
            while(dr.Read())
            {
                Employees Emp = new Employees();
                Emp.Id = (int)dr["id"];
                Emp.Name = dr["ename"].ToString();
                Emp.Email = dr["email"].ToString();
                Emp.Gender = dr["gender"].ToString();
                Emp.Mobile = dr["mobile"].ToString();
                Emp.Dept_ID = (int)dr["dept-id"];
                employees.Add(Emp);
            }
            Dbconnection.Connection.Close();
            return employees;
        }
    }
}
