using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LowerGround : MonoBehaviour
{
    public int WallValue;
    public TextMeshProUGUI counter;
    public int CurrentValue;
    private void Awake()
    {
        CurrentValue = 0;
        UpdateWallScore();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CollectibleObject>())
        {
            if (!collision.gameObject.GetComponent<CollectibleObject>().isCounted)
            {
                collision.gameObject.GetComponent<CollectibleObject>().isCollected = true;
                collision.gameObject.GetComponent<CollectibleObject>().isCounted = true;
                CurrentValue++;
                UpdateWallScore();
            }
               
        }

    }
    public void UpdateWallScore()
    {
        counter.text = CurrentValue.ToString() + " / " + WallValue.ToString();
    }
   
}
