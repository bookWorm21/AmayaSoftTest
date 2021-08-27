using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

namespace Assets.Scripts
{
    public class LevelSwitcher : MonoBehaviour
    {
        [SerializeField] private Level[] _levels;
        [SerializeField] private TMP_Text _findingObjectName;
        [SerializeField] private float _delayAFterCorrectSelecting;
        [SerializeField] private Button _restartButton;

        [SerializeField] private GameObject _container;
        [SerializeField] private TMP_Text[] _textes;

        [SerializeField] private TileSpawner _tileSpawner;

        private Level _currentLevel;
        private int _currentLevelIndex;
        private List<GameTileContent> _selectedContents = new List<GameTileContent>();

        public  GameTileContent RightTile { get; private set; }

        public event UnityAction StartedLevel;
        public event UnityAction EndedLevels;

        private void Start()
        {
            StartOver();
            _restartButton.onClick.AddListener(StartOver);
        }

        public void Init(TileSpawner tileSpawner)
        {
            _tileSpawner = tileSpawner;
        }

        public void GoNextLevel()
        {
            StartCoroutine(GoNextLevelWithDelay());
        }

        public void StartOver()
        {
            foreach(var text in _textes)
            {
                text.DOFade(0, 0);
                text.DOFade(1, 2);
            }

            _currentLevelIndex = 0;
            _currentLevel = _levels[_currentLevelIndex];
            StartCurrentLevel(true);
            _restartButton.gameObject.SetActive(false);
            _selectedContents.Clear();
        }

        private IEnumerator GoNextLevelWithDelay()
        {
            yield return new WaitForSeconds(_delayAFterCorrectSelecting);

            _currentLevelIndex++;
            if (_currentLevelIndex >= _levels.Length)
            {
                _restartButton.gameObject.SetActive(true);
                EndedLevels?.Invoke();
            }
            else
            {
                _currentLevel = _levels[_currentLevelIndex];
                StartCurrentLevel(false);
            }
        }

        private void StartCurrentLevel(bool withEffect)
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
            _tileSpawner.CreateMap(_currentLevel.Wight, _currentLevel.Height, contents, withEffect);

            StartedLevel?.Invoke();
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