using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class GameTile : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Vector2 _size;

        public GameTileContent TileContent { get; private set;}

        public bool IsActive { get; private set; }

        public Vector2 Size => _size;

        public void SetGameTileContent(GameTileContent gameTileContent)
        {
            TileContent = gameTileContent;
            _spriteRenderer.sprite = TileContent.Sprite;
        }

        public void OnCorrectlySelect()
        {

        }

        public void OnUncorrectlySelect()
        {

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