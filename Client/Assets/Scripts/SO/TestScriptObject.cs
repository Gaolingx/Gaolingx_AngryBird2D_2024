using UnityEngine;

namespace Core.Data
{
    [CreateAssetMenu(fileName = "TestScriptObject", menuName = "ScriptableObjects/TestScriptObject", order = 1)]
    public class TestScriptObject : ScriptableObject
    {
        public new string name;
        public int level;

        public int[] levelData;
        public int[] levelData2 = { 10 };

        public int[,] mapData;
    }
}
