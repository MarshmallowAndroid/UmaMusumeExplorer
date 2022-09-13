using AssetStudio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Image = SixLabors.ImageSharp.Image;

namespace UmaMusumeExplorer.Controls
{
    internal static class UnityAssetHelpers
    {
        private static readonly AssetsManager assetsManager = new();
        private static readonly Dictionary<string, ImagePointerContainer> imagePointerContainers = new();

        public static void LoadFiles(params string[] paths)
        {
            assetsManager.LoadFiles(paths);
        }

        public static void ClearLoadedFiles()
        {
            foreach (var imagePointerContainers in imagePointerContainers)
            {
                imagePointerContainers.Value.ImageHandle.Free();
            }
            imagePointerContainers.Clear();
            assetsManager.Clear();
        }

        public static PinnedBitmap GetCharaIcon(int id, int raceDressId = 0)
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
                imageStringBuilder.Append($"_{raceDressId:d6}_02");

            string imageString = imageStringBuilder.ToString();

            if (imagePointerContainers.ContainsKey(imageString)) return PinnedBitmapFromKey(imageString);

            SerializedFile targetAsset = GetFile(imageString, ClassIDType.Texture2D);
            Texture2D texture = targetAsset.Objects.Where(o => o.type == ClassIDType.Texture2D).First() as Texture2D;

            Image<Bgra32> image = texture.ConvertToImage(true);

            int adjustedHeight = (int)(image.Height * 1.115f);
            image.Mutate(o => o.Resize(image.Width, adjustedHeight));

            imagePointerContainers.Add(imageString,
                new ImagePointerContainer(
                   GCHandle.Alloc(image.ConvertToBytes(), GCHandleType.Pinned), image.Width, adjustedHeight));

            return PinnedBitmapFromKey(imageString);
        }

        public static PinnedBitmap GetJacket(int musicId, char size = 'm')
        {
            string idString = $"{musicId:d4}";

            StringBuilder imageStringBuilder = new();
            imageStringBuilder.Append($"jacket_icon_{size}_{idString}");

            string imageString = imageStringBuilder.ToString();

            if (imagePointerContainers.ContainsKey(imageString)) return PinnedBitmapFromKey(imageString);

            SerializedFile targetAsset = GetFile(imageString, ClassIDType.Texture2D);
            if (targetAsset is null) targetAsset = GetFile($"jacket_icon_{size}_0000", ClassIDType.Texture2D);
            Texture2D texture = targetAsset.Objects.Where(o => o.type == ClassIDType.Texture2D).First() as Texture2D;

            Image<Bgra32> image = texture.ConvertToImage(true);

            imagePointerContainers.Add(imageString,
                new ImagePointerContainer(
                   GCHandle.Alloc(image.ConvertToBytes(), GCHandleType.Pinned), image.Width, image.Height));

            return PinnedBitmapFromKey(imageString);
        }

        public static StreamReader GetLiveCsv(int musicId, string category)
        {
            string idString = $"{musicId:d4}";

            SerializedFile targetAsset = GetFile($"m{idString}_{category}", ClassIDType.TextAsset);
            if (targetAsset is null) return null;
            TextAsset textAsset = targetAsset.Objects.Where(o => o.type == ClassIDType.TextAsset).First() as TextAsset;

            return new StreamReader(new MemoryStream(textAsset.m_Script));
        }

        private static SerializedFile GetFile(string objectName, ClassIDType classIdType)
        {
            return assetsManager.assetsFileList.Where(
                a => (a.Objects.Where(o => o.type == classIdType).FirstOrDefault() as NamedObject)?.m_Name.Equals(objectName) ?? false).FirstOrDefault();
        }

        private static PinnedBitmap PinnedBitmapFromKey(string key) =>
            new PinnedBitmap(
                imagePointerContainers[key].ImageHandle.AddrOfPinnedObject(),
                imagePointerContainers[key].Width,
                imagePointerContainers[key].Height);
    }

    internal class ImagePointerContainer
    {
        public ImagePointerContainer(GCHandle imageHandle, int width, int height)
        {
            ImageHandle = imageHandle;
            Width = width;
            Height = height;
        }

        public GCHandle ImageHandle { get; }

        public int Width { get; }

        public int Height { get; }
    }
}
