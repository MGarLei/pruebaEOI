using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //Detectar posición del jugador
    Transform player;

    //Para que dispare
    public GameObject ray;

    //Para poner el punto desde el que va a disparar
    public Transform shootPoint;

    //Para darle una cadencia de disparo
    public float cadency;

    //Tiempo desde que ha disparado por última vez
    float timeLastShoot;

    Rigidbody rig;
    EnemyMovement move;
    public ParticleSystem particles;

    void Start()
    {
        //Va a buscar a un objeto que tenga el Tag "Player" en la escena
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Asignar referencia a los otros componentes
        rig = GetComponent<Rigidbody>();
        move = GetComponent<EnemyMovement>();
    }

 
    void Update()
    {
        //Controlar el comportamiento si está cerca del player
        if (Vector3.Distance(transform.position, player.position) < 200)
        {
            //Desabilita el movimiento del enemigo
            move.enabled = false;
            //Para la nave en seco
            rig.velocity = Vector3.zero;
            //Hace que la nave mire hacia el player
            transform.LookAt(player);


            //Aquí decimos que si el tiempo de juego es mayor que la última vez que disparó + la cadencia
            //de disparo, puede volver a disparar
            if (Time.time > timeLastShoot + cadency)
            {
                //Vamos a darle play al sistema de partículas del disparo
                particles.Play();

                Instantiate(ray, shootPoint.position, shootPoint.rotation);
                timeLastShoot = Time.time;
            }
            //Time.time es el tiempo actual del juego, el tiempo que llevamos jugando
        }

        //Un else para volver a activar el movimiento de la nave
        else 
        { 
        move.enabled = true;
        }
    }
}
