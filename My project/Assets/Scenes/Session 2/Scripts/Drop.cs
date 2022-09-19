using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] float temps = 3f;
    MeshRenderer renderer;
    Rigidbody rigidBody;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();

        renderer.enabled = false;
        rigidBody.useGravity = false;
        
    }

    void Update()
    {
        if(Time.time > temps)
        {
            renderer.enabled = true;
            rigidBody.useGravity = true;
        }
    }
}
