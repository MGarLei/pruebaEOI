using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //Float para la vida máxima del player
    public float maxHealth;

    //Vida del jugador que va a ir bajando cuando le hagamos daño al enemigo
    private float currentHealth;

    //La imagen de la interfaz que va a ir bajando cuando el enemigo reciba daño
    public Image ImageHealth;

    //Variable para la explosión cuando muera el enemigo
    public GameObject particleExplosion;
    void Start()
    {
        //Con esto indicamos que la vida actual de la nave al principio del juego sea su vida máxima
        currentHealth = maxHealth;
    }

    //Bajar barra de vida cuando colisiona el rayo del player con el enemigo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RayPlayer")) //busca lo que tenga el tag de RayPlayer
        {
            //Reducimos en 1 la variable de currentHealth
            currentHealth--;

            //El Fill amount va de 0 a 1, le asignamos la división entre la vida máxima
            ImageHealth.fillAmount = currentHealth / maxHealth;

            //Condicional para la muerte del enemigo
            if (currentHealth == 0)
            {
                //Accedemos a la variable estática GameManager para incrementar el número
                //de enemigos que hemos matado
                GameManager.instance.IncreaseEnemies();
                
                //Instanciamos la explosión (partículas) que se reproduzca cuando la vida del enemigo llegue a 0
                Instantiate(particleExplosion, transform.position, transform.rotation);

                
                //Destruir al enemigo si su vida llega a 0
                Destroy(gameObject);
            }
        }
    }
}
