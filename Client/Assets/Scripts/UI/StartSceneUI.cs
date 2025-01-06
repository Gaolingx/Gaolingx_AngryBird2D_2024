using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.UI
{
    public class StartSceneUI : MonoBehaviour
    {
        public Slider Slider_LoadProgress;
        public GameObject GameObj_ProgressPanel;
        public Image Img_LoadTxtBg;
        public GameObject GameObj_Start;
        public Button Btn_Exit;

        private Button Btn_Start;
        private TMP_Text Txt_LoadProgress;

        private void Awake()
        {
            Btn_Start = GameObj_Start.GetComponentInChildren<Button>();
        }

        private void Start()
        {
            Txt_LoadProgress = GameObj_ProgressPanel.transform.Find("TxtProgress").GetComponent<TMP_Text>();

            Slider_LoadProgress.value = 0;
            Txt_LoadProgress.text = "0%";

            GameObj_ProgressPanel.SetActive(true);
            GameObj_Start.SetActive(false);
            Img_LoadTxtBg.gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            Btn_Start.onClick.AddListener(OnClickStartGame);
            Btn_Exit.onClick.AddListener(OnClickExitGame);
        }

        public void UpdateLoadProgress(float loadingProgress)
        {
            Slider_LoadProgress.value = loadingProgress;
            Txt_LoadProgress.text = (int)(loadingProgress * 100) + "%";

            if (loadingProgress >= 1)
            {
                GameObj_ProgressPanel.SetActive(false);
                GameObj_Start.SetActive(true);
                Img_LoadTxtBg.gameObject.SetActive(false);
            }

        }

        private void OnClickStartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void OnClickExitGame()
        {
            ExitGame();
        }

        private void ExitGame()
        {
            Debug.Log("Info:Game Exit");
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void OnDisable()
        {
            Btn_Start.onClick.RemoveAllListeners();
        }
    }
}
