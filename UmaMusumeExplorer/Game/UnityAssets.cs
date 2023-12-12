using AssetsTools.NET;
using AssetsTools.NET.Extra;
using AssetsTools.NET.Texture;
using SixLabors.ImageSharp;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using UmaMusumeData;
using UmaMusumeExplorer.Controls.Common;
using Image = SixLabors.ImageSharp.Image;

namespace UmaMusumeExplorer.Game
{
    static class UnityAssets
    {
        private static readonly AssetsManager charaIconAssetsManager = new();
        private static readonly AssetsManager skillIconAssetsManager = new();
        private static readonly AssetsManager jacketsAssetsManager = new();
        private static readonly AssetsManager supportCardIconAssetsManager = new();
        private static readonly AssetsManager generalAssetsManager = new();
        private static readonly Dictionary<string, ImagePointerContainer> imagePointerContainers = new();

        private static bool charaIconsLoaded = false;
        private static bool skillIconsLoaded = false;
        private static bool jacketIconsLoaded = false;
        private static bool supportCardIconsLoaded = false;

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
            if (!charaIconsLoaded)
            {
                Regex chrIconRegex = new(@"\bchr_icon_[0-9]{4}\b");
                Regex chrCardIconRegex = new(@"\bchr_icon_[0-9]{4}_[0-9]{6}_[0-9]{2}\b");

                List<string> imagePaths = new();
                List<ManifestEntry> charaAssetEntryRows = UmaDataHelper.GetManifestEntryDataRows(ga => ga.Name.StartsWith("chara/"));
                charaAssetEntryRows.ForEach(c =>
                {
                    if (chrIconRegex.IsMatch(c.BaseName) || chrCardIconRegex.IsMatch(c.BaseName) || c.BaseName == "chr_icon_round_0000")
                        imagePaths.Add(UmaDataHelper.GetPath(c));
                });
                LoadFiles(charaIconAssetsManager, imagePaths);

                charaIconsLoaded = true;
            }

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

            if (imagePointerContainers.ContainsKey(imageName)) return PinnedBitmapFromKey(imageName);

            Image<Bgra32>? image = GetImage(charaIconAssetsManager, imageName);
            if (image is null) return null;

            int adjustedHeight = (int)(image.Height * 1.115F);
            image.Mutate(o => o.Resize(image.Width, adjustedHeight));

            AddLoadedImage(imageName, image);
            return PinnedBitmapFromKey(imageName);
        }

        public static PinnedBitmap? GetSkillIcon(int id)
        {
            if (!skillIconsLoaded)
            {
                List<ManifestEntry> skillIconAssetEntryRows = UmaDataHelper.GetManifestEntryDataRows(ga => ga.Name.StartsWith("outgame/skillicon/utx_ico_skill_"));
                LoadFiles(skillIconAssetsManager, GetFilePaths(skillIconAssetEntryRows));
                skillIconsLoaded = true;
            }

            string idString;
            if (id == 0)
                idString = "00000";
            else
                idString = id.ToString();

            StringBuilder imageStringBuilder = new();
            imageStringBuilder.Append($"utx_ico_skill_{idString}");
            string imageName = imageStringBuilder.ToString();

            if (imagePointerContainers.ContainsKey(imageName)) return PinnedBitmapFromKey(imageName);

            Image<Bgra32>? image = GetImage(skillIconAssetsManager, imageName);
            if (image is null) return null;

            AddLoadedImage(imageName, image);
            return PinnedBitmapFromKey(imageName);
        }

        public static PinnedBitmap? GetJacket(int id, char size = 'm')
        {
            if (!jacketIconsLoaded)
            {
                List<ManifestEntry> liveJacketAssetEntryRows = UmaDataHelper.GetManifestEntryDataRows(ga => ga.Name.StartsWith("live/jacket/jacket_icon_l_"));
                LoadFiles(jacketsAssetsManager, GetFilePaths(liveJacketAssetEntryRows));
                jacketIconsLoaded = true;
            }

            string idString = $"{id:d4}";
            StringBuilder imageStringBuilder = new();
            imageStringBuilder.Append($"jacket_icon_{size}_{idString}");
            string imageName = imageStringBuilder.ToString();

            if (imagePointerContainers.ContainsKey(imageName)) return PinnedBitmapFromKey(imageName);

            Image<Bgra32>? image = GetImage(jacketsAssetsManager, imageName);
            image ??= GetImage(jacketsAssetsManager, $"jacket_icon_{size}_0000");
            if (image is null) return null;

            AddLoadedImage(imageName, image);
            return PinnedBitmapFromKey(imageName);
        }

        public static PinnedBitmap? GetSupportCardIcon(int id)
        {
            if (!supportCardIconsLoaded)
            {
                Regex supportCardIconRegex = new(@"\bsupport_thumb_[0-9]{5}\b");

                List<string> imagePaths = new();
                List<ManifestEntry> supportCardAssetEntryRows = UmaDataHelper.GetManifestEntryDataRows(ga => ga.Name.StartsWith("supportcard/"));
                supportCardAssetEntryRows.ForEach(c =>
                {
                    if (supportCardIconRegex.IsMatch(c.BaseName.ToLower()) || c.BaseName.ToLower() == "support_thumb_00000")
                        imagePaths.Add(UmaDataHelper.GetPath(c));
                });
                LoadFiles(supportCardIconAssetsManager, imagePaths);
                supportCardIconsLoaded = true;
            }

            string idString = $"{id:d5}";
            StringBuilder imageStringBuilder = new();
            imageStringBuilder.Append($"support_thumb_{idString}");
            string imageName = imageStringBuilder.ToString();

            if (imagePointerContainers.ContainsKey(imageName)) return PinnedBitmapFromKey(imageName);

            Image<Bgra32>? image = GetImage(supportCardIconAssetsManager, imageName);

            if (image is null)
            {
                image = GetImage(supportCardIconAssetsManager, $"support_thumb_00000");
                if (image is null) return null;
                int adjustedHeight = (int)(image.Height / 2 * ((float)19 / 15));
                image.Mutate(o => o.Resize(image.Width, adjustedHeight));
            }
            else
            {
                int adjustedHeight = (int)(image.Height * ((float)19 / 15));
                image.Mutate(o => o.Resize(image.Width, adjustedHeight));
            }

            if (image is null) return null;

            AddLoadedImage(imageName, image);
            return PinnedBitmapFromKey(imageName);
        }

        //public static StreamReader GetLiveCsv(int musicId, string category)
        //{
        //    string idString = $"{musicId:d4}";

        //    SerializedFile targetAsset = GetFile(generalAssetsManager, $"m{idString}_{category}", ClassIDType.TextAsset);
        //    if (targetAsset is null) return null;
        //    TextAsset textAsset = targetAsset.Objects.First(o => o.type == ClassIDType.TextAsset) as TextAsset;

        //    return new StreamReader(new MemoryStream(textAsset.m_Script));
        //}

        private static void AddLoadedImage<TPixel>(string imageName, Image<TPixel> image) where TPixel : unmanaged, IPixel<TPixel>
        {
            imagePointerContainers.Add(imageName,
                new ImagePointerContainer(GCHandle.Alloc(image.ToBytes(), GCHandleType.Pinned), image.Width, image.Height));
        }

        private static Image<Bgra32>? GetImage(AssetsManager assetsManager, string imageName)
        {
            AssetTypeValueField? baseField = GetFileBaseField(assetsManager, imageName, AssetClassID.Texture2D, out AssetsFileInstance? assetsFileInstance);
            if (baseField is null) return null;
            TextureFile textureFile = TextureFile.ReadTextureFile(baseField);
            Image<Bgra32> image = Image.LoadPixelData<Bgra32>(textureFile.GetTextureData(assetsFileInstance), textureFile.m_Width, textureFile.m_Height);
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

        private static AssetTypeValueField? GetFileBaseField(AssetsManager assetsManager, string objectName, AssetClassID classId, out AssetsFileInstance? assetsFileInstance)
        {
            assetsFileInstance = null;
            foreach (var file in assetsManager.Files)
            {
                foreach (var asset in file.file.GetAssetsOfType(classId))
                {
                    AssetTypeValueField baseField = assetsManager.GetBaseField(file, asset);
                    if (baseField["m_Name"].AsString.ToLower() == objectName)
                    {
                        assetsFileInstance = file;
                        return baseField;
                    }
                }
            }

            return null;
        }

        private static void LoadFiles(AssetsManager assetsManager, IEnumerable<string> filePaths)
        {
            //foreach (var file in filePaths)
            //{
            //    BundleFileInstance bundle = assetsManager.LoadBundleFile(file);
            //    foreach (var assetsFile in bundle.file.GetAllFileNames())
            //    {
            //        assetsManager.LoadAssetsFileFromBundle(bundle, assetsFile);
            //    }
            //}
            new LoadingForm(assetsManager, filePaths).ShowDialog();
        }

        private static string[] GetFilePaths(List<ManifestEntry> entries)
        {
            List<string> paths = new();
            foreach (ManifestEntry entry in entries)
            {
                string path = UmaDataHelper.GetPath(entry);
                if (path != string.Empty) paths.Add(path);
            }
            return paths.ToArray();
        }

        private static PinnedBitmap PinnedBitmapFromKey(string key) =>
            new(imagePointerContainers[key].ImageHandle.AddrOfPinnedObject(),
                imagePointerContainers[key].Width,
                imagePointerContainers[key].Height);
    }
}
