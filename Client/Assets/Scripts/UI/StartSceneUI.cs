using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.UI
{
    public class StartSceneUI : MonoBehaviour
    {
        public Slider Slider_LoadProgress;
        public TMP_Text Txt_LoadProgress;
        public GameObject GameObj_Start;

        public Button Btn_Start;

        private void Awake()
        {
            Btn_Start = GameObj_Start.GetComponentInChildren<Button>();
        }

        private void Start()
        {
            Slider_LoadProgress.value = 0;
            Txt_LoadProgress.text = "0%";

            GameObj_Start.SetActive(false);
        }

        private void OnEnable()
        {
            Btn_Start.onClick.AddListener(OnClickStartGame);
        }

        public void UpdateLoadProgress(float loadingProgress)
        {
            Slider_LoadProgress.value = loadingProgress;
            Txt_LoadProgress.text = (int)(loadingProgress * 100) + "%";
        }

        private void OnClickStartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void OnDisable()
        {
            Btn_Start.onClick.RemoveAllListeners();
        }
    }
}
