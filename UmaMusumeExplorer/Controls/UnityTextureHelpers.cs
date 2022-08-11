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
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;
using Image = SixLabors.ImageSharp.Image;

namespace UmaMusumeExplorer.Controls
{
    internal static class UnityAssetHelpers
    {
        private static readonly AssetsManager assetsManager = new();

        public static void LoadFiles(params string[] paths)
        {
            assetsManager.LoadFiles(paths);
        }

        public static void ClearLoadedFiles()
        {
            assetsManager.Clear();
        }

        public static Bitmap GetCharaIcon(int id, int raceDressID = 0)
        {
            string idString = $"{id:d4}";

            StringBuilder imageString = new();
            imageString.Append($"chr_icon_{idString}");
            if (idString == "0000")
            {
                imageString.Clear();
                imageString.Append("chr_icon_round_0000");
            }

            if (raceDressID > 0)
                imageString.Append($"_{raceDressID:d6}_02");

            SerializedFile targetAsset = GetFile(imageString.ToString(), ClassIDType.Texture2D);
            Texture2D texture = targetAsset.Objects.Where(o => o.type == ClassIDType.Texture2D).First() as Texture2D;

            Image<Bgra32> image = texture.ConvertToImage(true);

            int adjustedHeight = (int)(image.Height * 1.115f);
            image.Mutate(o => o.Resize(image.Width, adjustedHeight));

            PinnedBitmap bitmap = new(image.ConvertToBytes(), image.Width, adjustedHeight);
            return bitmap.Bitmap;
        }

        public static Bitmap GetJacket(int musicID, char size = 'm')
        {
            string idString = $"{musicID:d4}";

            StringBuilder imageString = new();
            imageString.Append($"jacket_icon_{size}_{idString}");

            SerializedFile targetAsset = GetFile(imageString.ToString(), ClassIDType.Texture2D);
            if (targetAsset is null) targetAsset = GetFile($"jacket_icon_{size}_0000", ClassIDType.Texture2D);
            Texture2D texture = targetAsset.Objects.Where(o => o.type == ClassIDType.Texture2D).First() as Texture2D;

            Image<Bgra32> image = texture.ConvertToImage(true);

            //int adjustedHeight = (int)(image.Height * 1.115f);
            //image.Mutate(o => o.Resize(image.Width, adjustedHeight));

            PinnedBitmap bitmap = new(image.ConvertToBytes(), image.Width, image.Height);
            return bitmap.Bitmap;
        }

        public static StreamReader GetLiveCsv(int musicID, string category)
        {
            string idString = $"{musicID:d4}";

            SerializedFile targetAsset = GetFile($"m{idString}_{category}", ClassIDType.TextAsset);
            if (targetAsset is null) return null;
            TextAsset textAsset = targetAsset.Objects.Where(o => o.type == ClassIDType.TextAsset).First() as TextAsset;

            return new StreamReader(new MemoryStream(textAsset.m_Script));
        }

        private static SerializedFile GetFile(string objectName, ClassIDType classIDType)
        {
            return assetsManager.assetsFileList.Where(
                a => (a.Objects.Where(o => o.type == classIDType).FirstOrDefault() as NamedObject)?.m_Name.Equals(objectName) ?? false).FirstOrDefault();
        }
    }
}
