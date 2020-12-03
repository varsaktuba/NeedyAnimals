using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rg;
    private LineRenderer lr;
    private Camera cam;
    public Vector3 a, b,c;
    
    public float power = 5f;
   
    public Vector2 minPower;
    public Vector2 maxPower;

    public Sprite kalp;
    public Sprite angry;
    
    //KalanHamle
    public GameObject[] moves;
    private int hak;
    //public Text hakText;
    
    //LevelBarİçinGerekliŞeyler
    private Slider levelbar;
    private float slidermax, slidercurrent;
    public GameObject[] animals;
    
    //Çapıncaefektçıkması
    public GameObject[] puff;
    
    //GameMenager
    public GameManager gm;


    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        cam=Camera.main;
        hak = 5;
        levelbar = (Slider) FindObjectOfType(typeof (Slider));
        slidermax = 1.0f;
        slidercurrent = slidermax / animals.Length;


    }

  
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
           // Vector2 startPosition = cam.ScreenToWorldPoint (Input.mousePosition);
           a= cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, transform.position.z - cam.transform.position.z));
           lr.positionCount = 2;
        }
        if (Input.GetMouseButton(0)&& !EventSystem.current.IsPointerOverGameObject())
        {   lr.SetPosition(0,gameObject.transform.position);
            //Vector2 cursorPosition = cam.ScreenToWorldPoint (Input.mousePosition);
            b= cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, transform.position.z - cam.transform.position.z));
            
            /*float dist = Vector3.Distance(gameObject.transform.position, b);
            if(dist < 3)
            {  lr.SetPosition(1,b);}*/
            
            float dist = Vector3.Distance(gameObject.transform.position, b);
           
            Vector3 dir = b - gameObject.transform.position;
            float distt = Mathf.Clamp(Vector3.Distance(gameObject.transform.position, b), 0, 3);
            b = gameObject.transform.position + (dir.normalized * distt);
            lr.SetPosition(1,b);
        }
        
        if (Input.GetMouseButtonUp(0)&& !EventSystem.current.IsPointerOverGameObject())
        {
            lr.positionCount = 0;
            //Vector2 endPosition = cam.ScreenToWorldPoint (Input.mousePosition);
            c= cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, transform.position.z - cam.transform.position.z));
            
            Vector2 force = new Vector2(-Mathf.Clamp(transform.position.x - c.x, minPower.x, maxPower.x), -Mathf.Clamp(transform.position.y - c.y, minPower.y, maxPower.y));
            rg.AddForce(force * power, ForceMode2D.Impulse);

            if (hak > -1)
            {
                if (hak > 0)
                {
                    moves[hak - 1].SetActive(false);
                }

                hak = hak - 1;
                //hakText.text = "Kalan Hamle : " + hak + " / 5";
            }

            if (hak < 0)
            {
                gm.EndGame(); //Calling Game Over Scene 
                
            }

        }
    }
    
    private SpriteRenderer image;
    public void OnCollisionEnter2D(Collision2D other)
     {

           if (other.gameObject.tag == "p" || other.gameObject.tag == "c" )
         {

             if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name ==
                 this.gameObject.GetComponent<SpriteRenderer>().sprite.name)
             {
                 
                 image = other.gameObject.GetComponent<SpriteRenderer>();
                 image.sprite = kalp;


                 GameObject aa = other.transform.parent.gameObject;
                 //Çarpılan yok etme
                 Destroy(other.transform.parent.gameObject,1f);
                 

                
                /* if (!beingHandled)
                 {
                     StartCoroutine(HandleIt(other.transform.parent.gameObject.transform.position));
                 }*/
                
                if (!beingHandled)
                {
                    StartCoroutine(HandleIt(aa));
                }
             


                 //SliderLevelBar
                 levelbar.value += slidercurrent;
                 if (levelbar.value == slidermax)
                 {
                     if (!beingHandled2)
                     {
                         StartCoroutine(HandleIt2());
                     }
                 
                 
                 }
             }

             else
             {
                 
                 image = other.gameObject.GetComponent<SpriteRenderer>();
                 Sprite a = other.gameObject.GetComponent<SpriteRenderer>().sprite;
                 image.sprite = angry;
                 if (!beingHandled2)
                 {
                     StartCoroutine(HandleIt3(a));
                 }
                 
             }
            
           
         }


     }
    
    //Enumatorbekleme
    /*private bool beingHandled = false;
    private IEnumerator HandleIt(Vector3 a = new Vector3())
    {
        beingHandled = true;
        // process pre-yield
        yield return new WaitForSeconds(1.1f); 
        
        //Arkada puff particle çıkartma
        GameObject firework = Instantiate(puff[Random.Range(0, puff.Length)],a,Quaternion.identity);
        firework.GetComponent<ParticleSystem>().Play();
        // process post-yield
        beingHandled = false;
    }*/
    
    private bool beingHandled = false;
    private IEnumerator HandleIt(GameObject a)
    {
        beingHandled = true;
        // process pre-
        yield return new WaitForSeconds(0.9f); 
        Vector3 last = a.transform.position;
        yield return new WaitForSeconds(0.2f); 
        
        //Arkada puff particle çıkartma
        GameObject firework = Instantiate(puff[Random.Range(0, puff.Length)],last,Quaternion.identity);
        firework.GetComponent<ParticleSystem>().Play();
        // process post-yield
        beingHandled = false;
    }
    
    private bool beingHandled2 = false;
    private IEnumerator HandleIt2()
    {
        beingHandled2 = true;
        // process pre-yield
        yield return new WaitForSeconds(2.5f); 
        
        gm.WinGame();
    
        // process post-yield
        beingHandled2 = false;
    }
     
    
    private bool beingHandled3 = false;
    private IEnumerator HandleIt3(Sprite a)
    {
        beingHandled3 = true;
        // process pre-yield
        yield return new WaitForSeconds(1f);

        image.sprite = a;
        // process post-yield
        beingHandled3 = false;
    }
    
  
    /*public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("water"))
        {
            image = other.gameObject.GetComponent<SpriteRenderer>();
            image.sprite = kalp;
        }

        else
        {
            image = other.gameObject.GetComponent<SpriteRenderer>();
            image.sprite = angry;
        }
    }
    */
}
