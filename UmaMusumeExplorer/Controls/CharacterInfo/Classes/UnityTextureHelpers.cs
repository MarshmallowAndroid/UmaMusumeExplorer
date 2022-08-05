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
using Image = SixLabors.ImageSharp.Image;

namespace UmaMusumeExplorer.Controls.CharacterInfo.Classes
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

            SerializedFile targetAsset = assetsManager.assetsFileList.Where(
                a => (a.Objects.Where(o => o.type == ClassIDType.Texture2D).First() as NamedObject).m_Name.Equals(imageString.ToString())).First();
            Texture2D texture = targetAsset.Objects.Where(o => o.type == ClassIDType.Texture2D).First() as Texture2D;

            Image<Bgra32> image = texture.ConvertToImage(true);

            int adjustedHeight = (int)(image.Height * 1.115f);
            image.Mutate(o => o.Resize(image.Width, adjustedHeight));

            PinnedBitmap bitmap = new(image.ConvertToBytes(), image.Width, adjustedHeight);
            return bitmap.Bitmap;
        }
    }
}
