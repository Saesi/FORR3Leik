using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

//Þetta er scripta sem uppfærir 1/3 af stigatöfluni
public class EnemyScript : MonoBehaviour
{
    //Tekur inn texta til að breyta
    public static int Score;
    public Text ScoreCount;

    void Start()
    {
        //Birtir byrjunarstig
        Score = 0;
        SetScorecount();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ef óvinur rekst á byssukúlu
        if (other.gameObject.CompareTag("Bullet"))
        {
            //Eykst stigin
            Debug.Log("Hit");
            Score = Score + 35;
            SetScorecount();    //Kallar á fall til að uppfæra stigin á stigatöfluna
        }
    }
    //Fall sem uppfærir stigatöfluna
    void SetScorecount()
    {
        ScoreCount.text = "Stig: " + Score.ToString();
    }
}
