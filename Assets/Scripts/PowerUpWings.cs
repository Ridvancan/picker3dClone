using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpWings : MonoBehaviour
{
   public bool isRight;
    void Update()
    {
        if (isRight)
        RightWingRotate();
        else
        {
            LeftWingRotate();
        }
    }
    public void RightWingRotate()
    {
        gameObject.transform.Rotate(0, -300 * Time.deltaTime, 0);
    }
    public void LeftWingRotate()
    {
        gameObject.transform.Rotate(0, 300 * Time.deltaTime, 0);
    }
}
