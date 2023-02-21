using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] meteorPrefabs;
    [SerializeField] int meteorsCount;
    [SerializeField] float spawnDelay;

    GameObject[] meteors;
    public static MeteorSpawner Instance;
    [SerializeField]  GameObject Lose;
    [SerializeField]  TMP_Text txt;
    int score=0;

    void Awake()
    {
        Instance=this;
    }
    void Start()
    {
        PrepareMeteors();
        StartCoroutine(spawnmeteors());
        
    }

    void Update()
    {
        txt.text=score.ToString();
    }
    IEnumerator spawnmeteors()
    {
        for(int i=0;i<meteorsCount;i++)
        {
            meteors[i].SetActive(true);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void PrepareMeteors()
    {
        meteors=new GameObject[meteorsCount];
        int prefabsCount=meteorPrefabs.Length;
        for(int i=0;i<meteorsCount;i++)
        {
            meteors[i]=Instantiate(meteorPrefabs[Random.Range(0,prefabsCount)] , transform);
            meteors[i].GetComponent<Meteor>().isResultofFission=false;
            meteors[i].SetActive(false);
        }
    }
    public void lose()
    {
       Lose.SetActive(true);
       Destroy(gameObject);
    }
    public void scorex()
    {
        if(!Lose.activeInHierarchy)
           score ++;
    }
}
