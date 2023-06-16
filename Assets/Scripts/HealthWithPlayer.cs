using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthWithPlayer : MonoBehaviour
{
    public GameObject player;
    public Canvas HealthCanvas;
    //public GameObject empty;
    // Start is called before the first frame update
    void Start()
    {
        HealthCanvas.enabled = false;
       HealthCanvas.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthCanvas.transform.position = player.transform.position+ new Vector3(-0.1f,1f,0f);

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Spikes"))
    //    {
    //        gameObject.SetActive(true);
    //    }
}
    //}
