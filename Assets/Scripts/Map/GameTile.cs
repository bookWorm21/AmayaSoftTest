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
        [SerializeField] private AnimationCurve _curve;

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
            Vector3 startScale = _spriteRenderer.transform.localScale;
            _spriteRenderer.transform.DOScale(startScale.x * 1.3f, 0.5f);
            _spriteRenderer.transform.DOScale(startScale.x, 0.5f).SetDelay(0.5f);
        }

        public void OnUncorrectlySelect()
        {
            
        }

        public void Activate(bool withEffect)
        {
            gameObject.SetActive(true);
            IsActive = true;

            if (withEffect)
            {
                gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                gameObject.transform.DOScale(_size.x, 2);
            }
        }

        public void Disactivate()
        {
            gameObject.SetActive(false);
            IsActive = false;
        }
    }
}