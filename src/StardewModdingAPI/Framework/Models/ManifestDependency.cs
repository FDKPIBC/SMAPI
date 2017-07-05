﻿namespace StardewModdingAPI.Framework.Models
{
    /// <summary>A mod dependency listed in a mod manifest.</summary>
    internal class ManifestDependency : IManifestDependency
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The unique mod ID to require.</summary>
        public string UniqueID { get; set; }

        /// <summary>The minimum required version (if any).</summary>
        public ISemanticVersion MinimumVersion { get; set; }


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="uniqueID">The unique mod ID to require.</param>
        /// <param name="minimumVersion">The minimum required version (if any).</param>
        public ManifestDependency(string uniqueID, string minimumVersion)
        {
            this.UniqueID = uniqueID;
            this.MinimumVersion = !string.IsNullOrWhiteSpace(minimumVersion)
                ? new SemanticVersion(minimumVersion)
                : null;
        }
    }
}
