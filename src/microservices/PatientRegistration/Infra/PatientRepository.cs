using System;
using System.Threading.Tasks;
using Dapr.Client;
using eClinic.PatientRegistration.Domain;
using Flurl.Http;
using MongoDB.Driver;

namespace eClinic.PatientRegistration.Infra
{
    public class PatientRepository : IPatientRepository
    {
        public PatientRepository(ISecretStore secretStore)
        {
            _secretStore = secretStore;

            InitDatabase().GetAwaiter().GetResult();
        }

        public async Task<bool> CreateNewPatient(Patient patient)
        {
           var collection = _db.GetCollection<Patient>("Patient");
           await collection.InsertOneAsync(patient);
           return true;
        }

        public Task<Patient> FindPatientByIdentificaionNumberAsync(string identificationNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> SearchPatientByNameAsync(string namePattern)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> UpdateExistPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InitDatabase()
        {
            //string connString = "mongodb://cosmosmongo-patientregistration:WGxgVuWF6hsa9il5tg9WkNaP2idsFz3anf8O7N87oORKYfgjgDFjsiVDdJWWJB7UkQoNaxiNOvtVpkppQx3Gvg==@cosmosmongo-patientregistration.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            string connString = await _secretStore.GetAsync("CosmosConnString");

            _db = MongoDbHelper.GetDatabase(connString);

            return true;
        }

        private ISecretStore _secretStore;
        private IMongoDatabase _db;
    }
}