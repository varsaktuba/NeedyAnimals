using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Rigidbody2D rbody;
  public Vector3 startpos;
  public Vector3 endpos;
  public Vector3 currentpos;
  public LineRenderer lr;
  public float power = 5f; // power of shot
  public Vector2 minpow;
  public Vector2 maxpow;
  void Start()
  {
      
      lr = GetComponent<LineRenderer>();
      rbody = GetComponent<Rigidbody2D>();
      lr.positionCount = 2;
  }
  
  void Update()
  {
      
      
      if (Input.GetMouseButtonDown(0))
      {
          startpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          
          startpos.z = 15;
         
      }
      
      if (Input.GetMouseButton(0))
      {
          currentpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          
          currentpos.z = 15;

         
          RenderLine(startpos,currentpos);
          
      }
      
      
      if (Input.GetMouseButtonUp(0))
      {
          endpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          
          endpos.z = -1;
         
          EndLine();
          LaunchBall();
      }
  }

  public void RenderLine(Vector3 startpoint, Vector3 endpoint)
  {

      lr.positionCount = 2;
      Vector3[] line = new Vector3[2];
      line[0] = startpoint;
      line[1] = endpoint;
      lr.SetPositions(line);

  }
  public void EndLine()
  {
      lr.positionCount = 0;

  }
  
  void LaunchBall()
  {
      //Vector2 direction = (startpos - endpos).normalized; // swap subtraction to switch direction of launch
      Vector2 force = new Vector2(Mathf.Clamp(startpos.x-endpos.x,minpow.x,maxpow.x),Mathf.Clamp(startpos.y-endpos.y,minpow.y,maxpow.y));
      rbody.AddForce(force * power, ForceMode2D.Impulse);
      
      
  }
}
