using Core.Data;
using Core.UI;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.GameLogic
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public GameSO gameSO;

        public Bird[] birdList;
        private int index = -1;

        public int pigTotalCount;
        public int pigDeadCount;

        private FollowTarget cameraFollowTarget;

        public GameOverUI gameOverUI;

        private void Awake()
        {
            Instance = this;
            pigDeadCount = 0;
            LoadSelectedLevel();
        }

        // Start is called before the first frame update
        void Start()
        {
            birdList = FindObjectsByType<Bird>(FindObjectsSortMode.None);
            pigTotalCount = (FindObjectsByType<Pig>(FindObjectsSortMode.None)).Length;
            cameraFollowTarget = Camera.main.GetComponent<FollowTarget>();

            LoadNextBird();
        }

        private void LoadSelectedLevel()
        {
            Time.timeScale = 1;
            int mapID = gameSO.selectedMapID;
            int levelID = gameSO.selectedLevelID;
            GameObject levelPrefab = Resources.Load<GameObject>("Map" + mapID + "/" + "Level" + levelID);
            GameObject.Instantiate(levelPrefab);
        }

        public void LoadNextBird()
        {
            index++;

            if (index >= birdList.Length)
            {
                GameOver();
            }
            else
            {
                // ��ʼ�����״̬��׼��
                birdList[index].GoStage(Slingshot.Instance.getCenterPositon());
                // �����������Ŀ��
                cameraFollowTarget.SetTarget(birdList[index].transform);
            }

        }
        public void OnPigDead()
        {
            pigDeadCount++;

            if (pigDeadCount >= pigTotalCount)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            int starCount = 0;
            float pigDeadPercent = pigDeadCount * 1f / pigTotalCount;

            if (pigDeadPercent > 0.99f)
            {
                starCount = 3;
            }
            else if (pigDeadPercent > 0.66f)
            {
                starCount = 2;
            }
            else if (pigDeadPercent > 0.33f)
            {
                starCount = 1;
            }
            gameOverUI.Show(starCount);

            gameSO.UpdateLevel(starCount);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void LevelList()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        //1���ؽ���   2��ͼ�͹ؿ�ѡ��  3��Ϸ����
    }
}
