using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class TileSpawner : MonoBehaviour
    {
        [SerializeField] private Pool _pool;
        [SerializeField] private Vector2 _center;

        private List<GameTile> _lastTiles = new List<GameTile>();
        private Vector2 _tileSize;

        public void CreateMap(int wight, int height, GameTileContent[] contents, bool withEffect)
        {
            var tileTemp = _pool.GetTile();
            _tileSize = tileTemp.Size;
            foreach (var tile in _lastTiles)
            {
                tile.Disactivate();
            }
            _lastTiles.Clear();

            if(contents.Length != wight * height)
            {
                throw new System.Exception("Количество объектов не равно количеству ячеек");
            }

            Vector2 startSpawnPosition;
            startSpawnPosition.x = _center.x - ((float)wight / 2 - 0.5f) * _tileSize.x;
            startSpawnPosition.y = _center.y - ((float)height / 2 - 0.5f) * _tileSize.y;

            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < wight; j++)
                {
                    var tile = _pool.GetTile();
                    var position = startSpawnPosition;
                    position.x += j * _tileSize.x;
                    position.y += i * _tileSize.y;
                    tile.transform.position = position;
                    tile.Activate(withEffect);
                    tile.SetGameTileContent(contents[i * wight + j]);
                    _lastTiles.Add(tile);
                }
            }
        }
    }
}