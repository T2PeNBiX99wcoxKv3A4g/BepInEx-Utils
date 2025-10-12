using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace BepInExUtils.Extensions;

public static class AssemblyExtensions
{
    extension(Assembly assembly)
    {
        private Stream GetManifestResourceStreamOrThrow(string resource) =>
            assembly.GetManifestResourceStream(resource) ??
            throw new(
                $"Failed to find EmbeddedResource '{resource}' in Assembly '{assembly}' (Available Resources: {string.Join(", ", assembly.GetManifestResourceNames())})");

        [UsedImplicitly]
        public string GetEmbeddedResource(string resource)
        {
            using var streamReader = new StreamReader(assembly.GetManifestResourceStreamOrThrow(resource));
            return streamReader.ReadToEnd();
        }

        [UsedImplicitly]
        public byte[] GetEmbeddedResourceBytes(string resource)
        {
            using var stream = assembly.GetManifestResourceStreamOrThrow(resource);
            var data = new byte[stream.Length];
            _ = stream.Read(data, 0, data.Length);
            return data;
        }

        [UsedImplicitly]
        public AssetBundle GetEmbeddedAssetBundle(string resource)
        {
            using var stream = assembly.GetManifestResourceStreamOrThrow(resource);
            return AssetBundle.LoadFromStream(stream);
        }

        [UsedImplicitly]
        public bool LoadEmbeddedImage(ref Texture2D tex, string resource) =>
            tex.LoadImage(assembly.GetEmbeddedResourceBytes(resource));
    }
}