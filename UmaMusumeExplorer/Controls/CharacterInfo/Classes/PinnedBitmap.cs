using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace UmaMusumeExplorer.Controls.CharacterInfo.Classes
{
    class PinnedBitmap : IDisposable
    {
        private readonly GCHandle bitmapHandle;
        private readonly Bitmap bitmap;

        public PinnedBitmap(byte[] imageBytes, int width, int height)
        {
            bitmapHandle = GCHandle.Alloc(imageBytes, GCHandleType.Pinned);
            bitmap = new Bitmap(
                width,
                height,
                width * 4,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb,
                bitmapHandle.AddrOfPinnedObject());
        }

        public Bitmap Bitmap => bitmap;

        public void Dispose()
        {
            bitmap.Dispose();
            bitmapHandle.Free();
        }
    }
}
