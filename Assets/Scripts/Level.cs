using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int _wight;
        [SerializeField] private int _height;
        [SerializeField] private TileContentData _data;

        [SerializeField] private TileSpawner _tileSpawner;

        private void Start()
        {
            StartLevel();
        }

        public void Init(TileSpawner tileSpawner)
        {
            _tileSpawner = tileSpawner;
        }

        public void StartLevel()
        {
            _tileSpawner.CreateMap(_wight, _height , _data.GetTilesContent(_wight * _height).ToArray());
        }
    }
}