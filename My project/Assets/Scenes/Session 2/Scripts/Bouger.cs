using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouger : MonoBehaviour
{

    [SerializeField] float moveSpeed = 30f;

    void Start()
    {
       Instructions();
    }

    void Update()
    {
        SeDeplacer();
    }

    void Instructions()
    {
        Debug.Log("Bienvenue dans ce jeu");
        Debug.Log("Pour vous déplacer, utilisez les flèches directionnelles");
        Debug.Log("Vous pouvez aussi utiliser ZQSD pour vous déplacer, ou WASD si votre clavier est en QWERTY");
        Debug.Log("Ne touchez pas les murs !");
    }

    void SeDeplacer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue,0,zValue);
    }
}
