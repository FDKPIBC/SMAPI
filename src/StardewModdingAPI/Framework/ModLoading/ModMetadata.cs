﻿using StardewModdingAPI.Framework.Models;

namespace StardewModdingAPI.Framework.ModLoading
{
    /// <summary>Metadata for a mod.</summary>
    internal class ModMetadata : IModMetadata
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The mod's display name.</summary>
        public string DisplayName { get; }

        /// <summary>The mod's full directory path.</summary>
        public string DirectoryPath { get; }

        /// <summary>The mod manifest.</summary>
        public IManifest Manifest { get; }

        /// <summary>Optional metadata about a mod version that SMAPI should assume is compatible or broken, regardless of whether it detects incompatible code.</summary>
        public ModCompatibility Compatibility { get; }

        /// <summary>The metadata resolution status.</summary>
        public ModMetadataStatus Status { get; private set; }

        /// <summary>The reason the metadata is invalid, if any.</summary>
        public string Error { get; private set; }

        /// <summary>The mod instance (if it was loaded).</summary>
        public IMod Mod { get; private set; }


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="displayName">The mod's display name.</param>
        /// <param name="directoryPath">The mod's full directory path.</param>
        /// <param name="manifest">The mod manifest.</param>
        /// <param name="compatibility">Optional metadata about a mod version that SMAPI should assume is compatible or broken, regardless of whether it detects incompatible code.</param>
        public ModMetadata(string displayName, string directoryPath, IManifest manifest, ModCompatibility compatibility)
        {
            this.DisplayName = displayName;
            this.DirectoryPath = directoryPath;
            this.Manifest = manifest;
            this.Compatibility = compatibility;
        }

        /// <summary>Set the mod status.</summary>
        /// <param name="status">The metadata resolution status.</param>
        /// <param name="error">The reason the metadata is invalid, if any.</param>
        /// <returns>Return the instance for chaining.</returns>
        public IModMetadata SetStatus(ModMetadataStatus status, string error = null)
        {
            this.Status = status;
            this.Error = error;
            return this;
        }

        /// <summary>Set the mod instance.</summary>
        /// <param name="mod">The mod instance to set.</param>
        public IModMetadata SetMod(IMod mod)
        {
            this.Mod = mod;
            return this;
        }
    }
}
