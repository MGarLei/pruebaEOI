using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    Vector3 destination;
    Rigidbody rig;

    //Enemigo va a un punto aleatorio, cuando llega irá a otro punto aleatorio
    void RandomDestination()
    {
        destination = new Vector3(
            Random.Range(-1000, 1000),
            Random.Range(-1000, 1000),
            Random.Range(-1000, 1000));

        //player = GameObject.FindGameObjectWithTag("Player").transform; el enemigo va en busca del player
    }
    void Start()
    {
        
        rig = GetComponent<Rigidbody>();
        RandomDestination();
        
    }

    void Update()
    {
        //Comportamiento de la nave frame a frame
        transform.LookAt(destination);
        rig.velocity = transform.forward * speed;

        if (Vector3.Distance(transform.position, destination) < 10)
            RandomDestination();
        
    }
}
