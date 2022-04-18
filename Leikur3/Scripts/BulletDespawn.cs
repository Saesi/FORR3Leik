using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Þetta er scripta sem eyðir byssukúlunni ákveðinn tíma svo allar byssukúlurnar sem hafa veið skotnar hægja ekki fyrir leikinn
public class BulletDespawn : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Object.Destroy(gameObject, 2.0f);
    }
}
