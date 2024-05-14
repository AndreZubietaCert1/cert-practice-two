namespace SecondPracticeApp.Controllers
{
    public class PatientCodeController
    {

        private readonly PatientCodeCreation _patientCodeCreation;

        public PatientCodeController(PatientCodeCreation patientCodeCreation)
        {
            _patientCodeCreation = patientCodeCreation;
        }

        [HttpPost]
        public IActionResult GeneratePatientCode([FromBody] PatientInfo patientInfo)
        {
            if (patientInfo == null)
            {
                return BadRequest("Patient information is missing.");
            }

            // Generate patient code using the provided information
            string patientCode = _patientCodeCreation.GeneratePatientCode(patientInfo.FirstName, patientInfo.LastName, patientInfo.CI);

            return Ok(patientCode);
        }

    }
}
