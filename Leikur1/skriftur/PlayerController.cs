using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // Og hér eru allar private
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        // Disable-a tímabundið sigurtextann 
        SetCountText();
        winTextObject.SetActive(false);
    }

    // Heldur kúlunni gangandi
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();

        //Ef stigin eru 6 eða fleirri
        if(count >= 6)  
        {
            winTextObject.SetActive(true);
        }
    }


    // Munurinn á Update og FixedUpdate er sá að FixedUpdate gerir aðeins aðgerðirnar 60 sinnum á sekúndu.
    private void FixedUpdate()
    {
        // Hér er hreyfingin gerð. Allt inn í vettvangnum (scene) er staðsett með x,y og z ásum og hér er það notað.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    
    // Hér er fallið sem tékkar á því ef þú snertir gameobject með ákveðin tags
    private void OnTriggerEnter(Collider other)
    {
        // Annað klassískt if fall sem skoðar (comapres) ef það er með sama PickUp fallið 
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Þegar if fallið er ræst, er losað við gameobject, eða það er falið fyrir notendanum. 
            other.gameObject.SetActive(false);
            // Svo er bætt við stigum þegar hluturinn er farinn.
             count = count + 1;

             SetCountText();
        }
 
    }

}