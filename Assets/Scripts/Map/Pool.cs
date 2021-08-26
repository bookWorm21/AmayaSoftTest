using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private GameTile _prefab;
        [SerializeField] private int _startPoolSize;
        [SerializeField] private Transform _container;

        private List<GameTile> _tiles = new List<GameTile>();

        private void Start()
        {
            for(int i = 0; i < _startPoolSize; i++)
            {
                var inst = Instantiate(_prefab, _container);
                inst.gameObject.SetActive(false);
                _tiles.Add(inst);
            }
        }

        public GameTile GetTile()
        {
            var tile = _tiles.FirstOrDefault(p => p.IsActive == false);
            if(tile != null)
            {
                return tile;
            }

            tile = Instantiate(_prefab, _container);
            tile.gameObject.SetActive(false);
            _tiles.Add(tile);
            return tile;
        }
    }
}