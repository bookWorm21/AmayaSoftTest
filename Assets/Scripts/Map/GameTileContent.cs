using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class GameTileContent
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _gameName;

        public Sprite Sprite => _sprite;

        public string Name => _gameName;
    }
}