using UnityEngine;

namespace Core.Data
{
    [CreateAssetMenu(fileName = "MapData", menuName = "ScriptableObjects/MapData", order = 1)]
    public class MapSO : ScriptableObject
    {
        public int starNumberOfMap = -1;// -1 0 1 2 3 ....
        public int[] starNumberOfLevel = { -1 };
    }
}
