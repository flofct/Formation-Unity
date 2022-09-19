using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int score = 0;

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Obstacle")
        {
            score++;
            Debug.Log("Vous avez touché : "+ other.gameObject.tag + ", score : " + score);
        }

        if(other.gameObject.tag == "Arrivée")
        {
            if(score == 0)
            {
                Debug.Log("Vous avez atteint l'arrivée sans toucher d'obstacles ! Félicitations !");
            }
            else
            {
                Debug.Log("Vous avez atteint l'arrivée ! Vous avez touché " + score + " obstacles.");
            }
            
        }
    }
}
