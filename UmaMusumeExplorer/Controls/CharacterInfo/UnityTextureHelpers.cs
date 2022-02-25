using AssetStudio;
using PlayerGui.Controls.CharacterInfo;
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

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    internal static class UnityTextureHelpers
    {
        private static AssetsManager assetsManager = new();

        public static void LoadFiles(params string[] paths)
        {
            assetsManager.LoadFiles(paths);
        }

        public static Bitmap GetCharaIcon(int id)
        {
            string idString = $"{id:d4}";
            string imageString = $"chr_icon_{idString}";
            if (idString == "0000") imageString = "chr_icon_round_0000";

            SerializedFile targetAsset = assetsManager.assetsFileList.Where(
                a => ((NamedObject)a.Objects.Where(o => o.type == ClassIDType.Texture2D).First()).m_Name.StartsWith(imageString)).First();
            Texture2D texture = (Texture2D)targetAsset.Objects.Where(o => o.type == ClassIDType.Texture2D).First();

            Image<Bgra32> image = texture.ConvertToImage(true);

            int adjustedHeight = (int)(image.Height * 1.10f);
            image.Mutate(o => o.Resize(image.Width, adjustedHeight));

            PinnedBitmap bitmap = new(image.ConvertToBgra32Bytes(), image.Width, adjustedHeight);
            return bitmap.Bitmap;
        }
    }
}
