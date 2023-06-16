using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpikesSpawner : MonoBehaviour
{
    public GameObject spike_obj;
    public float timer;
    public List<GameObject> spikes_list = new List<GameObject>();
    bool isActive = false;
    
    
    // Start is called before the first frame update
    void Start()
    {



        Invoke("coroutinestart", 50f);
            //StartCoroutine(BTSpiketrue());
           
            
      

    }

    // Update is called once per frame
    void Update()
    {

    }
    void coroutinestart()
    {
        StartCoroutine(BTSpiketrue());
        

    }

    void spikespwn()
    {
            isActive = !isActive;

            for (int j = 0; j < spikes_list.Count; j++)
            {
                spikes_list[j].SetActive(isActive);
            }

    }
    IEnumerator BTSpiketrue()
    {         

        while (true)
        {
            
            yield return new WaitForSeconds(2f);
            spikespwn();

        }

        

        
        
    }

}




















