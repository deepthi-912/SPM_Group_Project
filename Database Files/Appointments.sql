//Database for ccreating Doctor Appointments 
create database Appointments;
select doctor_id from Appointments.Appointments;

//Database Table Creation 
CREATE TABLE  Appointments.Appointments(
  doctor_id INT NOT NULL,
  patient_id INT NOT NULL,
  appointment_id INT NOT NULL PRIMARY KEY ,
  appointment_time DATETIME NOT NULL,
  patient_name VARCHAR(255) NOT NULL,
  doctor_name VARCHAR(255) NOT NULL,
  doctor_department VARCHAR(255) NOT NULL,
  patient_disease VARCHAR(255) NOT NULL,
  patient_age INT NOT NULL
);

//Insertion of values 
INSERT INTO Appointments.Appointments(doctor_id, patient_id, appointment_id, appointment_time, patient_name, doctor_name, doctor_department, patient_disease, patient_age) VALUES
(1, 1, 1, '2023-03-05 09:00:00', 'John Doe', 'Dr. Smith', 'Cardiology', 'Heart Attack', 56),
(2, 2, 2, '2023-03-06 10:00:00', 'Jane Doe', 'Dr. Lee', 'Oncology', 'Breast Cancer', 42),
(3, 3, 3, '2023-03-07 11:00:00', 'Bob Johnson', 'Dr. Wilson', 'Orthopedics', 'Fractured Arm', 35),
(4, 4, 4, '2023-03-08 12:00:00', 'Alice Johnson', 'Dr. Jackson', 'Neurology', 'Migraine', 28),
(5, 5, 5, '2023-03-09 13:00:00', 'Sarah Lee', 'Dr. Neilson', 'Allergy and Immunology', 'Allergies', 19),
(1, 6, 6, '2023-03-10 14:00:00', 'Tom Davis', 'Dr. Smith', 'Cardiology', 'Asthma', 49),
(6, 7, 7, '2023-03-11 15:00:00', 'Linda Wilson', 'Dr. Carolina', 'Dermatology', 'Psoriasis', 61),
(7, 8, 8, '2023-03-12 16:00:00', 'David Brown', 'Dr. Katie', 'Infectious Disease', 'Flu', 32),
(8, 9, 9, '2023-03-13 17:00:00', 'Samantha Green', 'Dr. Charles', 'Gastroenterology', 'Irritable Bowel Syndrome', 47),
(10, 10, 10, '2023-03-14 18:00:00', 'Peter White', 'Dr. Monica', 'Endocrinology', 'Diabetes', 52),
(11, 11, 11, '2023-03-15 19:00:00', 'Karen Lewis', 'Dr. Deepthi', 'Rheumatology', 'Arthritis', 71),
(3, 12, 12, '2023-03-16 20:00:00', 'Mark Roberts', 'Dr. Jackson', 'Neurology', 'Parkinson Disease', 59),
(12, 13, 13, '2023-03-17 09:00:00', 'Catherine Johnson', 'Dr. Smitha', 'Psychiatry', 'Depression', 43),
(2, 14, 14, '2023-03-18 10:00:00', 'Alexandra Lee', 'Dr. Lee', 'Oncology', 'Lung Cancer', 34),
(5, 15, 15, '2023-03-19 11:00:00', 'Laura Davis', 'Dr. Neilson', 'Allergy and Immunology', 'Hay Fever', 51);
