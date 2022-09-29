using System;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    class PartTrigger
    {
        private static readonly int[] positionTable =
        {

        };

        public int TimeMs { get; }

        public int[] MemberTracks { get; }

        public float[] MemberVolumes { get; }

        public float[] MemberPans { get; }

        public float VolumeRate { get; }

        public PartTrigger(string partCsvLine, bool hasVolumeRate)
        {
            string[] columns = partCsvLine.Split(',');

            int activeMembers;

            int ignoreColumns = hasVolumeRate ? 2 : 1;

            if (columns.Length - ignoreColumns > 5)
                activeMembers = (columns.Length - ignoreColumns) / 3;
            else
                activeMembers = columns.Length - ignoreColumns;

            MemberTracks = new int[activeMembers];
            MemberVolumes = new float[activeMembers];
            MemberPans = new float[activeMembers];

            int currentIndex = 0;
            TimeMs = int.Parse(columns[currentIndex++]);

            int pivot = activeMembers / 2;

            for (int i = 0; i < activeMembers; i++)
            {
                MemberTracks[PositionToIndex(i, pivot)] = int.Parse(columns[currentIndex++]);
            }

            if (columns.Length - 1 > 5)
            {
                for (int i = 0; i < activeMembers; i++)
                {
                    MemberVolumes[PositionToIndex(i, pivot)] = float.Parse(columns[currentIndex++]);
                }
                for (int i = 0; i < activeMembers; i++)
                {
                    MemberPans[PositionToIndex(i, pivot)] = float.Parse(columns[currentIndex++]);
                }
            }
            else
            {
                for (int i = 0; i < activeMembers; i++)
                {
                    MemberVolumes[i] = 1.0f;
                    MemberPans[i] = 999;
                }
            }

            if (hasVolumeRate)
                VolumeRate = float.Parse(columns[currentIndex++]);
        }

        private static int PositionToIndex(int position, int pivot)
        {
            int distance = Math.Abs(pivot - position);
            int multiply = distance * 2;
            if (position < pivot) multiply -= 1;
            return multiply;
        }
    }
}
