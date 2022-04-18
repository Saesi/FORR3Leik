using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

//Þetta er scripta sem lætur byssuna skjóta byssukúlu
public class LaunchProjectile : MonoBehaviour
{
    //Tekur inn breytur
   public GameObject projectile;
   public float launchVelocity = 700f;
   public InputAction fireAction;
   void start()
   {
       Debug.Log("Begin");
   }

   void Update()
   {
       fireAction.Enable();
       //Ef takkinn sem er notaður til að skjóta byssuni er notaður
       if (fireAction.triggered)
       {
           Debug.Log("Fire!");
           //Er byssukúlunni skottið frá byssuni
           GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
           ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0,0,launchVelocity));
       }
   }
}