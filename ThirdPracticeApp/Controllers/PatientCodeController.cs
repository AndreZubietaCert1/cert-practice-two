using Microsoft.AspNetCore.Mvc;
using businesslogic.Managers;
using businesslogic.Models;
using ThirdPracticeApp.Models;

namespace ThirdPracticeApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientCodeController : ControllerBase
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