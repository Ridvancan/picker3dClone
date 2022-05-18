
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject hand;
    public GameObject handObjectUI;
    public GameObject levelSuccessUI;
    public GameObject levelFailedUI;
    public GameObject collectedCoinParent;
    public GameObject coin;
    public TextMeshProUGUI coinScoreTMP;
    public TextMeshProUGUI levelTMP;
    public List<Vector3> collectedCoinStartPlace;

    void Start()
    {
        HandAnimation();
    }
    public void BringSavedLevel()
    {
        levelTMP.text = "LEVEL " + PlayerPrefs.GetInt("FakeLevel").ToString();
    }
    public void BringSavedCoin()
    {
        coinScoreTMP.text = PlayerPrefs.GetInt("PlayerScore").ToString();
    }
    void Update()
    {

    }
    public void HandAnimationReset()
    {
        hand.transform.localPosition = new Vector2(-380, 0);
    }
    public void HandAnimation()
    {
        HandAnimationReset();
        LeanTween.moveLocalX(hand, hand.transform.localPosition.x + 700, 1f).setLoopPingPong();
    }
    public void LevelCompletedUIAnimation()
    {
        LevelSuccessReset();
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "level - " + PlayerPrefs.GetInt("FakeLevel").ToString());
        levelSuccessUI.SetActive(true);
        LeanTween.moveLocalX(levelSuccessUI, 0, 0.6f);
    }
    public void LevelFailedReset()
    {
        levelFailedUI.transform.localPosition = new Vector3(1000, levelFailedUI.transform.localPosition.y, levelFailedUI.transform.localPosition.z);
    }
    public void LevelSuccessReset()
    {
        levelSuccessUI.transform.localPosition = new Vector3(1000, levelFailedUI.transform.localPosition.y, levelFailedUI.transform.localPosition.z);
    }
    public void LevelFailedUIAnimation()
    {
       
            GameManager.Instance.gameStatus = Enums.GameStatus.gameOver;
            LevelFailedReset();
            //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "level - " + PlayerPrefs.GetInt("FakeLevel").ToString());
            levelFailedUI.SetActive(true);
            LeanTween.moveLocalX(levelFailedUI, 0, 0.6f);
       
       
    }
    public void RaiseCoinAmount()
    {
        LeanTween.value(Convert.ToInt32(coinScoreTMP.text), UnityEngine.Random.Range(Convert.ToInt32(coinScoreTMP.text), Convert.ToInt32(coinScoreTMP.text) + 10), 0.3f).setOnUpdate((float val) =>
         {
             coinScoreTMP.text = (Convert.ToInt32(val)).ToString();
             UIManager.Instance.coin.transform.localScale = new Vector3(2, 2, 2);
             LeanTween.scale(UIManager.Instance.coin, Vector3.one, 0.4f).setEase(LeanTweenType.easeOutBack);
         });
    }
    //public IEnumerator FinalMultiplierCoin()
    //{
    //    yield return new WaitForSeconds(1);
    //    int newScore = Convert.ToInt32(Convert.ToInt32(coinScoreTMP.text) * GameManager.Instance.lastXPerson);
    //    LeanTween.value(Convert.ToInt32(coinScoreTMP.text), newScore, 0.3f).setOnUpdate((float val) =>
    //    {
    //        coinScoreTMP.text = (Convert.ToInt32(val)).ToString();
    //    });

    //}
}
