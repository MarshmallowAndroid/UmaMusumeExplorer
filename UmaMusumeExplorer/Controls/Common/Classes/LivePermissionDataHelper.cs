﻿using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.Common.Classes
{
    static class LivePermissionDataHelper
    {
        public static IEnumerable<LivePermissionData> GetLivePermissionData(int musicId)
        {
            List<LivePermissionData> livePermissionData = AssetTables.LivePermissionDatas.Where(lpd => lpd.MusicId == musicId).ToList();

            var matches = UmaDataHelper.GetManifestEntries(ga => ga.BaseName.StartsWith($"snd_bgm_live_{musicId}_chara_") && ga.BaseName.EndsWith(".awb"));
            foreach (var audioAsset in matches)
            {
                int charaId = int.Parse(audioAsset.BaseName.Remove(0, $"snd_bgm_live_{musicId}_chara_".Length)[..4]);

                if (livePermissionData is not List<LivePermissionData> list) continue;
                list.Add(new LivePermissionData() { MusicId = musicId, CharaId = charaId });
            }

            return livePermissionData;
        }
    }
}
