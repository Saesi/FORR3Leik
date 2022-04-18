using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Þetta er skripta sem eyðir óvin sem hluturinn sem scriptan tengist(Byssukúlan) rekast saman

public class BulletKill : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // ef rekst á óvin deyr óvinurinn
        if (other.gameObject.CompareTag("Ovinur"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
