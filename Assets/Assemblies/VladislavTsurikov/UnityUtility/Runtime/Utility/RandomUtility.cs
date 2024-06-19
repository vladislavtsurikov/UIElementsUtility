using UnityEngine;

namespace VladislavTsurikov.UnityUtility.Runtime.Utility
{
    public static class RandomUtility
    {
        public static void ChangeRandomSeed() 
        {
            int randomSeed = Random.Range(0, int.MaxValue);
            
            Random.InitState(randomSeed);
        }
    }
}