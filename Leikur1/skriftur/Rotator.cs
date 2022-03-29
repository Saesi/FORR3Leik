using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update gerist einu sinni í hverjum ramma.
    void Update()
    {
        //lætur peningana snúast
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}