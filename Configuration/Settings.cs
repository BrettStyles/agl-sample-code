using Microsoft.Azure;

namespace Configuration
{
    public class Settings : ISettings
    {
        public string PetServiceAddress => CloudConfigurationManager.GetSetting("personservice");
    }
}