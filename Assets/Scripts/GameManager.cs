using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Enums.GameStatus gameStatus;
    public List<GameObject> collectedObjectList = new List<GameObject>();
    public Transform Way;
    public GameObject ObjectSpawner;
    public bool isSpawnerBegin;
    public GameObject SpawnObjects;

    void Start()
    {
        Application.targetFrameRate = 60;
        if (PlayerPrefs.GetInt("PlayerLevel")==0)
        {
            PlayerPrefs.SetInt("PlayerLevel",1);
        }
        LevelEditor.Instance.GenerateLevel(PlayerPrefs.GetInt("PlayerLevel"));
        
    }

    void Update()
    {

    }

    public void ResetCharacter()
    {
        CharacterController.Instance.mainObject.transform.position = Vector3.zero;
        CharacterController.Instance.leftPowerUpWing.SetActive(false);
        CharacterController.Instance.rightPowerUpWing.SetActive(false);
        UIManager.Instance.levelFailedUI.SetActive(false);
        collectedObjectList.Clear();
        gameStatus = Enums.GameStatus.mainMenu;
        LevelEditor.Instance.GenerateLevel(PlayerPrefs.GetInt("PlayerLevel"));
    }
    public void PlayButton()
    {
        if (gameStatus == Enums.GameStatus.mainMenu)
        {
            gameStatus = Enums.GameStatus.inGame;
            UIManager.Instance.handObjectUI.SetActive(false);
        }
    }
    public void SaveAndLoadNextLevel()
    {
        ResetCharacter();
        SaveCurrentLevelAndScore();
        LevelEditor.Instance.GenerateLevel(PlayerPrefs.GetInt("PlayerLevel"));
        gameStatus = Enums.GameStatus.mainMenu;
        UIManager.Instance.levelSuccessUI.SetActive(false);
        UIManager.Instance.BringSavedLevel();
    }
    public void SaveCurrentLevelAndScore()
    {
        PlayerPrefs.SetInt("PlayerLevel", PlayerPrefs.GetInt("PlayerLevel") + 1);
    }
}
