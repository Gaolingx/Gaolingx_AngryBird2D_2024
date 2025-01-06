using Core.UI;
using System.Collections;
using UnityEngine;

namespace Core.GameLogic
{
    public class StartScene : MonoBehaviour
    {
        [SerializeField]
        private int m_FrameRate = 60;

        [SerializeField]
        private StartSceneUI StartSceneWnd;

        private float progress = 0f;

        private void Awake()
        {
            Application.targetFrameRate = m_FrameRate;
        }

        private void Start()
        {
            StartCoroutine(LoadGameScene());
        }

        private IEnumerator LoadGameScene()
        {
            yield return new WaitForSeconds(0.5f);

            while (true)
            {
                yield return new WaitForSeconds(0.5f);

                progress += 0.2f;
                StartSceneWnd.UpdateLoadProgress(progress);
                if (progress >= 1f)
                {
                    StartSceneWnd.GameObj_Start.SetActive(true);
                    yield break;
                }
            }
        }

        /// <summary>
        /// 获取或设置游戏帧率。
        /// </summary>
        public int FrameRate
        {
            get => m_FrameRate;
            set => Application.targetFrameRate = m_FrameRate = value;
        }

    }
}
