using AssetStudio;
using open.imaging.S3TC;
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
            Image<Bgra32> image = ConvertToImage(texture, true);

            int adjustedHeight = (int)(image.Height * 1.10f);
            image.Mutate(o => o.Resize(image.Width, adjustedHeight));

            PinnedBitmap bitmap = new(ConvertToBgra32Bytes(image), image.Width, adjustedHeight);
            return bitmap.Bitmap;
        }

        private static unsafe Image<Bgra32> ConvertToImage(Texture2D m_Texture2D, bool flip)
        {
            var buff = BigArrayPool<byte>.Shared.Rent(m_Texture2D.m_Width * m_Texture2D.m_Height * 4);
            var buff2 = BigArrayPool<byte>.Shared.Rent(m_Texture2D.image_data.Size);
            m_Texture2D.image_data.GetData(buff2);

            try
            {
                fixed (byte* data = buff2)
                {
                    fixed (byte* image = buff)
                    {
                        DXT5Decoder.Decode((uint)m_Texture2D.m_Width, (uint)m_Texture2D.m_Height, data, image);
                    }
                }
                if (buff.Length > 0)
                {
                    var image = Image.LoadPixelData<Bgra32>(buff, m_Texture2D.m_Width, m_Texture2D.m_Height);
                    if (flip)
                    {
                        image.Mutate(x => x.Flip(FlipMode.Vertical));
                    }
                    return image;
                }
                return null;
            }
            finally
            {
                BigArrayPool<byte>.Shared.Return(buff);
            }
        }

        private static byte[] ConvertToBgra32Bytes(Image<Bgra32> image)
        {
            if (image.DangerousTryGetSinglePixelMemory(out var pixelMemory))
            {
                return MemoryMarshal.AsBytes(pixelMemory.Span).ToArray();
            }
            return null;
        }
    }
}
