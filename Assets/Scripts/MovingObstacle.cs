using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Transform startLocation;
    public Transform endLocation;
    
    public float speed = 1.0F;
    private float startTime;
    public Transform obstacle;

    private float magnitude;
    void Start()
    {
        startTime = Time.time;

        magnitude = Vector3.Distance(startLocation.position,endLocation.position);
    }

    void Update()
    {
        lerpObject();
    }
   
   void lerpObject()
   {
        float distance = (Time.time - startTime) * speed;

        float path = Mathf.PingPong(distance / magnitude, 1);

        obstacle.position = Vector3.Lerp(startLocation.position, endLocation.position, path);
    
   }
}