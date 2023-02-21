//Created By: Xavier
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class EmployeeManager
    {
        /// <summary>
        /// get a list of employees
        /// </summary>
        /// <param name="db">context</param>
        /// <returns></returns>
        public static List<Employee> GetEmployees(TravelExpertsContext db)
        {
            List<Employee> employees = db.Employees.ToList();
            return employees;
        }
    }
}
