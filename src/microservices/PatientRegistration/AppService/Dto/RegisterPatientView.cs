using System;
using System.Text.Json.Serialization;

namespace eClinic.PatientRegistration.AppService
{
    public class RegisterPatientView
    {
        [JsonPropertyName("patientID")]
        public string PatientID { get; set; }
    }
}