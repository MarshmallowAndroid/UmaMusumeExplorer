﻿using AssetStudio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using UmaMusumeData;

namespace UmaMusumeExplorer.Game
{
    static class UnityAssets
    {
        private static readonly AssetsManager charaIconAssetsManager = new();
        private static readonly AssetsManager skillIconAssetsManager = new();
        private static readonly AssetsManager jacketsAssetsManager = new();
        private static readonly AssetsManager generalAssetsManager = new();
        private static readonly Dictionary<string, ImagePointerContainer> imagePointerContainers = new();

        private static bool charaIconsLoaded = false;
        private static bool skillIconsLoaded = false;
        private static bool jacketIconsLoaded = false;

        public static void ClearLoadedFiles()
        {
            foreach (var imagePointerContainers in imagePointerContainers)
            {
                imagePointerContainers.Value.ImageHandle.Free();
            }

            charaIconAssetsManager.Clear();
            skillIconAssetsManager.Clear();
            jacketsAssetsManager.Clear();
            generalAssetsManager.Clear();
            imagePointerContainers.Clear();
        }

        public static PinnedBitmap GetCharaIcon(int id, int raceDressId = 0, int plate = 1)
        {
            if (!charaIconsLoaded)
            {
                Regex chrIconRegex = new(@"\bchr_icon_[0-9]{4}\b");
                Regex chrCardIconRegex = new(@"\bchr_icon_[0-9]{4}_[0-9]{6}_[0-9]{2}\b");

                List<string> imagePaths = new();
                List<GameAsset> charaAssetRows = UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("chara/"));
                charaAssetRows.ForEach(c =>
                {
                    if (chrIconRegex.IsMatch(c.BaseName) || chrCardIconRegex.IsMatch(c.BaseName) || c.BaseName.Equals("chr_icon_round_0000"))
                        imagePaths.Add(UmaDataHelper.GetPath(c));
                });

                charaIconAssetsManager.LoadFiles(imagePaths.ToArray());

                charaIconsLoaded = true;
            }

            string idString = $"{id:d4}";

            StringBuilder imageStringBuilder = new();
            imageStringBuilder.Append($"chr_icon_{idString}");
            if (idString.Equals("0000"))
            {
                imageStringBuilder.Clear();
                imageStringBuilder.Append("chr_icon_round_0000");
            }

            if (raceDressId > 0)
                imageStringBuilder.Append($"_{raceDressId:d6}_{plate:d2}");

            string imageString = imageStringBuilder.ToString();

            if (imagePointerContainers.ContainsKey(imageString)) return PinnedBitmapFromKey(imageString);

            SerializedFile targetAsset = GetFile(charaIconAssetsManager, imageString, ClassIDType.Texture2D);
            Texture2D texture = targetAsset.Objects.First(o => o.type == ClassIDType.Texture2D) as Texture2D;

            Image<Bgra32> image = texture.ConvertToImage(true);

            int adjustedHeight = (int)(image.Height * 1.115F);
            image.Mutate(o => o.Resize(image.Width, adjustedHeight));

            imagePointerContainers.Add(imageString,
                new ImagePointerContainer(
                   GCHandle.Alloc(image.ConvertToBytes(), GCHandleType.Pinned), image.Width, adjustedHeight));

            return PinnedBitmapFromKey(imageString);
        }

        public static PinnedBitmap GetSkillIcon(int id)
        {
            if (!skillIconsLoaded)
            {
                List<GameAsset> skillIconAssetRows = UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("outgame/skillicon/utx_ico_skill_"));
                skillIconAssetsManager.LoadFiles(GetFilePaths(skillIconAssetRows));
                skillIconsLoaded = true;
            }

            string idString;

            if (id == 0)
                idString = "00000";
            else
                idString = id.ToString();

            StringBuilder imageStringBuilder = new();
            imageStringBuilder.Append($"utx_ico_skill_{idString}");

            string imageString = imageStringBuilder.ToString();

            if (imagePointerContainers.ContainsKey(imageString)) return PinnedBitmapFromKey(imageString);

            SerializedFile targetAsset = GetFile(skillIconAssetsManager, imageString, ClassIDType.Texture2D);
            Texture2D texture = targetAsset.Objects.First(o => o.type == ClassIDType.Texture2D) as Texture2D;

            Image<Bgra32> image = texture.ConvertToImage(true);

            imagePointerContainers.Add(imageString,
                new ImagePointerContainer(
                   GCHandle.Alloc(image.ConvertToBytes(), GCHandleType.Pinned), image.Width, image.Height));

            return PinnedBitmapFromKey(imageString);
        }

        public static PinnedBitmap GetJacket(int musicId, char size = 'm')
        {
            if (!jacketIconsLoaded)
            {
                List<GameAsset> liveJacketAssetRows = UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("live/jacket/jacket_icon_l_"));
                jacketsAssetsManager.LoadFiles(GetFilePaths(liveJacketAssetRows));
                jacketIconsLoaded = true;
            }

            string idString = $"{musicId:d4}";

            StringBuilder imageStringBuilder = new();
            imageStringBuilder.Append($"jacket_icon_{size}_{idString}");

            string imageString = imageStringBuilder.ToString();

            if (imagePointerContainers.ContainsKey(imageString)) return PinnedBitmapFromKey(imageString);

            SerializedFile targetAsset = GetFile(jacketsAssetsManager, imageString, ClassIDType.Texture2D);
            targetAsset ??= GetFile(jacketsAssetsManager, $"jacket_icon_{size}_0000", ClassIDType.Texture2D);
            Texture2D texture = targetAsset.Objects.First(o => o.type == ClassIDType.Texture2D) as Texture2D;

            Image<Bgra32> image = texture.ConvertToImage(true);

            imagePointerContainers.Add(imageString,
                new ImagePointerContainer(
                   GCHandle.Alloc(image.ConvertToBytes(), GCHandleType.Pinned), image.Width, image.Height));

            return PinnedBitmapFromKey(imageString);
        }

        public static StreamReader GetLiveCsv(int musicId, string category)
        {
            string idString = $"{musicId:d4}";

            SerializedFile targetAsset = GetFile(generalAssetsManager, $"m{idString}_{category}", ClassIDType.TextAsset);
            if (targetAsset is null) return null;
            TextAsset textAsset = targetAsset.Objects.First(o => o.type == ClassIDType.TextAsset) as TextAsset;

            return new StreamReader(new MemoryStream(textAsset.m_Script));
        }

        private static string[] GetFilePaths(List<GameAsset> gameAssets)
        {
            List<string> paths = new();

            foreach (GameAsset asset in gameAssets)
            {
                string path = UmaDataHelper.GetPath(asset);
                if (path != string.Empty) paths.Add(path);
            }

            return paths.ToArray();
        }

        private static SerializedFile GetFile(AssetsManager assetsManager, string objectName, ClassIDType classIdType)
        {
            return assetsManager.assetsFileList.FirstOrDefault(
                a => (a.Objects.FirstOrDefault(o => o.type == classIdType) as NamedObject)?.m_Name.Equals(objectName) ?? false);
        }

        private static PinnedBitmap PinnedBitmapFromKey(string key) =>
            new(imagePointerContainers[key].ImageHandle.AddrOfPinnedObject(),
                imagePointerContainers[key].Width,
                imagePointerContainers[key].Height);
    }

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
