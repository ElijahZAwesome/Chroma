using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using Chroma.Audio.Sources;
using Chroma.Graphics;
using Chroma.Graphics.Accelerated;
using Chroma.Graphics.TextRendering.Bitmap;
using Chroma.Graphics.TextRendering.TrueType;
using Chroma.Input;
using Chroma.MemoryManagement;

namespace Chroma.ContentManagement.FileSystem.ContentProviders
{
    public class EmbeddedResourceContentProvider : DisposableResource, IContentProvider
    {
        private readonly HashSet<DisposableResource> _loadedResources;
        private readonly Dictionary<Type, Func<string, object[], object>> _importers;

        private string _namespace;
        private Assembly _assembly;

        public string ContentRoot { get; }

        public EmbeddedResourceContentProvider(Assembly assembly, string contentRoot = null)
        {
            ContentRoot = contentRoot;
            _namespace = assembly.GetName().Name;
            _assembly = assembly;

            if (string.IsNullOrEmpty(ContentRoot))
            {
                ContentRoot = "Content";
            }

            _loadedResources = new HashSet<DisposableResource>();
            _importers = new Dictionary<Type, Func<string, object[], object>>();

            RegisterImporters();
        }

        public T Load<T>(string relativePath, params object[] args) where T : DisposableResource
        {
            var type = typeof(T);

            if (!_importers.ContainsKey(type))
            {
                throw new UnsupportedContentException(
                    "This type of content is not supported by this provider.",
                    MakeAbsolutePath(relativePath)
                );
            }

            var resource = _importers[type].Invoke(MakeAbsolutePath(relativePath), args) as T;

            if (resource != null)
            {
                _loadedResources.Add(resource);
                resource.Disposing += OnResourceDisposing;
            }

            return resource;
        }

        public void Unload<T>(T resource) where T : DisposableResource
        {
            if (!_loadedResources.Contains(resource))
                throw new ContentNotLoadedException(
                    "The content you want to unload was never loaded in the first place.");

            resource.Dispose();
        }

        private string ConvertToManifestPath(string filePath) => Path.GetFullPath(filePath).Replace('/', '.').TrimStart('.');

        private string GetQualifiedManifestPath(string relativePath) 
            => $"{_namespace}.{ConvertToManifestPath(relativePath)}";
        
        public Stream Open(string relativePath)
            => OpenEmbeddedResource(GetQualifiedManifestPath(relativePath));

        private Stream OpenEmbeddedResource(string qualifiedPath)
            => _assembly.GetManifestResourceStream(qualifiedPath);

        public byte[] Read(string relativePath)
        {
            using var mem = new MemoryStream();
            _assembly.GetManifestResourceStream(GetQualifiedManifestPath(relativePath))!.CopyTo(mem);
            return mem.ToArray();
        }

        public void Track<T>(T resource) where T : DisposableResource
        {
            if (_loadedResources.Contains(resource))
                throw new InvalidOperationException("The content you want to track is already being tracked.");

            _loadedResources.Add(resource);
            resource.Disposing += OnResourceDisposing;
        }

        public void StopTracking<T>(T resource) where T : DisposableResource
        {
            if (!_loadedResources.Contains(resource))
                throw new ContentNotLoadedException(
                    "The content you want to stop tracking was never tracked in the first place.");

            resource.Disposing -= OnResourceDisposing;
            _loadedResources.Remove(resource);
        }

        public void RegisterImporter<T>(Func<string, object[], object> importer) where T : DisposableResource
        {
            var contentType = typeof(T);

            if (_importers.ContainsKey(contentType))
            {
                throw new InvalidOperationException(
                    $"An importer for type {contentType.Name} was already registered."
                );
            }

            _importers.Add(contentType, importer);
        }

        public void UnregisterImporter<T>() where T : DisposableResource
        {
            var contentType = typeof(T);

            if (!_importers.ContainsKey(contentType))
            {
                throw new InvalidOperationException(
                    $"An importer for type {contentType.Name} was never registered, thus it cannot be unregistered.");
            }

            _importers.Remove(contentType);
        }

        public bool IsImporterPresent<T>() where T : DisposableResource
            => _importers.ContainsKey(typeof(T));

        protected override void FreeManagedResources()
        {
            var disposables = new List<IDisposable>(_loadedResources);

            foreach (var resource in disposables)
                resource.Dispose();
        }

        private void RegisterImporters()
        {
            RegisterImporter<Texture>((path, _) =>
            {
                using var stream = Open(path);
                return new Texture(stream);
            });
            RegisterImporter<PixelShader>((path, _) => new PixelShader(Encoding.ASCII.GetString(Read(path))));
            RegisterImporter<VertexShader>((path, _) => new VertexShader(Encoding.ASCII.GetString(Read(path))));
            RegisterImporter<Effect>((path, _) => new Effect(Encoding.ASCII.GetString(Read(path))));
            RegisterImporter<BitmapFont>((path, _) =>
            {
                using var stream = Open(path);
                return new BitmapFont(path, stream, (texFileName) =>
                {
                    var basePathParts = GetQualifiedManifestPath(path).Split('.').Take(..^2);

                    var texEmbeddedResourcePath = string.Join('.', basePathParts) + $".{texFileName}";

                    using var textureStream = OpenEmbeddedResource(texEmbeddedResourcePath);
                    return new Texture(textureStream);
                });
            });
            RegisterImporter<Sound>((path, _) =>
            {
                using var stream = Open(path);
                return new Sound(stream);
            });
            RegisterImporter<Music>((path, _) =>
            {
                using var stream = Open(path);
                return new Music(stream);
            });

            RegisterImporter<Cursor>((path, args) =>
            {
                var hotSpot = new Vector2();

                if (args.Length >= 1)
                    hotSpot = (Vector2)args[0];

                using var textureStream = Open(path);
                var cursor = new Cursor(new Texture(textureStream), hotSpot);
                return cursor;
            });

            RegisterImporter<TrueTypeFont>((path, args) =>
            {
                TrueTypeFont ttf;
                using var stream = Open(path);
                if (args.Length == 2)
                {
                    ttf = new TrueTypeFont(stream, (int)args[0], (string)args[1]);
                }
                else if (args.Length == 1)
                {
                    ttf = new TrueTypeFont(stream, (int)args[0]);
                }
                else
                {
                    ttf = new TrueTypeFont(stream, 12);
                }

                return ttf;
            });
        }

        private string MakeAbsolutePath(string relativePath)
            => Path.Combine(ContentRoot, relativePath);

        private void OnResourceDisposing(object sender, EventArgs e)
        {
            if (sender is DisposableResource disposable)
            {
                disposable.Disposing -= OnResourceDisposing;
                _loadedResources.Remove(disposable);
            }
        }
    }
}