using UnityEngine;

public class StarUI : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Show()
    {
        anim.SetTrigger("IsShow");
    }
}
