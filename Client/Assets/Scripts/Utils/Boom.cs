using UnityEngine;

namespace Tools
{
    public class Boom : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
