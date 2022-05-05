using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Leikmaður tekur skaða ef hann labbar yfir það sem er með þessa skriptu á sér
public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController >();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }
}