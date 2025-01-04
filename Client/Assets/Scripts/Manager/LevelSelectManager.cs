using Core.Data;
using Core.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.GameLogic
{
    public class LevelSelectManager : MonoBehaviour
    {
        public static LevelSelectManager Instance { get; private set; }
        public GameSO gameSO;
        public MapLevelUI mapLevelUI;
        private void Awake()
        {
            Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            mapLevelUI.ShowMapList(gameSO.mapArray);
        }

        public void SetSelectedMap(int mapID)
        {
            gameSO.selectedMapID = mapID;
        }
        public void SetSelectedLevel(int levelID)
        {
            gameSO.selectedLevelID = levelID;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public int[] GetSelectedMap()
        {
            return gameSO.mapArray[gameSO.selectedMapID - 1].starNumberOfLevel;
        }

    }
}
