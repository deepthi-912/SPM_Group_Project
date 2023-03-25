using Appointments_API.Models;

namespace Appointments_API.Interfaces
{
    public interface IAppointmentRepository
    {
        /// <summary>
        /// GetItems is to get all the items in the Appointments .
        /// </summary>
        /// <returns>Items list</returns>
        ICollection<Appointments> GetItems();
        /// <summary>
        /// GetItem function gets appointment details of the ID given.It returns appointments of each ID if it is found else it returns Notfound.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>400(notfound) or item</returns>
        Appointments GetItem(int id);

        bool TodoExists(int id);
        /// <summary>
        /// CreateItem method creates a new appointment.
        /// </summary>
        /// <returns>creates a new item if doesn't exist</returns>
        bool CreateItem(Appointments todo);

        /// <summary>
        /// DeleteItem method deletes a appointment.
        /// </summary>
        /// <returns>deletes a item if it exists</returns>
        bool DeleteItem(int todo);

        bool Save();

        /// <summary>
        /// UpdateItem method updates a new appointment.
        /// </summary>
        /// <returns>updates a item</returns>
        bool UpdateItem(Appointments item);

        /// <summary>
        /// getAppointmentsBetweenDates method returns the appointment details by date.
        /// </summary>
        /// <returns>appointment details of all patients for a particular date</returns>
        List<Appointments> getAppointmentsByDate(DateTime dt);

        /// <summary>
        /// getAppointmentsBetweenDates method returns the appointment details between dates.
        /// </summary>
        /// <returns>appointment details of all patients between dates</returns>
        List<Appointments> getAppointmentsBetweenDates(DateTime dt1, DateTime dt2);

        /// <summary>
        /// getAppointmentsByPatient method returns the appointment details of a particular doctor.
        /// </summary>
        /// <returns>appointment details of a doctor id</returns>
        List<Appointments> getAppointmentsByDoctor(int doctorId);

        /// <summary>
        /// getAppointmentsByPatient method returns the appointment details of a particular patient.
        /// </summary>
        /// <returns>appointment details of a patient id</returns>
        List<Appointments> getAppointmentsByPatient(int patientId);

        /// <summary>
        /// getAverage method returns the total appointments count.
        /// </summary>
        /// <returns>int</returns>
        int getTotalAppointmentsCount();
    }
}


