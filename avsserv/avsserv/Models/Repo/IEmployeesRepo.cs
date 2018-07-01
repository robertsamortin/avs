using avsserv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avsserv.Models.Repo
{
    public interface IEmployeesRepo
    {
        void Add(Employees emp);
        EmployeesViewModel UserLogin(string Username);
        EmployeesViewModel GetByID(string ID);
        List<Employees> GetAll();
    }
}
