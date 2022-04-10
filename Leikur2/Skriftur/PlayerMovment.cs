using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20;
    public float sideways = 20;
    public float jump = 20;
    //private Rigidbody leikmadur;
    public static int count;
    public Text countText;

    void Start()
    {
        Debug.Log("byrja");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Hér að neðan eru öll intökinn fyrir playerinn
        if (Input.GetKey("g"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("f"))//snúa leikmanni
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        if (Input.GetKey(KeyCode.Space))//hoppa
        {
            transform.position += transform.up * jump ;
        }
        if (transform.position.y <= -1)
        {
            Endurræsa();
        }
        if (Input.GetKey(KeyCode.UpArrow))//áfram
        {
            transform.position += transform.forward * speed ;
        }
        if (Input.GetKey(KeyCode.DownArrow))// til baka
        {
            transform.position += -transform.forward * speed;

        }
        if (Input.GetKey(KeyCode.RightArrow))//hægri
        {
            transform.position += transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.LeftArrow))//vinstri
        {
            //hreyfir player um sideways í hvert skipti sem ýtt er á leftArrow
            transform.position += -transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("búmm");
            //Vector3 movement = new Vector3(0, 10, 0);
            transform.position +=transform.up *jump;
        }
        if (transform.position.y<=-1)
        {
            Endurræsa();
        }
    }
   
     void OnCollisionEnter(Collision collision)
    {
        // Hér að neðan er fylgt eftir hvort playerinn kemur við eitthvað og hvað skuli gera
        // ef player keyrir á object sem heitir hlutur
        if (collision.collider.tag == "hlutur")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 1;
           // Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "pikk")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 5;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "hindrun")
        {
            //collision.collider.gameObject.SetActive(false);
            count = count -3;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "finnish")
        {
            //Debug.Log("Next");
            SceneManager.LoadScene("Scene2");
        }
        if (collision.collider.tag == "finnishline")
        {
            Debug.Log("Next");
            SceneManager.LoadScene("Finnish");
        }
    }
    void SetCountText()
    {
        // setur upp textann sem heldur utan um upplýsingar
        countText.text = "Stig: " + count.ToString();
       
        if (count <= 0)
        {
            this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan

            countText.text = "Svo dauðððððððððððððððður " + count.ToString()+" stigum";
            
            StartCoroutine(Bida());
            //gameObject.SetActive(false);

        }
        
    }
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(1);
        
        Endurræsa();
    }
   
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    public void Endurræsa()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Level_1
       
        SceneManager.LoadScene(0);
        count=0;
    }

}
