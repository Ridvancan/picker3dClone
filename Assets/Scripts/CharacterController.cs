
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CharacterController : Singleton<CharacterController>
{
    private Vector3 prevmousePos;
    private Vector3 currentmousePos;
    private Vector3 deltamousePos;
    public float MovementSpeed;
    public float smoothTime;
    public float xMinLimit;
    public float xMaxLimit;
    private Vector3 target;
    private Vector3 velocity = Vector3.zero;
    public GameObject mainObject;
    public GameObject rightPowerUpWing;
    public GameObject leftPowerUpWing;
    void Update()
    {
        if (GameManager.Instance.gameStatus == Enums.GameStatus.mainMenu)
        {

        }
            if (GameManager.Instance.gameStatus == Enums.GameStatus.inGame)
        {
            ForwardMovement();
            if (Input.GetMouseButtonDown(0))
            {
                currentmousePos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                LeftRightPosition();
            }
            if (Input.GetMouseButtonUp(0))
            {
                mainObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                transform.position = Vector3.SmoothDamp(transform.position, transform.position, ref velocity, 0);
            }
        }
        else if (GameManager.Instance.gameStatus == Enums.GameStatus.finish)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * MovementSpeed);
        }
        else if (GameManager.Instance.gameStatus == Enums.GameStatus.levelSuccess)
        {
           
        }
    }
    public void ForwardMovement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * MovementSpeed);
    }
    public void LeftRightPosition()
    {
        prevmousePos = currentmousePos;
        currentmousePos = Input.mousePosition;
        deltamousePos = currentmousePos - prevmousePos;
        target = new Vector3(deltamousePos.x, 0);
        float changePosition = transform.position.x;
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x + target.x / 2,
            transform.position.y, transform.position.z), ref velocity, smoothTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMinLimit, xMaxLimit), transform.position.y, transform.position.z);
    }
   
}

