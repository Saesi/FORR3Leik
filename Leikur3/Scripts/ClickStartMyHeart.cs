using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;


//Þetta er scripta sem lætur mann byrja aftur á aðalscenuni skuli leikmaður deyja
public class ClickStartMyHeart : MonoBehaviour
{
    public InputAction fireAction;
    void Start()
    {
        
    }

    void Update()
    {
        fireAction.Enable();
        // Ef takkinn sem á að ýtta á er notaður
        if (fireAction.triggered)
        {
            // Birtir aðalscenuna
            SceneManager.LoadScene("Scene1");
        }
    }
}
