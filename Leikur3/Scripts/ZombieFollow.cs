using UnityEngine;
using System.Collections;

public class ZombieFollow : MonoBehaviour
{

    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 10;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;

    void Update()
    {
        // Leitar til player
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            // ef player er innan við viðeigandi vegalengd
            if (TargetDistance < AllowedRange)
            {
                // Óvinahraði
                EnemySpeed = 0.065f;
                if (AttackTrigger == 0)
                {
                    transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
                }
            }
            // Annars bíður óvinurinn
            else
            {
                EnemySpeed = 0;
            }
        }

        if (AttackTrigger == 1)
        {
            EnemySpeed = 0;
        }
    }

    void OnTriggerEnter()
    {
        AttackTrigger = 1;
    }

    void OnTriggerExit()
    {
        AttackTrigger = 0;
    }

}