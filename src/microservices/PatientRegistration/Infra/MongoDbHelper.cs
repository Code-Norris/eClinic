using System;
using System.Security.Authentication;
using MongoDB.Driver;

namespace eClinic.PatientRegistration.Infra
{
    public class MongoDbHelper
    {
        public static IMongoDatabase GetDatabase(string mongoConnString)
        {
            return InitMongoDb(mongoConnString);
        }

        private static IMongoDatabase InitMongoDb(string mongoConnString)
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(
                new MongoUrl(mongoConnString)
                );
                settings.SslSettings = 
                new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                var mongoClient = new MongoClient(settings);

                return mongoClient.GetDatabase("PatientRegistration");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
