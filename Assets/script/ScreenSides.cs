using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSides : MonoBehaviour
{
    [SerializeField] BoxCollider2D leftwallCollider;
    [SerializeField] BoxCollider2D rightwallCollider;

    void Awake()
    {
        float screenWidth=Game.Instance.screenWidth;

        leftwallCollider.transform.position=new Vector3(-screenWidth/2-screenWidth-leftwallCollider.size.x/2f ,0f,0f);
        rightwallCollider.transform.position=new Vector3(screenWidth/2+screenWidth+rightwallCollider.size.x/2f ,0f,0f);


        Destroy(this);
    }
}
