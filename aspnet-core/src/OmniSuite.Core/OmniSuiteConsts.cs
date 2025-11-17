using OmniSuite.Debugging;

namespace OmniSuite;

public class OmniSuiteConsts
{
    public const string LocalizationSourceName = "OmniSuite";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "7f4a4d14caa74f2f947f70901251692e";
}
