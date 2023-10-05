using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject ray;

    //Array de transform
    public Transform[] shootPoint;

    private void Update()
    {
        //Hacer que la nave no dispare cuando tenemos el menú de pausa abierto
        if (Time.timeScale == 0)
            return;
        
        //Condición para el disparo
        if (Input.GetButtonDown("Fire1"))
        {
            //Bucle de 4 vueltas ya que tenemos 4 puntos de disparo
            for (int i = 0; i < 4; i++)
            {
                //En cada vuelta del bucle se crea un rayo en distinta posición, 1, 2, 3...
                //Cuando vale 4 se termina el bucle
                Instantiate(ray, shootPoint[i].position, shootPoint[i].rotation);
                shootPoint[i].GetChild(0).GetComponent<ParticleSystem>().Play();
            }
        }
        //GetComponent<AudioSource>().Play(); para hacer que se reproduzca el sonido del
        //disparo del audio source del player
    }





}
