using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public Text countText;
    public float speed;
    private int count;
    private Rigidbody rb;
    public Text winText;
    public string hAxis;
    public string vAxis;
    public Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        spawnLocation = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < -50){
            transform.position = spawnLocation;
            // rb.velocity = new Vector3(0,5,0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.rotation = Quaternion.identity;
        }
        float moveHorizontal = Input.GetAxis(hAxis);
        float moveVertical = Input.GetAxis(vAxis);
 
        Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if  (other.gameObject.CompareTag("collec")){
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if (count == 8){
            winText.text = "You Win!1!";
        }
    }
}
