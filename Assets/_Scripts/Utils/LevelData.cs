using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VinoUtility
{
    [CreateAssetMenu(fileName = "Level Data", menuName = "SO/LevelData", order = 1)]
    public class LevelData : ScriptableObject
    {
        public int level;
        public string levelName;
        
        [HideInInspector]
        public string sceneName;
        public int scoreToWin;

        #if UNITY_EDITOR
        public SceneAsset sceneAsset;
        private void OnValidate() {
            if(sceneAsset != null)
                sceneName = sceneAsset.name;
        }
        #endif
    }
}