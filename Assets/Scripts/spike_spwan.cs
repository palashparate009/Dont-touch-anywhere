using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spike_spwan : MonoBehaviour
{
    [SerializeField] List<GameObject> _spikesList;
    [SerializeField] int _activeSpikeCount;
    [SerializeField] float _waitTime;
    private List<GameObject> _templist;
   
    // Start is called before the first frame update
    void Start()
    {
        _templist = new List<GameObject>();


        for (int i = 0; i < _spikesList.Count; i++)
        {
            _spikesList[i].SetActive(false);
        }
        spawnSpike();
        
    }

    // Update is called once per frame
    void Update()
    {
       //Debug.Log(_spikesList.Count);
      
    }
    int giverandomInt()
    {
        int tempint = Random.Range(0, _spikesList.Count);
       
        return tempint;
       
        //return Random.Range(0, _spikesList.Count);


    }
    void spawnSpike()
    {
        GameObject temp;
        _templist.Clear();
        for (int i = 0; i < _activeSpikeCount; i++)
        {
            temp = _spikesList[giverandomInt()];
            //Debug.Log(temp);
            temp.SetActive(true);
         // _spkiesList[giverandomInt()].SetActive(true);
            _templist.Add(temp);
        
        }
       StartCoroutine("newSpike");
    }
    IEnumerator newSpike()
    {
        yield return new WaitForSeconds(_waitTime);
        //  foreach (var item in _templist)
        // {
        //     item.SetActive(false);
        //}
        int tempcount=_templist.Count;
        for (int i = 0; i < tempcount; i++)
        {
            _templist[i].SetActive(false);
        }
        spawnSpike();
    }

}

