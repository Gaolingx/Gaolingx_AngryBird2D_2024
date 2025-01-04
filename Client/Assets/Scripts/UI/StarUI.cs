using UnityEngine;

namespace Core.UI
{
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
}
