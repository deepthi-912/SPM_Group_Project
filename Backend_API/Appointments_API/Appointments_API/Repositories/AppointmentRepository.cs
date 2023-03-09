using System;
using HWK4.Data;
using HWK4.Interfaces;
using HWK4.Models;

namespace HWK4.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private DataContext _context;

        public AppointmentRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Appointments> GetItems()
        {
            return _context.Appointments.ToList();
        }

        public Appointments GetItem(int id)
        {
            return _context.Appointments.Where(todo => todo.appointment_id == id).FirstOrDefault();
        }

        public bool TodoExists(int id)
        {
            return _context.Appointments.Any(todo => todo.appointment_id == id);
        }

        public bool CreateItem(Appointments todo)
        {
            if (TodoExists(todo.appointment_id))
            {
                return false;
            }
            _context.Add(todo);
            return Save();
        }

        public bool UpdateItem(Appointments todo)
        {
            _context.Update(todo);
            return Save();
        }

        public bool DeleteItem(int id)
        {
            Appointments exp = GetItem(id);
            if (exp == null || !TodoExists(exp.appointment_id))
            {
                return false;
            }
            _context.Remove(exp);
            return Save();
        }

        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved == 1;
        }

        /// <summary>
        /// getAverage method returns the average value of expenditures spent.
        /// </summary>
        /// <returns>double</returns>
        public int getTotalAppointmentsCount()
        {
            int count = 0;
            List<Appointments> expense_List = _context.Appointments.ToList();
            return expense_List.Count;
        }

        /// <summary>
        /// getMinimumExpenditure method returns the minimum value of the expenditure values.
        /// </summary>
        /// <returns>Bill</returns>

        public List<Appointments> getAppointmentsByDate(DateTime dt)
        {
            int value = int.MaxValue;
            List<Appointments> expense_List = _context.Appointments.ToList();
            List<Appointments> appointmentsDate= new List<Appointments>();
            foreach (Appointments expense in expense_List)
            {
                if (expense.appointment_time == dt)
                {
                    appointmentsDate.Add(expense);
                }

            }
            return appointmentsDate;
        }

        public List<Appointments> getAppointmentsBetweenDates(DateTime dt1, DateTime dt2)
        {
            int value = int.MaxValue;
            List<Appointments> expense_List = _context.Appointments.ToList();
            List<Appointments> appointmentsDate = new List<Appointments>();
            foreach (Appointments expense in expense_List)
            {
                if (expense.appointment_time >= dt1 && expense.appointment_time<=dt2)
                {
                    appointmentsDate.Add(expense);
                }

            }
            return appointmentsDate;
        }

        /// <summary>
        /// getMaximumExpenditure method returns the maximum value of the expenditure values.
        /// </summary>
        /// <returns>Bill</returns>

        public List<Appointments> getAppointmentsByDoctor(int doctorId)
        {
            List<Appointments> expense_List = _context.Appointments.ToList();
            List<Appointments> appointmentsDate =new List<Appointments>();
            foreach (Appointments expense in expense_List)
            {
                if (expense.doctor_id == doctorId)
                {
                    appointmentsDate.Add(expense);
                }

            }
            return appointmentsDate;
        }

        /// <summary>
        /// getMaximumExpenditure method returns the maximum value of the expenditure values.
        /// </summary>
        /// <returns>Bill</returns>

        public List<Appointments> getAppointmentsByPatient(int patientId)
        {
            List<Appointments> expense_List = _context.Appointments.ToList();
            List<Appointments> appointmentsDate = new List<Appointments>();
            foreach (Appointments expense in expense_List)
            {
                if (expense.patient_id == patientId)
                {
                    appointmentsDate.Add(expense);
                }

            }
            return appointmentsDate;
        }
    }
}

