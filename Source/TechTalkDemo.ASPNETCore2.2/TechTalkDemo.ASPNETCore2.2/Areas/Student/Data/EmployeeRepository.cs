using System.Collections.Generic;
using TechTalkDemo.ASPNETCore2._2.Areas.Student.Models;
using System.Data;
using System;

namespace TechTalkDemo.ASPNETCore2._2.Areas.Student.Data
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployeeData();
    }
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> GetEmployeeData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("FistName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));

            dt.Rows.Add(1, "Mary","A");
            dt.Rows.Add(2, "Tony","A");

            List<Employee> employeelst = new List<Employee>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Employee employee = new Employee();
                employee.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                employee.FirstName = dt.Rows[i]["FistName"].ToString();
                employee.LastName = dt.Rows[i]["LastName"].ToString();
                employeelst.Add(employee);
            }
            return employeelst;
        }
           
    }
}
