using AssetsTools.NET;
using AssetsTools.NET.Extra;
using AssetsTools.NET.Texture;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using UmaMusumeData;
using Image = SixLabors.ImageSharp.Image;

namespace UmaMusumeExplorer.Assets
{
    static class GameAssets
    {
        private static readonly AssetsManager charaIconAssetsManager = new();
        private static readonly AssetsManager skillIconAssetsManager = new();
        private static readonly AssetsManager jacketsAssetsManager = new();
        private static readonly AssetsManager supportCardIconAssetsManager = new();
        private static readonly AssetsManager generalAssetsManager = new();
        private static readonly Dictionary<string, ImagePointerContainer> imagePointerContainers = new();

        public static Form? MainForm { get; set; }

        public static void ClearLoadedFiles()
        {
            foreach (var imagePointerContainers in imagePointerContainers)
            {
                imagePointerContainers.Value.ImageHandle.Free();
            }

            charaIconAssetsManager.UnloadAll();
            skillIconAssetsManager.UnloadAll();
            jacketsAssetsManager.UnloadAll();
            supportCardIconAssetsManager.UnloadAll();
            generalAssetsManager.UnloadAll();
            imagePointerContainers.Clear();
        }

        public static PinnedBitmap? GetCharaIcon(int id, int raceDressId = 0, int plate = 1)
        {
            string idString = $"{id:d4}";
            StringBuilder imageStringBuilder = new();
            imageStringBuilder.Append($"chr_icon_{idString}");
            if (idString == "0000")
            {
                imageStringBuilder.Clear();
                imageStringBuilder.Append("chr_icon_round_0000");
            }
            if (raceDressId > 0)
                imageStringBuilder.Append($"_{raceDressId:d6}_{plate:d2}");
            string imageName = imageStringBuilder.ToString();

            return LoadImage(charaIconAssetsManager, imageName);
        }

        public static PinnedBitmap? GetSkillIcon(int id)
        {
            string idString;
            if (id == 0)
                idString = "00000";
            else
                idString = id.ToString();

            StringBuilder imageStringBuilder = new();
            imageStringBuilder.Append($"utx_ico_skill_{idString}");
            string imageName = imageStringBuilder.ToString();

            return LoadImage(skillIconAssetsManager, imageName);
        }

        public static PinnedBitmap? GetJacket(int id, char size = 'm')
        {
            string idString = $"{id:d4}";
            StringBuilder imageStringBuilder = new();
            imageStringBuilder.Append($"jacket_icon_{size}_{idString}");
            string imageName = imageStringBuilder.ToString();

            return LoadImage(jacketsAssetsManager, imageName, $"jacket_icon_{size}_0000");
        }

        public static PinnedBitmap? GetSupportCardIcon(int id)
        {
            string idString = $"{id:d5}";
            StringBuilder imageStringBuilder = new();
            imageStringBuilder.Append($"support_thumb_{idString}");
            string imageName = imageStringBuilder.ToString();

            return LoadImage(supportCardIconAssetsManager, imageName, "support_thumb_00000");
        }

        private static PinnedBitmap? LoadImage(AssetsManager assetsManager, string imageName, string fallbackImage = "")
        {
            if (!imagePointerContainers.ContainsKey(imageName))
            {
                lock (assetsManager)
                {
                    LoadAsset(assetsManager, imageName);

                    Image<Bgra32>? image = GetImage(assetsManager, imageName);
                    if (!string.IsNullOrEmpty(fallbackImage))
                        image ??= GetImage(assetsManager, fallbackImage);
                    if (image is null) return null;

                    AddLoadedImage(imageName, image);
                }
            }

            return PinnedBitmapFromKey(imageName);
        }

        private static void AddLoadedImage<TPixel>(string imageName, Image<TPixel> image) where TPixel : unmanaged, IPixel<TPixel>
        {
            lock (imagePointerContainers)
            {
                if (!imagePointerContainers.ContainsKey(imageName))
                    imagePointerContainers.Add(imageName,
                        new ImagePointerContainer(GCHandle.Alloc(image.ToBytes(), GCHandleType.Pinned), image.Width, image.Height));
            }
        }

        private static Image<Bgra32>? GetImage(AssetsManager assetsManager, string imageName)
        {
            AssetTypeValueField? baseField = GetFileBaseField(assetsManager, imageName, out AssetsFileInstance? assetsFileInstance);
            if (baseField is null) return null;
            TextureFile textureFile = TextureFile.ReadTextureFile(baseField);
            Image<Bgra32> image = Image.LoadPixelData<Bgra32>(textureFile.DecodeTextureRaw(textureFile.FillPictureData(assetsFileInstance)), textureFile.m_Width, textureFile.m_Height);
            image.Mutate(o => o.Flip(FlipMode.Vertical));
            return image;
        }

        private static byte[]? ToBytes<TPixel>(this Image<TPixel> image) where TPixel : unmanaged, IPixel<TPixel>
        {
            if (image.DangerousTryGetSinglePixelMemory(out Memory<TPixel> memory))
            {
                return MemoryMarshal.Cast<TPixel, byte>(memory.Span).ToArray();
            }

            return null;
        }

        public static AssetTypeValueField? GetFileBaseField(AssetsManager assetsManager, string objectName, out AssetsFileInstance? assetsFileInstance)
        {
            assetsFileInstance = null;
            foreach (var file in assetsManager.Files)
            {
                foreach (var asset in file.file.AssetInfos)
                {
                    AssetTypeValueField baseField = assetsManager.GetBaseField(file, asset);
                    if (baseField["m_Name"].AsString.Equals(objectName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        assetsFileInstance = file;
                        return baseField;
                    }
                }
            }

            return null;
        }

        public static void LoadAsset(AssetsManager assetsManager, string assetName)
        {
            string assetPath = GetFilePath(assetName);

            if (string.IsNullOrEmpty(assetPath))
                return;

            BundleFileInstance bundle = assetsManager.LoadBundleFile(assetPath);
            foreach (var assetsFile in bundle.file.GetAllFileNames())
            {
                assetsManager.LoadAssetsFileFromBundle(bundle, assetsFile);
            }
        }

        private static string GetFilePath(string entryName)
        {
            ManifestEntry? entry = UmaDataHelper.GetManifestEntries(e => e.Name == entryName || e.BaseName == entryName).FirstOrDefault();
            return UmaDataHelper.GetPath(entry);
        }

        private static PinnedBitmap PinnedBitmapFromKey(string key) =>
            new(imagePointerContainers[key].ImageHandle.AddrOfPinnedObject(),
                imagePointerContainers[key].Width,
                imagePointerContainers[key].Height);
    }
}
