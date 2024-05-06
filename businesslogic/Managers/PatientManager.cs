using businesslogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace businesslogic.Managers
{
    public class PatientManager
    {

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
            Patient patient2 = new Patient()
            {
                Name = patient.Name,
                LastName = patient.LastName,
                CI = patient.CI,
                BloodGroup = patient.BloodGroup
            };
            _patients.Add(patient2);

            return patient2;
        }

        public Patient UpdatePatient(int ci, Patient patientToUpdate)
        {
            Patient existingPatient = GetPatientByCI(ci);

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
            return foundPatient;
        }
        public Patient DeletePatientByID(int ci) 
        {
            Patient patientToDel = GetPatientByCI(ci);
            _patients.Remove(patientToDel);
            return patientToDel;

        }

    }
}
