using System;
using System.Threading.Tasks;
using eClinic.PatientRegistration.Domain;
using MongoDB.Driver;

namespace eClinic.PatientRegistration.Infra
{
    public class PatientRepository : IPatientRepository
    {
        public PatientRepository(ISecretStore secretStore)
        {
            InitRepository(secretStore).GetAwaiter().GetResult();
            InitDatabase();
        }

        public Task<Patient> CreateNewPatient(Patient patient)
        {
            throw new NotImplementedException();
           
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

        public async Task InitRepository(ISecretStore secretStore)
        {
            _secretStore = secretStore;

            if(_secretStore == null)
                throw new ArgumentNullException("ISecretStore is null");

            _secrets = await _secretStore.LoadAsync();
        }

        public bool InitDatabase()
        {
            _db = MongoDbHelper.GetDatabase(_secrets.CosmosConnString);
            return true;
        }

        private ISecretStore _secretStore;
        private Secrets _secrets;
        private IMongoDatabase _db;
    }
}