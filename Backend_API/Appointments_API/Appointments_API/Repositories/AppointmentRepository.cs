using System;
using Appointments_API.Data;
using Appointments_API.Interfaces;
using Appointments_API.Models;

namespace Appointments_API.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private DataContext _context;

        public AppointmentRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GetItems method returns the appointment details of all patients.
        /// </summary>
        /// <returns>appointment details of all patient id</returns>

        public ICollection<Appointments> GetItems()
        {
            return _context.Appointments.ToList();
        }

        /// <summary>
        /// GetItem method returns the appointment details of a paticular appointment id.
        /// </summary>
        /// <returns>appointment details of a patient id</returns>
        
        public Appointments GetItem(int id)
        {
            return _context.Appointments.Where(todo => todo.appointment_id == id).FirstOrDefault();
        }

        public bool TodoExists(int id)
        {
            return _context.Appointments.Any(todo => todo.appointment_id == id);
        }

        /// <summary>
        /// CreateItem method creates a new appointment.
        /// </summary>
        /// <returns>creates a new item if doesn't exist</returns>

        public bool CreateItem(Appointments todo)
        {
            if (TodoExists(todo.appointment_id))
            {
                return false;
            }
            _context.Add(todo);
            return Save();
        }

        /// <summary>
        /// UpdateItem method updates a new appointment.
        /// </summary>
        /// <returns>updates a item</returns>

        public bool UpdateItem(Appointments todo)
        {
            _context.Update(todo);
            return Save();
        }

        /// <summary>
        /// DeleteItem method deletes a appointment.
        /// </summary>
        /// <returns>deletes a item if it exists</returns>

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
        /// getAverage method returns the total appointments count.
        /// </summary>
        /// <returns>int</returns>
        public int getTotalAppointmentsCount()
        {
            int count = 0;
            List<Appointments> expense_List = _context.Appointments.ToList();
            return expense_List.Count;
        }

        /// <summary>
        /// getAppointmentsBetweenDates method returns the appointment details by date.
        /// </summary>
        /// <returns>appointment details of all patients for a particular date</returns>
        
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

        /// <summary>
        /// getAppointmentsBetweenDates method returns the appointment details between dates.
        /// </summary>
        /// <returns>appointment details of all patients between dates</returns>

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
        /// getAppointmentsByPatient method returns the appointment details of a particular doctor.
        /// </summary>
        /// <returns>appointment details of a doctor id</returns>

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
        /// getAppointmentsByPatient method returns the appointment details of a particular patient.
        /// </summary>
        /// <returns>appointment details of a patient id</returns>

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

        /// <summary>
        /// getAppointmentsByDisease method returns all the appointment details of a particular disease.
        /// </summary>
        /// <returns>appointment details of a disease</returns>

        public List<Appointments> getAppointmentsByDisease(string disease)
        {
            List<Appointments> expense_List = _context.Appointments.ToList();
            List<Appointments> appointments = new List<Appointments>();
            foreach (Appointments expense in expense_List)
            {
                if (expense.patient_disease == disease)
                {
                    appointments.Add(expense);
                }

            }
            return appointments;
        }
    }
}

