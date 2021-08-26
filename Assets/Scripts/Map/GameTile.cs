using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameTile : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Vector2 _size;

        private GameTileContent _gameTileContent;

        public bool IsActive { get; private set; }

        public Vector2 Size => _size;

        public void SetGameTileContent(GameTileContent gameTileContent)
        {
            _gameTileContent = gameTileContent;
            _spriteRenderer.sprite = _gameTileContent.Sprite;
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            IsActive = true;
        }

        public void Disactivate()
        {
            gameObject.SetActive(false);
            IsActive = false;
        }
    }
}