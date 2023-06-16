using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BallMovement : MonoBehaviour
{
    public Transform target;
    public Transform throwPoint;
    public float timeTillHit = 1f;
    //private Rigidbody2D _rigidBody;
    private float _startPoint, _endPoint;
    public Rigidbody2D rb;
    public float movespeed;
    bool collided;
    public bool isactive;
    public float force;
    public float moveforce;
    public float leftforces;
    public ScoreManager sm;
    public bool istouching;
    public HealthSystem hm;
    public HealthWithPlayer hp;
    public float Health_timer;
    Vector3 lastVelocity;
    public float timer=0f;
    [SerializeField] ParticleSystem ps;
    [SerializeField] ParticleSystem ps_red;
    [SerializeField] GameObject _taptoplay;
    [SerializeField] GameObject pausemenupanelref;
    TrailRenderer _trail;
    public UImanager um; 
    public AudioSource ball;
    public AudioSource spike;
    public AudioSource Bounce;
  
 


    void Start()
    {
        _taptoplay.SetActive(true);
       // rb.gameObject.GetComponent<Rigidbody2D>();
        //rb.AddForce(Vector2.left * force);
        _trail= GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        //rb.AddForce(Vector2.up * force);
        //hp.HealthCanvas.enabled = false;
        //ps.emission = false;
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;

        


        if (!gameObject)
        {
            gameObject.SetActive(true);
        }
        if (hp.HealthCanvas == true)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                hp.HealthCanvas.enabled = false;
                timer = 0;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            _taptoplay.SetActive(false);
            Bounce.Play();
            var temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _startPoint = temp.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            var temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _endPoint = temp.y;
            Throw();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pausemenupanelref.SetActive(true);
        }
    }














        //----------------------------------------------------------------------------------------------
        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //    if(istouching)
        //    {
        //        rb.AddForce(Vector2.up * moveforce);

        //        rb.AddForce(Vector2.right * force);
        //        rb.AddForce(Vector2.left * leftforces);
        //        //Debug.Log("right dir");
        //    }
        //    else
        //    {
        //        rb.AddForce(Vector2.up * moveforce);

        //        rb.AddForce(Vector2.left * force );
        //        //Debug.Log("left dir");

        //    }

        //}

        //if (Input.GetKey(KeyCode.A))
        //{

        //    rb.AddForce(new Vector2(-10f, 10f));
        //}
        //if (Input.GetKey(KeyCode.D))
        //{

        //    rb.AddForce(new Vector2(10f, 10f));
        //}
        //---------------------------------------------------------------------------------------------

    

    private void Throw()
    {
        rb.gravityScale = 1;
        var xDistance = _endPoint - _startPoint;
        var yDistance = target.position.y - throwPoint.position.y;
        var angle = Mathf.Atan((yDistance + 4.905f * (timeTillHit * timeTillHit)) / xDistance);
        var totalvel = xDistance / (Mathf.Cos(angle) * timeTillHit);
        var xVel = totalvel * Mathf.Cos(angle);
        var yVel = totalvel * Mathf.Sin(angle);
        rb.velocity = new Vector2(xVel, yVel);

    }



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    void leftforce()
    {
        rb.AddForce(Vector2.left * force);
        rb.AddForce(Vector2.up * force);
    }
    void rightforce()
    {
        rb.AddForce(Vector2.right * force);
        rb.AddForce(Vector2.up * force);
    }
    void upforce()
    {
        rb.AddForce(Vector2.up * force);

    }
    void downforce()
    {
        rb.AddForce(Vector2.down * force);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        Vector2 point = collision.contacts[0].point;
        
        
        ps.gameObject.transform.position = point;
        switch (collision.gameObject.tag)
        {
            case "leftwall":
                rightforce();
                istouching = true;
                um.score += 10;
                ps.Play();
                ball.Play();
                break;
            case "rightwall":
                istouching = false;
                leftforce();
                um.score += 10;
                ps.Play();
                ball.Play();
                break;
            case "bottomwall":
                if (istouching)
                {
                    rightforce();
                }
                else
                {
                    leftforce();
                }
                um.score -= 5;
                ps.Play();
                ball.Play();
                break;
            case "abovewall":
                downforce();
                ps.Play();
                ball.Play();
                break;
            case "Spikes":
                _trail.emitting = false;
                gameObject.SetActive(false);
                hm.health = hm.health - 1;
                hp.HealthCanvas.enabled = true;
                ps_red.gameObject.transform.position = point;
                ps_red.Play();
                spike.Play();
                Invoke("playerrespawn",0.5f);
                break;
            default:
                break;
        }
        if (collision.gameObject.CompareTag("Obstacle_wall_left"))
        {
            um.score += 5;
            rightforce();
            ball.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle_wall_right"))
        {
            um.score += 5;
            leftforce();
            ball.Play();
        } 
        if (collision.gameObject.CompareTag("Obstacle_spike"))
        {
            um.score -= 2;
            spike.Play();
        }
    }
    void playerrespawn()
    {
        if(!HealthSystem.instance.IsDead())
        {
            transform.position = new Vector3(-0.321f, 0.424f, 0f);
            gameObject.SetActive(true);
            _trail.emitting = true;
        }
    
    }
   



}
