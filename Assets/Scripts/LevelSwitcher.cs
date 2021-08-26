using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class LevelSwitcher : MonoBehaviour
    {
        [SerializeField] private Level[] _levels;
        [SerializeField] private TMP_Text _findingObjectName;

        [SerializeField] private TileSpawner _tileSpawner;

        private Level _currentLevel;
        private int _currentLevelIndex;
        private List<GameTileContent> _selectedContents = new List<GameTileContent>();

        public  GameTileContent RightTile { get; private set; }

        public event UnityAction EndedLevels;

        private void Start()
        {
            _currentLevelIndex = 0;
            _currentLevel = _levels[_currentLevelIndex];
            StartCurrentLevel();
        }

        public void Init(TileSpawner tileSpawner)
        {
            _tileSpawner = tileSpawner;
        }

        public void GoNextLevel()
        {
            _currentLevelIndex++;
            if(_currentLevelIndex >= _levels.Length)
            {
                EndedLevels?.Invoke();
            }
            else
            {
                _currentLevel = _levels[_currentLevelIndex];
                StartCurrentLevel();
            }
        }

        private void StartCurrentLevel()
        {
            GameTileContent[] contents = _currentLevel.TileContentData.GetTilesContent(_currentLevel.Wight * _currentLevel.Height).ToArray();

            GameTileContent rightSelected = null;
            do
            {
                rightSelected = contents[Random.Range(0, contents.Length)];
            }
            while (_selectedContents.Contains(rightSelected));

            RightTile = rightSelected;
            _selectedContents.Add(rightSelected);
            _findingObjectName.text = RightTile.Name;
            _tileSpawner.CreateMap(_currentLevel.Wight, _currentLevel.Height, contents);
        }

        [System.Serializable]
        class Level
        {
            [SerializeField] private int _wight;
            [SerializeField] private int _height;
            [SerializeField] private TileContentData _tileContentData;

            public int Wight => _wight;

            public int Height => _height;


            public TileContentData TileContentData => _tileContentData;
        }
    }
}