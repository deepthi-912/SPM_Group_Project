using System;
using Appointments_API.Data;
using Appointments_API.Models;

namespace Appointments_API
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
                dataContext.Appointments.AddRange(todos);
                dataContext.SaveChanges();
            }
        }
    }
}

