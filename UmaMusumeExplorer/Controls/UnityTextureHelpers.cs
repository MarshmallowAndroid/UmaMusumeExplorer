using AssetStudio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;
using Image = SixLabors.ImageSharp.Image;

namespace UmaMusumeExplorer.Controls
{
    internal static class UnityTextureHelpers
    {
        private static readonly AssetsManager assetsManager = new();

        public static void LoadFiles(params string[] paths)
        {
            assetsManager.LoadFiles(paths);
        }

        public static Bitmap GetCharaIcon(int id, int raceDressId = 0)
        {
            string idString = $"{id:d4}";

            StringBuilder imageString = new();
            imageString.Append($"chr_icon_{idString}");
            if (idString == "0000")
            {
                imageString.Clear();
                imageString.Append("chr_icon_round_0000");
            }

            if (raceDressId > 0)
                imageString.Append($"_{raceDressId:d6}_02");

            SerializedFile targetAsset = GetImageFile(imageString.ToString());
            Texture2D texture = targetAsset.Objects.Where(o => o.type == ClassIDType.Texture2D).First() as Texture2D;

            Image<Bgra32> image = texture.ConvertToImage(true);

            int adjustedHeight = (int)(image.Height * 1.115f);
            image.Mutate(o => o.Resize(image.Width, adjustedHeight));

            PinnedBitmap bitmap = new(image.ConvertToBytes(), image.Width, adjustedHeight);
            return bitmap.Bitmap;
        }

        public static Bitmap GetJacket(int musicId, int size = 0)
        {
            string idString = $"{musicId:d4}";

            StringBuilder imageString = new();
            imageString.Append($"jacket_icon_{(size == 0 ? 'm' : 'l')}_{idString}");

            SerializedFile targetAsset = GetImageFile(imageString.ToString());
            if (targetAsset is null) targetAsset = GetImageFile($"jacket_icon_{(size == 0 ? 'm' : 'l')}_0000");
            Texture2D texture = targetAsset.Objects.Where(o => o.type == ClassIDType.Texture2D).First() as Texture2D;

            Image<Bgra32> image = texture.ConvertToImage(true);

            //int adjustedHeight = (int)(image.Height * 1.115f);
            //image.Mutate(o => o.Resize(image.Width, adjustedHeight));

            PinnedBitmap bitmap = new(image.ConvertToBytes(), image.Width, image.Height);
            return bitmap.Bitmap;
        }

        private static SerializedFile GetImageFile(string objectName)
        {
            return assetsManager.assetsFileList.Where(
                a => (a.Objects.Where(o => o.type == ClassIDType.Texture2D).First() as NamedObject).m_Name.Equals(objectName)).FirstOrDefault();
        }
    }
}
