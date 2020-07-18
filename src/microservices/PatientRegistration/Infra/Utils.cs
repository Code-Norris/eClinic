using System;

namespace eClinic.PatientRegistration.Infra
{
    public class Utils
    {
        public static string BaseDaprUrl
        {
            get
            {
                string port = Environment.GetEnvironmentVariable("daprPort");
                return $"http://localhost:{port}/";
            }
        }
    }
}