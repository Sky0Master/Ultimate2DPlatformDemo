using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Vivian
{
    [CreateAssetMenu(fileName = "Level Data", menuName = "Vivian/LevelData", order = 1)]
    public class LevelData : ScriptableObject
    {
        public int level;
        public string levelName;
        
        [HideInInspector]
        public string sceneName;
        public SceneAsset sceneAsset;
        public int score1Required;
        public int score2Required;
        public string score1Name;
        public string score2Name;
        

        #if UNITY_EDITOR
        private void OnValidate() {
            if(sceneAsset != null)
                sceneName = sceneAsset.name;
        }
        #endif

    }
}