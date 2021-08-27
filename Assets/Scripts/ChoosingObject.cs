using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChoosingObject : MonoBehaviour
    {
        [SerializeField] private LayerMask _tileLayer;
        [SerializeField] private LevelSwitcher _levelSwitcher;

        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
            _levelSwitcher.StartedLevel += () => enabled = true;
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D result = Physics2D.Raycast(mousePosition, ray.direction, 5.0f, _tileLayer);
                if (result.collider != null)
                {
                    if(result.collider.TryGetComponent(out GameTile tile))
                    {
                        if(tile.TileContent == _levelSwitcher.RightTile)
                        {
                            tile.OnCorrectlySelect();
                            _levelSwitcher.GoNextLevel();
                            enabled = false;
                        }
                        else
                        {
                            tile.OnUncorrectlySelect();
                        }
                    }
                }
            }
        }
    }
}