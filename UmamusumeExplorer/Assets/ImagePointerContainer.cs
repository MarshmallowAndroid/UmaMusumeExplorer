using System.Runtime.InteropServices;

namespace UmamusumeExplorer.Assets
{
    class ImagePointerContainer
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
