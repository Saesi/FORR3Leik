using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;


    // Hér byrjar kóði sem lætur myndavélina fylgja playerinum
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}