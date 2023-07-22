using Microsoft.Extensions.Localization;
using System.Reflection;

namespace NetShop.Models
{
    public class LanguageService
    {
        private readonly IStringLocalizer _stringLocalizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(ShareResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _stringLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }
        public LocalizedString GetKey(string key) 
        {
            return _stringLocalizer[key];
        }
    }
}
