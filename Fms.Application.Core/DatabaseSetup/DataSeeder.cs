using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Fms.Application.Core.DatabaseSetup;
public class DataSeeder
{
    private readonly DbContext _applicationDbContext;

    public DataSeeder(DbContext applicationDbContext)
    {
        this._applicationDbContext = applicationDbContext;
    }

    // public void Seed()
    // {
    //     if(!_applicationDbContext.Employee.Any())
    //     {
    //         var employees = new List<Employee>()
    //         {
    //             new Employee()
    //             {
    //                 Name = "Karthik",
    //                 Citizenship = "India",
    //                 EmployeeId = "1"
    //             },
    //             new Employee()
    //             {
    //                 Name = "Jacob",
    //                 Citizenship = "US",
    //                 EmployeeId = "2"
    //             }
    //         };
    //
    //         _applicationDbContext.Employee.AddRange(employees);
    //         _applicationDbContext.SaveChanges();
    //     }
    // }
    
}