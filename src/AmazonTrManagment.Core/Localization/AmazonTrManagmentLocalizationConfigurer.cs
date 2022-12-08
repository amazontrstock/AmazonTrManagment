using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AmazonTrManagment.Localization
{
    public static class AmazonTrManagmentLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AmazonTrManagmentConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AmazonTrManagmentLocalizationConfigurer).GetAssembly(),
                        "AmazonTrManagment.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
