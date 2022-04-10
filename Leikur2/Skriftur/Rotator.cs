using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ræsi skriftuna
public class Rotator : MonoBehaviour
{

    // Update gerist einu sinni í hverjum ramma.
    void Update()
    {
        // Hér er skipun sem einfaldlega snýr hluti
        transform.Rotate(new Vector3(0, 80, 0) * Time.deltaTime);
    }
}