//Using Interface inbuilt libraries 
using System;
using System.ComponentModel.DataAnnotations;

namespace HWK4.Models
{
    public class Appointments
    {
        /// <summary>
        /// Id is a unique id of each object
        /// </summary>
        private static int nextID = 1;

        /// <summary>
        /// These are columns and types of data in the Expenditures CSV file which are taken as attributes here in the Todo class.
        /// </summary>
        /// <param name="expenditureType"></param>
        /// <param name="expenditure"></param>
        //public Expenditures(String expenditureType, int expenditure)
        //{
        //    ExpenditureType = expenditureType;
        //    Expenditure = expenditure;
        //    ID = nextID;
        //    nextID++;
        //}

        /// <summary>
        /// Declaration of the attributes are done here
        /// </summary>
        public int doctor_id { get; set; }
        public int patient_id { get; set; }
        [Key]
        public int appointment_id { get; set; }
        public DateTime appointment_time { get; set; }
        public String patient_name { get; set; } = String.Empty;
        public String doctor_name { get; set; } = String.Empty;
        public String doctor_department { get; set; } = String.Empty;
        public String patient_disease { get; set; } = String.Empty;
        public int patient_age { get; set; }

    }
}

