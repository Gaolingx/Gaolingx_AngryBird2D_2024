using Core.UI;
using System.Collections;
using UnityEngine;

namespace Core.GameLogic
{
    public class StartScene : MonoBehaviour
    {
        public StartSceneUI StartSceneWnd;

        private float progress = 0f;

        // Start is called before the first frame update
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
    }
}
