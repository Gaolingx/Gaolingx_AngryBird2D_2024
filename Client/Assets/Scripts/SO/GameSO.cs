using UnityEngine;

namespace Core.Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
    public class GameSO : ScriptableObject
    {
        public MapSO[] mapArray;
        public int selectedMapID = -1;
        public int selectedLevelID = -1;

        public void UpdateLevel(int number)
        {
            if (number <= 0) return;

            if (number > mapArray[selectedMapID - 1].starNumberOfLevel[selectedLevelID - 1])
            {
                mapArray[selectedMapID - 1].starNumberOfLevel[selectedLevelID - 1] = number;

                int sum = 0;
                foreach (int num in mapArray[selectedMapID - 1].starNumberOfLevel)
                {
                    if (num > 0)
                    {
                        sum += num;
                    }
                }
                mapArray[selectedMapID - 1].starNumberOfMap = sum;

                //�ж��Ƿ������һ��
                if (selectedLevelID >= mapArray[selectedMapID - 1].starNumberOfLevel.Length)
                {
                    //�ж���һ����ͼ�Ƿ��Ѿ����������δ�������Ϳ���
                    if (selectedMapID < mapArray.Length && mapArray[selectedMapID].starNumberOfMap == -1)
                    {
                        mapArray[selectedMapID].starNumberOfMap = 0;
                        mapArray[selectedMapID].starNumberOfLevel[0] = 0;
                    }
                }
                else
                {
                    //�ж���һ���Ƿ���
                    if (mapArray[selectedMapID - 1].starNumberOfLevel[selectedLevelID] == -1)
                    {
                        mapArray[selectedMapID - 1].starNumberOfLevel[selectedLevelID] = 0;
                    }
                }

            }
        }
    }
}
