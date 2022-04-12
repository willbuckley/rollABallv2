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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

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
