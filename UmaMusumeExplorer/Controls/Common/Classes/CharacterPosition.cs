﻿namespace UmaMusumeExplorer.Controls.Common.Classes
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
