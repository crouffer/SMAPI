namespace StardewModdingAPI.Web.Framework.ConfigModels
{
    /// <summary>The config settings for the API clients.</summary>
    internal class ApiClientsConfig
    {
        /*********
        ** Accessors
        *********/
        /****
        ** Generic
        ****/
        /// <summary>The user agent for API clients, where {0} is the SMAPI version.</summary>
        public string UserAgent { get; set; }


        /****
        ** Chucklefish
        ****/
        /// <summary>The base URL for the Chucklefish mod site.</summary>
        public string ChucklefishBaseUrl { get; set; }

        /// <summary>The URL for a mod page on the Chucklefish mod site excluding the <see cref="GitHubBaseUrl"/>, where {0} is the mod ID.</summary>
        public string ChucklefishModPageUrlFormat { get; set; }


        /****
        ** GitHub
        ****/
        /// <summary>The base URL for the GitHub API.</summary>
        public string GitHubBaseUrl { get; set; }

        /// <summary>The URL for a GitHub API query for the latest stable release, excluding the <see cref="GitHubBaseUrl"/>, where {0} is the organisation and project name.</summary>
        public string GitHubStableReleaseUrlFormat { get; set; }

        /// <summary>The URL for a GitHub API query for the latest release (including prerelease), excluding the <see cref="GitHubBaseUrl"/>, where {0} is the organisation and project name.</summary>
        public string GitHubAnyReleaseUrlFormat { get; set; }

        /// <summary>The Accept header value expected by the GitHub API.</summary>
        public string GitHubAcceptHeader { get; set; }

        /// <summary>The username with which to authenticate to the GitHub API (if any).</summary>
        public string GitHubUsername { get; set; }

        /// <summary>The password with which to authenticate to the GitHub API (if any).</summary>
        public string GitHubPassword { get; set; }

        /****
        ** ModDrop
        ****/
        /// <summary>The base URL for the ModDrop API.</summary>
        public string ModDropApiUrl { get; set; }

        /// <summary>The URL for a ModDrop mod page for the user, where {0} is the mod ID.</summary>
        public string ModDropModPageUrl { get; set; }

        /****
        ** Nexus Mods
        ****/
        /// <summary>The base URL for the Nexus Mods API.</summary>
        public string NexusBaseUrl { get; set; }

        /// <summary>The URL for a Nexus mod page for the user, excluding the <see cref="NexusBaseUrl"/>, where {0} is the mod ID.</summary>
        public string NexusModUrlFormat { get; set; }

        /// <summary>The URL for a Nexus mod page to scrape for versions, excluding the <see cref="NexusBaseUrl"/>, where {0} is the mod ID.</summary>
        public string NexusModScrapeUrlFormat { get; set; }

        /****
        ** Pastebin
        ****/
        /// <summary>The base URL for the Pastebin API.</summary>
        public string PastebinBaseUrl { get; set; }

        /// <summary>The user key used to authenticate with the Pastebin API.</summary>
        public string PastebinUserKey { get; set; }

        /// <summary>The developer key used to authenticate with the Pastebin API.</summary>
        public string PastebinDevKey { get; set; }

    }
}
