using businesslogic.Managers;
using businesslogic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecondPracticeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        // GET: api/<PatientController>

        private PatientManager _patientManager;

        public PatientController(PatientManager patientManager) 
        {
            _patientManager = patientManager; 
        }


        [HttpGet]
        public List<Patient> Get()
        {
            return _patientManager.GetAll();
        }

        // GET api/<PatientController>/5
        [HttpGet("{ci}")]
        public Patient Get(int ci)
        {
            return _patientManager.GetPatientByCI(ci);
        }

        // POST api/<PatientController>
        [HttpPost]
        public void Post([FromBody] Patient value)
        {
            _patientManager.CreatePatient(value);
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Patient value)
        {
            _patientManager.UpdatePatient(id, value);
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int ci)
        {
            _patientManager.DeletePatientByID(ci);
        }
    }
}
