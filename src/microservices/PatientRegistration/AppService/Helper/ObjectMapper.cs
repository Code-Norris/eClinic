using AutoMapper;
using eClinic.PatientRegistration.Domain;
using shortid;
using shortid.Configuration;

namespace eClinic.PatientRegistration.AppService
{
    public class ObjectMapper
    {
        public ObjectMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PatientView, Address>();
                cfg.CreateMap<PatientView, Patient>();
            });
               //.ForMember(addr => addr.City, opt => opt.MapFrom(src => src.))
            //});

            // var config = new MapperConfiguration(cfg => {
                
            // });

            _mapper = config.CreateMapper();
        }

        public IMapper Mapper { get {return _mapper;}}

        IMapper _mapper;
    }
}