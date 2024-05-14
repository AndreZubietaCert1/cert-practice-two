namespace ThirdPracticeApp
{
    public class PatientCodeCreation
    {
        public string GeneratePatientCode(string firstName, string lastName, int ci)
        {
            // Extract first two letters of first name (or full first name if less than two letters)
            string codePrefixA = firstName.Substring(0,1).ToUpper();
            string codePrefixB = lastName.Substring(0, 1).ToUpper();

            string codePrefix = codePrefixA + codePrefixB;

            // Combine with hyphen and CI
            string patientCode = $"{codePrefix}-{ci}";

            return patientCode;
        }


    }
}
