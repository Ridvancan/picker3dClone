using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStoper>())
        {
            CharacterController.Instance.leftPowerUpWing.SetActive(false);
            CharacterController.Instance.rightPowerUpWing.SetActive(false);
            GameManager.Instance.gameStatus = Enums.GameStatus.stationWait;
            foreach (var item in GameManager.Instance.collectedObjectList)
            {
                item.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 4));
            }
              other.GetComponent<BoxCollider>().enabled = false;
              StartCoroutine(other.GetComponent<CharacterStoper>().WaitForStation(other.GetComponent<CharacterStoper>().LowerGround));
            
        }
        if (other.GetComponent<PowerUp>())
        {
            other.gameObject.SetActive(false);
            CharacterController.Instance.leftPowerUpWing.SetActive(true);
            CharacterController.Instance.rightPowerUpWing.SetActive(true);
            
        }
        if (other.GetComponent<SpawnerStarter>())
        {
            if (!GameManager.Instance.isSpawnerBegin)
            {
                other.gameObject.transform.parent.gameObject.GetComponent<ObjectSpawner>().BeginSpawner();
            }
            
            
        }
        if (other.GetComponent<FinishLine>())
        {
            GameManager.Instance.gameStatus = Enums.GameStatus.levelSuccess;
            UIManager.Instance.LevelCompletedUIAnimation();
        }
        
    }
   
}
