using System;

namespace eClinic.PatientRegistration.Infra
{
    public interface IAppLogger
    {
        public void Info(string message);

        public void Error(Exception ex);
    }
}