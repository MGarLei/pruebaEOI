using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Float para la vida m�xima del player
    public float maxHealth;

    //Vida del jugador que va a ir bajando cuando le hagamos da�o al player
    private float currentHealth;

    //La imagen de la interfaz que va a ir bajando cuando el player reciba da�o
    public Image ImageHealth;

    //Variable para la pantalla de Game Over
    public GameObject gameOver;
    void Start()
    {
        //Con esto indicamos que la vida actual de la nave al principio del juego sea su vida m�xima
        currentHealth = maxHealth;
    }

    //Bajar barra de vida cuando colisiona el rayo enemigo con el player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RayEnemy")) //busca lo que tenga el tag de RayEnemy
        {
            //Reducimos en 1 la variable de currentHealth
            currentHealth--;

            //El Fill amount va de 0 a 1, le asignamos la divisi�n entre la vida m�xima
            ImageHealth.fillAmount = currentHealth / maxHealth;

            if (currentHealth <= 0)
            {
                //Activamos pantalla game over
                gameOver.SetActive(true);
                //Activamos el movimiento del cursor
                Cursor.lockState = CursorLockMode.None;
                //Ponemos la escala de tiempo a 0 (pausamos el juego)
                Time.timeScale = 0;
            }
        }
    }
}
