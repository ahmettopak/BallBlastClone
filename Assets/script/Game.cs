using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{
   public static Game Instance;
   [HideInInspector]public float screenWidth;
   private void Awake()
   {
       Instance=this;
       screenWidth=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0f,0f)).x;
   }

    public void click_restart()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void click_exit()
    {
       Application.Quit();
    }
}
