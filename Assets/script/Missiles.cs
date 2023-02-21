using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missiles : MonoBehaviour
{
    Queue<GameObject> missilesQueue;
    [SerializeField] GameObject missilePrefab;
    [SerializeField] int missileCount;

    [Space]
    [SerializeField] float delay=0.3f;
    [SerializeField] float speed=0.3f;

    GameObject g;
    float t=0f;

    public static Missiles Instance;

    void Awake()
    {
       Instance=this;  
    }
    void Start()
    {
        PrepareMissiles();
    }

   
    void Update()
    {
        t +=Time.deltaTime;
        if(t>=delay)
        {
            t=0f;
            g=SpawnMissile(transform.position);
            g.GetComponent<Rigidbody2D>().velocity=Vector2.up * speed;
        }
    }
    void PrepareMissiles()
    {
        missilesQueue=new Queue<GameObject>();
        for(int i=0 ; i<missileCount;i++)
        {
            g=Instantiate(missilePrefab,transform.position,Quaternion.identity,transform);
            g.SetActive(false);
            missilesQueue.Enqueue(g);
        }
    }

    public GameObject SpawnMissile(Vector2 position)
    {
        if(missileCount>0)
        {
            if(missilesQueue!=null)
            {
                g=missilesQueue.Dequeue();
                g.transform.position=position;
                g.SetActive(true);
                return g;
            }
           
        }

        return null;
    }

    public void DestroyMissile(GameObject missile)
    {
        missilesQueue.Enqueue(missile);
        missile.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("missile"))
        {
            DestroyMissile(other.gameObject);
        }
    }
}
