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
        public int score1Required;
        public int score2Required;
        public string score1Name;
        public string score2Name;
        public string sceneName;
        
        #if UNITY_EDITOR
        public SceneAsset sceneAsset;
        private void OnValidate() {
            if(sceneAsset != null)
                sceneName = sceneAsset.name;
        }
        #endif

    }
}