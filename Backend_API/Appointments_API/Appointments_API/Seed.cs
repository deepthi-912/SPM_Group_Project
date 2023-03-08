using System;
using HWK4.Data;
using HWK4.Models;

namespace HWK4
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Appointments.Any())
            {
                List<Appointments> todos = new();
                
                //{
                //    new Expenditures { ID = 01, ExpenditureType = "Rent", Expenditure = 1000},
                //    new Expenditures { ID = 02,  ExpenditureType = "Groceries", Expenditure = 200},
                //    new Expenditures { ID = 03, ExpenditureType = "Transportation", Expenditure = 250},
                //    new Expenditures { ID = 04,  ExpenditureType = "Gas", Expenditure = 100},
                //    new Expenditures { ID = 05, ExpenditureType = "Vacation", Expenditure = 2000},
                //    new Expenditures { ID = 06,  ExpenditureType = "Furniture", Expenditure = 3000},
                //    new Expenditures { ID = 07, ExpenditureType = "Internet", Expenditure = 50},
                //    new Expenditures { ID = 08,  ExpenditureType = "Insurance", Expenditure = 200}
                //};
                dataContext.Appointments.AddRange(todos);
                dataContext.SaveChanges();
            }
        }
    }
}

