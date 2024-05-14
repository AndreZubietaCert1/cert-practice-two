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
        private readonly HttpClient _httpClient;

        public PatientController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost("generate-patient-code")]
        public async Task<string> GeneratePatientCode([FromBody] Patient patient)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://practice3-api-url/api/PatientCode");

            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(patient), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string patientCode = await response.Content.ReadAsStringAsync();
                return patientCode;
            }
            else
            {
                return null;
            }
        }


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
            if (_patientManager.GetPatientByCI(ci) == null)
            {
                // Log.Error("Error 404: Patient not found");
            }
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