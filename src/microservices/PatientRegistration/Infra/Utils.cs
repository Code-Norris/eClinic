using System;

namespace eClinic.PatientRegistration.Infra
{
    public class Utils
    {
        public static string GetSecretStoreName()
        {
            string env = Environment.GetEnvironmentVariable("env");

            if(string.IsNullOrEmpty(env))
                return "kubernetes";
            else
                return "localsecretstore";
        }

        public static string GetDaprPort()
        {
            string port = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3500";
            return port;
        }
    }
}