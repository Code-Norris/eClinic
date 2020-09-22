using System;
using System.Text.Json.Serialization;

namespace eClinic.PatientRegistration.AppService
{
    public class NewPatientView
    {

        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("idCardNumber")]
        public string IDCardNumber { get; set; }
        [JsonPropertyName("age")]
        public int Age { get; set; }
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
        [JsonPropertyName("height")]
        //cm
        public double Height { get; set; }
        [JsonPropertyName("weight")]
        //kg
        public double Weight { get; set; }
        [JsonPropertyName("allergies")]
        public string[] Allergies { get; set; }
    }
}