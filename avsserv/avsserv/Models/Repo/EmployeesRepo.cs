using avsserv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avsserv.Models.Repo
{

    public class EmployeesRepo : IEmployeesRepo
    {
        DBCon _context;
        public EmployeesRepo(DBCon context)
        {
            _context = context;
        }
        public void Add(Employees emp)
        {
            _context.Add(emp);
            _context.SaveChanges();
        }

        public List<Employees> GetAll()
        {
            return _context.Employees.OrderBy(e => e.FirstName).OrderBy(e => e.MiddleName).OrderBy(e => e.LastName).ToList();
        }

        public EmployeesViewModel GetByID(string ID)
        {
            throw new NotImplementedException();
        }

        public EmployeesViewModel UserLogin(string Username)
        {
            throw new NotImplementedException();
        }
    }
}
