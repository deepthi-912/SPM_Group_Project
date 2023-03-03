using HWK4.Models;

namespace HWK4.Interfaces
{
    public interface IAppointmentRepository
    {
        ICollection<Appointments> GetItems();
        Appointments GetItem(int id);
        bool TodoExists(int id);
        bool CreateItem(Appointments todo);
        bool DeleteItem(int todo);
        bool Save();
        bool UpdateItem(Appointments item);
        List<Appointments> getAppointmentsByDate(DateTime dt);
        List<Appointments> getAppointmentsBetweenDates(DateTime dt1, DateTime dt2);
        List<Appointments> getAppointmentsByDoctor(int doctorId);
        List<Appointments> getAppointmentsByPatient(int patientId);
        int getTotalAppointmentsCount();
    }
}


