using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeFiles;
using UmaMusumeFiles.Tables;
using AssetStudio;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Image = SixLabors.ImageSharp.Image;
using SixLabors.ImageSharp.Processing;
using open.imaging.S3TC;

namespace PlayerGui.Controls.CharacterInfo
{
    public partial class CharacterInfoControl : UserControl
    {
        private readonly List<CharaData> charaDatas;
        private readonly List<TextData> charaNameTextData;
        private readonly List<TextData> charaNameKatakanaTextData;
        private readonly List<TextData> charaVoiceNameTextData;

        private AssetsManager assetsManager;
        private PinnedBitmap charaBitmap;

        public CharacterInfoControl()
        {
            InitializeComponent();

            charaDatas = UmaFileHelper.GetInfoDatabaseRows<CharaData>();
            charaNameTextData = UmaFileHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 170);
            charaNameKatakanaTextData = UmaFileHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 182);
            charaVoiceNameTextData = UmaFileHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 7);

            List<string> imagePaths = new();
            Regex charIconRegex = new("\\bchr_icon_[0-9]{4}\\b");
            foreach (var item in UmaFileHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("chara/")))
            {

                if (charIconRegex.IsMatch(item.BaseName) || item.BaseName == "chr_icon_round_0000")
                    imagePaths.Add(UmaFileHelper.GetPath(item));

                //if (item.BaseName.Length == 13 || item.BaseName == "chr_icon_round_0000")
            }

            assetsManager = new();
            assetsManager.LoadFiles(imagePaths.ToArray());

            //UpdateImage(0);

            foreach (var item in charaDatas)
            {
                string charaName = charaNameTextData.Where(td => td.Index == item.Id).First().Text;
                characterSelectComboBox.Items.Add(new CharaComboBoxItem(item, charaName));
            }
        }

        private void CharacterSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            CharaComboBoxItem selectedCharacter = comboBox.SelectedItem as CharaComboBoxItem;

            int id = selectedCharacter.Id;

            characterNameLabel.Text = selectedCharacter.Name;
            string katakana = charaNameKatakanaTextData.Where(td => td.Index == id).First().Text;
            if (!katakana.Equals(characterNameLabel.Text))
                characterNameLabel.Text += $"（{charaNameKatakanaTextData.Where(td => td.Index == id).First().Text}）";
            characterNameLabel.BackColor = ColorFromHexString(selectedCharacter.CharaData.UIColorMain);
            if (GetBrightness(characterNameLabel.BackColor) > 144)
                characterNameLabel.ForeColor = System.Drawing.Color.Black;
            else
                characterNameLabel.ForeColor = System.Drawing.Color.White;

            characterVoiceNameLabel.Text = "CV. " + charaVoiceNameTextData.Where(td => td.Index == id).First().Text;
            characterVoiceNameLabel.BackColor = ColorFromHexString(selectedCharacter.CharaData.UIColorSub);
            if (GetBrightness(characterVoiceNameLabel.BackColor) > 128)
                characterVoiceNameLabel.ForeColor = System.Drawing.Color.Black;
            else
                characterVoiceNameLabel.ForeColor = System.Drawing.Color.White;

            UpdateImage(id);
        }

        private void UpdateImage(int id)
        {
            if (DesignMode)
                return;

            string idString = $"{id:d4}";
            string imageString = $"chr_icon_{idString}";
            if (idString == "0000") imageString = "chr_icon_round_0000";

            //string charaImage = $"chara/chr{idString}/chr_icon_{idString}";
            //GameAsset imageAsset = UmaFileHelper.GetGameAssetDataRows(ga => ga.Name == charaImage)[0];
            //string imagePath = UmaFileHelper.GetPath(imageAsset);

            //AssetsManager assetsManager = new();
            //assetsManager.LoadFiles(new[] { imagePath });
            //Texture2D texture = (Texture2D)assetsManager.assetsFileList[0].Objects.Where(o => o.type == ClassIDType.Texture2D).First();
            SerializedFile targetAsset = assetsManager.assetsFileList.Where(
                a => ((NamedObject)a.Objects.Where(o => o.type == ClassIDType.Texture2D).First()).m_Name == imageString).First();
            Texture2D texture = (Texture2D)targetAsset.Objects.Where(o => o.type == ClassIDType.Texture2D).First();
            Image<Bgra32> image = ConvertToImage(texture, true);
            image.Mutate(o => o.Resize((int)(image.Width * 1.10f), image.Height));

            if (charaBitmap != null)
            {
                charaBitmap.Dispose();
            }

            charaBitmap = new(ConvertToBgra32Bytes(image), texture.m_Width, texture.m_Height);
            pictureBox1.Image = charaBitmap.Bitmap;
        }

        private void CharacterInfoControl_Load(object sender, EventArgs e)
        {
            //characterNameLabel.Text = DesignMode ? "Epic!" : "Bruh";
            UpdateImage(0);
        }

        private static byte GetBrightness(System.Drawing.Color color)
        {
            return (byte)((color.R + color.R + color.B + color.G + color.G) / 6);
        }

        private System.Drawing.Color ColorFromHexString(string hexString)
        {
            byte a = 0xFF;
            byte r = Convert.FromHexString(hexString[..2])[0];
            byte g = Convert.FromHexString(hexString[2..4])[0];
            byte b = Convert.FromHexString(hexString[4..6])[0];

            return System.Drawing.Color.FromArgb(a, r, g, b);
        }

        private unsafe Image<Bgra32> ConvertToImage(Texture2D m_Texture2D, bool flip)
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

    class CharaComboBoxItem
    {
        public CharaComboBoxItem(CharaData charaData, string charaName)
        {
            CharaData = charaData;
            Id = charaData.Id;
            Name = charaName;
        }

        public CharaData CharaData { get; }

        public int Id { get; }

        public string Name { get; }

        public override string ToString()
        {
            return Id + ": " + Name;
        }
    }
}
