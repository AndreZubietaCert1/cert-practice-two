using businesslogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace businesslogic.Managers
{
    public class PatientManager
    {
        public class PatientNotFoundException : Exception
        {
            public PatientNotFoundException(string message) : base(message) { }
        }

        

        private List<Patient> _patients;
        public PatientManager()
        {
            _patients = new List<Patient>();
            _patients.Add(
                    new Patient()
                    {
                        Name = "André",
                        LastName = "Zubieta",
                        CI = 1234134,
                        BloodGroup = "O+"
                    }
                );
            _patients.Add(
                    new Patient()
                    {
                        Name = "Vani",
                        LastName = "Gomez",
                        CI = 415214,
                        BloodGroup = "A-"
                    }
                );
            _patients.Add(
                    new Patient()
                    {
                        Name = "Cole",
                        LastName = "Palmer",
                        CI = 202020,
                        BloodGroup = "AB+"
                    }
                );

        }

        public List<Patient> GetAll()
        {
            return _patients;
        }

        public Patient CreatePatient(Patient patient) 
        {

            string[] bloodGroups = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
            Random random = new Random();
            int randBloodGroup = random.Next(bloodGroups.Length);

            Patient patient2 = new Patient()
            {
                Name = patient.Name,
                LastName = patient.LastName,
                CI = patient.CI,
                BloodGroup = bloodGroups[randBloodGroup]
            };
            _patients.Add(patient2);

            return patient2;
        }

        public Patient UpdatePatient(int ci, Patient patientToUpdate)
        {
            Patient existingPatient = GetPatientByCI(ci);

            if (existingPatient == null)
            {
                
                throw new PatientNotFoundException("Patient not found");
            }

            if (!string.IsNullOrWhiteSpace(patientToUpdate.Name))
            {
                existingPatient.Name = patientToUpdate.Name;
            }
            if (!string.IsNullOrWhiteSpace(patientToUpdate.LastName))
            {
                existingPatient.LastName = patientToUpdate.LastName;
            }
            return existingPatient;
        }

        public Patient GetPatientByCI(int ci) 
        {
            Patient foundPatient = _patients.Find(x => x.CI == ci);

            if (foundPatient == null)
            {
                throw new PatientNotFoundException("Patient not found");
            }

            return foundPatient;
        }
        public Patient DeletePatientByID(int ci) 
        {
            Patient patientToDel = GetPatientByCI(ci);
            if (patientToDel == null)
            {
                throw new PatientNotFoundException("Patient not found");
            }

            _patients.Remove(patientToDel);
            return patientToDel;

        }

    }
}
