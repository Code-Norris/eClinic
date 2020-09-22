using AutoMapper;
using eClinic.PatientRegistration.Domain;
using shortid;
using shortid.Configuration;

namespace eClinic.PatientRegistration.AppService
{
    public class PropMapper
    {
        public PropMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NewPatientView, Address>();
                cfg.CreateMap<NewPatientView, Patient>();
                cfg.CreateMap<QueueInfo, PatientRegistrationResult>();
            });

            _mapper = config.CreateMapper();
        }

        public IMapper Mapper { get {return _mapper;}}

        IMapper _mapper;
    }
}