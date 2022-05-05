using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Starting : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        // Takki til að byrja leik
        if(Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
