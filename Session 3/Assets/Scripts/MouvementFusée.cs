using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementFusée : MonoBehaviour
{
    [SerializeField] float puissance = 10f;
    [SerializeField] float rotation = 50f;
    [SerializeField] AudioClip moteurFusée;

    [SerializeField] ParticleSystem moteurPrincipal;
    [SerializeField] ParticleSystem moteurGauche;
    [SerializeField] ParticleSystem moteurDroit;


    AudioSource audioSource;
    Rigidbody corps;  

    void Start()
    {
       corps = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
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
            DébutPoussée();
        }
        else
        {
            StopPoussée();
        }

    }
    void Rotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            RotationGauche();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotationDroite();
        }
        else
        {
            StopRotation();
        }

    }


    void DébutPoussée()
    {
        corps.AddRelativeForce(Vector3.up * puissance * Time.deltaTime);
        moteurPrincipal.Play();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(moteurFusée);
        }
    }
    private void StopPoussée()
    {
        audioSource.Stop();
        moteurPrincipal.Stop();
    }


    private void RotationDroite()
    {
        EffectuerRotation(rotation);
        if (!moteurGauche.isPlaying)
        {
            moteurGauche.Play();
        }
    }

    private void RotationGauche()
    {
        EffectuerRotation(-rotation);
        if (!moteurDroit.isPlaying)
        {
            moteurDroit.Play();
        }
    }

    private void StopRotation()
    {
        moteurDroit.Stop();
        moteurGauche.Stop();
    }

    void EffectuerRotation(float sensRotation)
    {
        corps.freezeRotation = true;
        transform.Rotate(Vector3.back * sensRotation * Time.deltaTime);
        corps.freezeRotation = false;
    }
    


}
