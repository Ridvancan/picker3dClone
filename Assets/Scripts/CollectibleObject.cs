using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    public bool isCollected;
    public bool isCounted;
    private void Awake()
    {
        isCollected = false;
        isCounted = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CollectibleObjectKeeper>())
        {
            if (!isCollected)
            {
                isCollected = true;
                GameManager.Instance.collectedObjectList.Add(gameObject);
            }
           
        }
    }
    public void ForceTheBall()
    {

    }
}
