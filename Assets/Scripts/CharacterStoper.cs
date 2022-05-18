using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStoper : MonoBehaviour
{
    public GameObject LowerGround;
    private void OnTriggerEnter(Collider other)
    {
       
    }
    public IEnumerator WaitForStation(GameObject lowerGroundObject)
    {
        yield return new WaitForSeconds(4);
        if (lowerGroundObject.GetComponent<LowerGround>().CurrentValue >= lowerGroundObject.GetComponent<LowerGround>().WallValue)
        {
            LeanTween.moveY(LowerGround, GameManager.Instance.Way.position.y, 1f).setOnComplete(() =>
            {
                GameManager.Instance.gameStatus = Enums.GameStatus.inGame; 
                foreach (var item in GameManager.Instance.collectedObjectList)
                {
                    Destroy(item);
                }  
                GameManager.Instance.collectedObjectList.Clear();  });
        }
        else
        {
           
            UIManager.Instance.LevelFailedUIAnimation();
        }
    }

}
