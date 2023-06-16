using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obj;
    public float time1;
    public float time2;
    GameObject Temp;
    public GameObject prefab;
    public GameObject prefab_variant;
    public List<GameObject> obstacles_List;
    public List<GameObject> obstacles_List_variant;

    // Start is called before the first frame update
    void Start()
    {
        time1 = time2 = 0;
        Invoke("Init", 100f);
        obstacles_List = new List<GameObject>();
        obstacles_List_variant = new List<GameObject>();
        //Init();
       // obj.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
      
        StartCoroutine(Spawn_Obstacle());
       // TimerMethod();

    }
    float RandomX()
    {
        return Random.Range(-4f, 4f);
    }
    float RandomY()
    {
        return Random.Range(2.3f, -2.3f);
    }
    float RandomX_variant()
    {
        return Random.Range(-4f, 4f);
    }
    float RandomY_variant()
    {
        return Random.Range(2.3f, -2.3f);
    }
    private void Init()
    {
        for (int i = 0; i < 1; i++)
        {
            var g = Instantiate(prefab, new Vector3(RandomX(), RandomY(), 0f), Quaternion.identity);
            Temp = g;
            obstacles_List.Add(g);
            
        }
        for (int j = 0; j < 1; j++)
        {
            var r = Instantiate(prefab_variant, new Vector3(RandomX_variant(), RandomY_variant(), 0f), Quaternion.identity);
            Temp = r;
            obstacles_List_variant.Add(r);
        }

    }
    IEnumerator Spawn_Obstacle()
    {
        yield return new WaitForSeconds(100f);
        //obj.gameObject.SetActive(true); 
        
        TimerMethod();
    }

    void TimerMethod()
    {

        time1 += Time.deltaTime;
        if (time1 >= 2f)
        {
           
            obstacles_List[0].transform.position = new Vector3(RandomX(), RandomY(), 0f);
            time1 = 0;
        }
        time2 += Time.deltaTime;
        if (time2 >= 4f)
        {

            obstacles_List_variant[0].transform.position = new Vector3(RandomX_variant(), RandomY_variant(), 0f);
            time2 = 0;
        }

    }   
}
