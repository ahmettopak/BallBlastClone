using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform traget;
    float screenWidth;

     void Start()
    {
       screenWidth=Game.Instance.screenWidth;
    }
    void Update()
    {
        
        if(traget!=null)
        {
           if(traget.transform.position.x<screenWidth/2f && traget.transform.position.x>-screenWidth/2f)
           {
               transform.position=new Vector3(traget.transform.position.x,transform.position.y,transform.position.z); 
           }
             
        }
        
    }
}
