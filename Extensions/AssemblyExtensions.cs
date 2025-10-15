using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace BepInExUtils.Extensions;

public static class AssemblyExtensions
{
    extension(Assembly assembly)
    {
        [PublicAPI]
        private Stream GetManifestResourceStreamOrThrow(string resource) =>
            assembly.GetManifestResourceStream(resource) ??
            throw new(
                $"Failed to find EmbeddedResource '{resource}' in Assembly '{assembly}' (Available Resources: {string.Join(", ", assembly.GetManifestResourceNames())})");

        [PublicAPI]
        public string GetEmbeddedResource(string resource)
        {
            using var streamReader = new StreamReader(assembly.GetManifestResourceStreamOrThrow(resource));
            return streamReader.ReadToEnd();
        }

        [PublicAPI]
        public byte[] GetEmbeddedResourceBytes(string resource)
        {
            using var stream = assembly.GetManifestResourceStreamOrThrow(resource);
            using var memoryStream = new MemoryStream();
            var data = new byte[stream.Length];
            int read;
            while ((read = stream.Read(data, 0, data.Length)) != 0)
                memoryStream.Write(data, 0, read);
            return memoryStream.ToArray();
        }

        [PublicAPI]
        public AssetBundle GetEmbeddedAssetBundle(string resource)
        {
            using var stream = assembly.GetManifestResourceStreamOrThrow(resource);
            return AssetBundle.LoadFromStream(stream);
        }

        [PublicAPI]
        public bool LoadEmbeddedImage(ref Texture2D tex, string resource) =>
            tex.LoadImage(assembly.GetEmbeddedResourceBytes(resource));
    }
}