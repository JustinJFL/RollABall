using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour 
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text pickupText;

    private Rigidbody rb;
    private int scoreCount;
    private int pickupCount;
    private int yellowCount;
    public Transform playerLocation;

    void Start ()
    {
        playerLocation = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        scoreCount = 0;
        pickupCount = 0;
        yellowCount = 0;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

     void Update() {
    
    if (Input.GetKey("escape"))
     Application.Quit();    
    
    }

        void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive (false);
            scoreCount = scoreCount + 1;
            pickupCount = pickupCount + 1;
            yellowCount = yellowCount + 1;
            SetCountText ();
        }
        else if (other.gameObject.CompareTag ("Enemy"))
        {
            other.gameObject.SetActive (false);
            scoreCount = scoreCount -1 ;
            pickupCount = pickupCount + 1;
            SetCountText ();
        }
    }
    
    void SetCountText ()
    {
        countText.text = "Score: " + scoreCount.ToString ();
        pickupText.text = "Pickups Acquired: " + pickupCount.ToString();
        
        if (yellowCount == 12)
        {
            StartCoroutine(moveDelay(3f));
            winText.text = "Level 1 Complete.";
            Invoke("disableText", 3f);
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Invoke("restorePlayer", 3.5f);
        }
        else if (yellowCount ==20 && pickupCount >20)
        {
            countText.text = "";
            pickupText.text = "";
            winText.text = "You Lost!";
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else if (yellowCount == 20 && pickupCount == 20)
        {
            countText.text = "";
            pickupText.text = "";
            winText.text = "You Won!";
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    void disableText ()
    {
        winText.text = "";
    }

    void movePlayer()
    {
        playerLocation.position = new Vector3(120.0f,2.5f,0);
    }

    void restorePlayer()
    {
        rb.constraints = RigidbodyConstraints.None;
    }

     IEnumerator moveDelay(float time)
    {
         yield return new WaitForSeconds(time);
         movePlayer();    
    }

}
