using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    void Start ()
    {

        offset = transform.position - player.transform.position;

    }
         void Update() 
    {
    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }    
    }

    void LateUpdate ()
    {

        transform.position = player.transform.position + offset;
        
    }
}