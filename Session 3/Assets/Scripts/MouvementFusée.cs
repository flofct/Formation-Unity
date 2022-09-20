using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementFusée : MonoBehaviour
{
    Rigidbody corps;
    [SerializeField] float puissance = 10f;
    [SerializeField] float rotation = 50f;


    void Start()
    {
       corps = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Poussée();
        Rotation();
    }

    void Poussée()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            corps.AddRelativeForce(Vector3.up * puissance * Time.deltaTime);
        }        
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            EffectuerRotation(-rotation);
        }

        else 
        
        if (Input.GetKey(KeyCode.D))
        {
            EffectuerRotation(rotation);
        }
    }

    void EffectuerRotation(float sensRotation)
    {
        corps.freezeRotation = true;
        transform.Rotate(Vector3.back * sensRotation * Time.deltaTime);
        corps.freezeRotation = false;
    }

    
}
