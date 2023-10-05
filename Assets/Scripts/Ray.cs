using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    public float speed;

    //Destruir el proyectil
    private void Start()
    {
        Destroy(gameObject, 3);
    }

    //Movimiento del proyectil
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    //Colisión del proyectil, elimina con lo que colisiona
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
