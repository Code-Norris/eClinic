using System;
using System.Threading.Tasks;

namespace eClinic.PatientRegistration.AppService
{
    public interface IPatientRegistrationService
    {
        //https://softwareengineering.stackexchange.com/questions/330428/ddd-repositories-in-application-or-domain-service

        Task RegisterPatient();
    }
}
