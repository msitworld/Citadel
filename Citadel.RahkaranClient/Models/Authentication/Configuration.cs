namespace Citadel.RahkaranClient.Models.Authentication
{
    public class Configuration
    {
        /// <summary>
        /// Gets or sets the Rahkaran base address 
        /// </summary>
        public string BaseAddress { get; set; }

        /// <summary>
        /// Gets or sets the name of organization system name
        /// </summary>
        public string SgName { get; set; }

        /// <summary>
        /// Gets or sets the name of Api username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the name of Api password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the maximum retry time for authorization (Default: 5 times)
        /// </summary>
        public int AuthourizeRetryTime { get; set; }

        /// <summary>
        /// Gets or sets the retry delay second between the authorization retry (Default: 3 seconds)
        /// </summary>
        public int AuthourizeRetryDelay { get; set; }
    }
}
