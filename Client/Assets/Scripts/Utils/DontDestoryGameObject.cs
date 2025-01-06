using UnityEngine;

/// <summary>
/// Please modify the description.
/// </summary>
public class DontDestoryGameObject : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationQuit()
    {
        StopAllCoroutines();
    }
}