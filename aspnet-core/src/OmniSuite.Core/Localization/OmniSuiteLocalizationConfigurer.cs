using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace OmniSuite.Localization;

public static class OmniSuiteLocalizationConfigurer
{
    public static void Configure(ILocalizationConfiguration localizationConfiguration)
    {
        localizationConfiguration.Sources.Add(
            new DictionaryBasedLocalizationSource(OmniSuiteConsts.LocalizationSourceName,
                new XmlEmbeddedFileLocalizationDictionaryProvider(
                    typeof(OmniSuiteLocalizationConfigurer).GetAssembly(),
                    "OmniSuite.Localization.SourceFiles"
                )
            )
        );
    }
}
