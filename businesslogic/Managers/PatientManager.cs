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
            return patient2;
        }

        public Patient UpdatePatient(Patient patientToUpdate)
        { 
            throw new NotImplementedException();
        }

        public Patient GetPatientByCI(int ci) 
        {
            throw new NotImplementedException();
        }
        public Patient DeletePatientByID(int id) 
        {
            throw new NotImplementedException();
        }

    }
}
