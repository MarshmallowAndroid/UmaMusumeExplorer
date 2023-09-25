using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    internal struct CharacterPosition
    {
        public int CharacterId;
        public int Position;

        public CharacterPosition(int characterId, int position)
        {
            CharacterId = characterId;
            Position = position;
        }
    }
}
