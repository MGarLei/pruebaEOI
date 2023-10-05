using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject[] rock;
    void Start()
    {
        //Bucle for que d� 200 vueltas para crear 200 rocas

        for (int i = 0; i < 200; i++) 
        {
            //Posici�n aleatoria entre -1000 y 1000 en todos los ejes (x, y, z) dentro del cubo que hemos creado
            Vector3 position = new Vector3(
                Random.Range(-1000, 1000),
                Random.Range(-1000, 1000),
                Random.Range(-1000, 1000));

            //Rotaciones aleatorias
            Quaternion rotation = Quaternion.Euler(
                Random.Range(0, 360),
                Random.Range(0, 360),
                Random.Range(0, 360));

            //Variable int para hacer las rocas aleatorias
            int index = Random.Range(0, rock.Length);
            //Instanciar la roca, se crear�n como hijas del objeto vac�o Spawner para que est�n ordenadas
            GameObject newRock = Instantiate(rock[index], position, rotation, transform);

            //Escala de la roca aleatoria
            newRock.transform.localScale = new Vector3(
                Random.Range(10, 50),
                Random.Range(10, 50),
                Random.Range(10, 50));

            //"Animaci�n" de rotaci�n de las rocas aleatoria
            newRock.GetComponent<Rigidbody>().angularVelocity = new Vector3(
                Random.Range(0f, 0.5f),
                Random.Range(0f, 0.5f),
                Random.Range(0f, 0.5f));
        }
    }


    void Update()
    {
        
    }
}
