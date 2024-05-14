using businesslogic.Models;

namespace SecondPracticeApp
{
    public class PatientDataFile
    {

        private readonly string _filePath;

        public PatientDataFile(string filePath)
        {
            _filePath = "C:\\Users\\Drucus\\Certificacion I\\Practice-2\\practice2-app-vs\\patient-data.txt"
;
        }

        public void SavePatients(List<Patient> patients)
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var patient in patients)
                {
                    writer.WriteLine($"{patient.Name},{patient.LastName},{patient.CI},{patient.BloodGroup}");
                }
            }
        }

        public List<Patient> LoadPatients()
        {
            List<Patient> patients = new List<Patient>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        patients.Add(new Patient
                        {
                            Name = parts[0],
                            LastName = parts[1],
                            CI = int.Parse(parts[2]),
                            BloodGroup = parts[3]
                        });
                    }
                }
            }

            return patients;
        }
    }
}

