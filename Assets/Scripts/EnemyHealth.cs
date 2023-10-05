using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //Float para la vida m�xima del player
    public float maxHealth;

    //Vida del jugador que va a ir bajando cuando le hagamos da�o al enemigo
    private float currentHealth;

    //La imagen de la interfaz que va a ir bajando cuando el enemigo reciba da�o
    public Image ImageHealth;

    //Variable para la explosi�n cuando muera el enemigo
    public GameObject particleExplosion;
    void Start()
    {
        //Con esto indicamos que la vida actual de la nave al principio del juego sea su vida m�xima
        currentHealth = maxHealth;
    }

    //Bajar barra de vida cuando colisiona el rayo del player con el enemigo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RayPlayer")) //busca lo que tenga el tag de RayPlayer
        {
            //Reducimos en 1 la variable de currentHealth
            currentHealth--;

            //El Fill amount va de 0 a 1, le asignamos la divisi�n entre la vida m�xima
            ImageHealth.fillAmount = currentHealth / maxHealth;

            //Condicional para la muerte del enemigo
            if (currentHealth == 0)
            {
                //Accedemos a la variable est�tica GameManager para incrementar el n�mero
                //de enemigos que hemos matado
                GameManager.instance.IncreaseEnemies();
                
                //Instanciamos la explosi�n (part�culas) que se reproduzca cuando la vida del enemigo llegue a 0
                Instantiate(particleExplosion, transform.position, transform.rotation);

                
                //Destruir al enemigo si su vida llega a 0
                Destroy(gameObject);
            }
        }
    }
}
