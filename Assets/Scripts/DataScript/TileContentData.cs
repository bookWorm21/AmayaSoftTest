using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "new style", menuName = "Content/Style")]
    public class TileContentData : ScriptableObject
    {
        [SerializeField] private GameTileContent[] _contents;

        public IEnumerable<GameTileContent> GetTilesContent(int count)
        {
            if(count > _contents.Length)
            {
                throw new System.Exception("Недостаточно объектов для запроса");
            }

            var general = new List<GameTileContent>();
            for(int i = 0; i < _contents.Length; i++)
            {
                general.Add(_contents[i]);
            }

            for(int i = 0; i < count; i++)
            {
                var content = general[Random.Range(0, general.Count)];
                general.Remove(content);
                yield return content;
            }
        }
    }
}