using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class EmployeeManager
    {
        public static List<Employee> GetEmployees(TravelExpertsContext db)
        {
            List<Employee> employees = db.Employees.ToList();
            return employees;
        }
    }
}
