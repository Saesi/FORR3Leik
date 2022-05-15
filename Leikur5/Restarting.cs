using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarting : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        //Takki til að fara aftur á byrjunarsenu
        if(Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
