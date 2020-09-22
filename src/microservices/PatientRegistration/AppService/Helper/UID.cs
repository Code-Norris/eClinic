using shortid;
using shortid.Configuration;

namespace eClinic.PatientRegistration.AppService
{
    public class UID
    {
        public static string New()
        {
            return ShortId.Generate(new GenerationOptions(){
                Length = 8,
                UseSpecialCharacters = false,
                UseNumbers = true
            });
        }
    }
}