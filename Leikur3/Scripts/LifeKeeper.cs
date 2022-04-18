using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;


// Þetta er scripta sem heldur utan um peningahaldi leikmannsins og líf hans. Scriptan sér líka um dauða leikmansis
public class LifeKeeper : MonoBehaviour
{
    // Setur upp 2/3 af stigatöflunni
    public static int count;
    public Text countText;
    public static int coins;
    public Text CoinCount;
    int sideCoin = 0;
    
    void Start()
    {
        // birtir upphafsstig
        Debug.Log("Byrja");
        count = 3;
        coins = 0;
        SetCountText();
        SetCoincount();
    }
    
    void update()
    {

    }

    void FixedUpdate()
    {
        // ef leikmaðurinn dettur einhvernveginn af leiksvæðinu
        if (transform.position.y<=-1)
        {
            Endurræsa();
        }
    }

    void OnCollisionEnter(Collision collision)
    {   
        // ef leikmaðurinn rekst á óvin
        if (collision.collider.tag == "Ovinur")
        {
            // uppfærir stigatöfluna
            Debug.Log("Ouch");
            count = count - 1;
            SetCountText();
        }
        // ef leikmaðurinn lendir í vatni
        if (collision.collider.tag == "Water")
        {
            Debug.Log("Ouch");
            count = count - count;
            SetCountText();
        }
        // ef leikmaður rekst í hjarta
        if (collision.collider.tag == "HP")
        {
            Debug.Log("Nice");
            count = count + 1;
            // Hverfur hjartað
            collision.collider.gameObject.SetActive(false);
            SetCountText();
        }
        // ef leikmaðurinn rekst á gullpening
        if (collision.collider.tag == "Coin")
        {
            coins = coins + 1;
            sideCoin = sideCoin + 1;
            collision.collider.gameObject.SetActive(false);
            SetCoincount();
        }
        // ef leikmaðurinn reynir að fara úr leiksvæðinu eins og er áætlað
        if (collision.collider.tag == "Finnishline")
        {
            Debug.Log("AtEnd");
            // ef leikmaður hefur safnað að minstalagi 5 gullpeninga
            if (sideCoin >= 5)
            {
                // birtir lokascenuna
                SceneManager.LoadScene("GameFinnish");
            }
        }
        // ef leikmaður fer á byrjunar pallinn
        if (collision.collider.tag == "Start")
        {
            // birtir aðalscenuna
            SceneManager.LoadScene("Scene1");
        }
        //Ef leikmaður fer þar sem hann á ekki að vera
        if (collision.collider.tag == "Boundry")
        {
            //Þarf hann að byrja upp á nýtt
            SceneManager.LoadScene("Scene1");
        }
    }
    void SetCountText()
    {
        // setur upp textann sem heldur utan um upplýsingar
        countText.text = "Líf: " + count.ToString();
       // ef leikmaður hefur tapað öllum lífum sínum
        if (count <= 0)
        {
            this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan

            //birtir dauðascenuna
            SceneManager.LoadScene("Dead");

        }
        
    }
    // birtir peningatalinu
    void SetCoincount()
    {
        CoinCount.text = "Peningar: " + coins.ToString();
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
