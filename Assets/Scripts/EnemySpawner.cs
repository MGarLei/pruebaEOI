using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Array para crear enemigos
    public GameObject[] enemy;
    private void Start()
    {
        //Llamar al método de forma recurrente usando el comando InvokeRepeating
        //Va a ejecutar el método spawn, la primera vez a los 5 segundos y luego cada 5 segundos
        InvokeRepeating("Spawn", 5, 5);
        //con "Spawn" estamos llamando a la función de más abajo
    }

    //método spawn para que spawneen enemigos en un sitio aleatorio
    public void Spawn()
    {

        Vector3 position = new Vector3(
            Random.Range(-1000, 1000),
            Random.Range(-1000, 1000),
            Random.Range(-1000, 1000));

        //si tenemos varios enemigos en el array tomará uno de manera aleatoria para spawnearlo
        int random = Random.Range(0, enemy.Length);

        //Quaternion identity es la rotación 0, 0, 0, con el ,transform hacemos que se generen dentro del
        //spawner en la escena para que quede más ordenado
        Instantiate(enemy[random], position, Quaternion.identity, transform);
    }
}
