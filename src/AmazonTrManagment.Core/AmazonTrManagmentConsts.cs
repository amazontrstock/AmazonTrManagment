using AmazonTrManagment.Debugging;

namespace AmazonTrManagment
{
    public class AmazonTrManagmentConsts
    {
        public const string LocalizationSourceName = "AmazonTrManagment";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "ba98a8b6ab6142939ca525cba166eca5";
    }
}
