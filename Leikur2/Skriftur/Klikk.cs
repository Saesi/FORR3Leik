using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Klikk : MonoBehaviour
{
    public void Byrja()
    {
        SceneManager.LoadScene("Scene1");
    }
    
    void FixedUpdate()
    {
        // Hér er einfalt intak til að byrja leikinn
        if (Input.GetKey("e"))
        {
            SceneManager.LoadScene("Scene1");
        }
        
    }
}
