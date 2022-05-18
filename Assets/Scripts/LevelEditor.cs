using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LevelEditor : Singleton<LevelEditor>
{
    public GameObject CurrentLevel;

    [Serializable]
    public class Levels
    {
        public string LevelName;
        public int LevelIndex;
        public GameObject LevelPrefab;
        
    }
    public List<Levels> levels = new List<Levels>();
    

    public void GenerateLevel(int index)
    {
        if (CurrentLevel)
        {
            Destroy(CurrentLevel);
        }
        if (PlayerPrefs.GetInt("PlayerLevel")>levels.Count)
        {
            CurrentLevel = Instantiate(levels[PlayerPrefs.GetInt("PlayerLevel")%levels.Count].LevelPrefab);
        }
        else
        {
            for (int i = 0; i < levels.Count; i++)
            {
                if (index == levels[i].LevelIndex)
                {
                    CurrentLevel = Instantiate(levels[i].LevelPrefab);
                }
            }
        }
        

    }


}
