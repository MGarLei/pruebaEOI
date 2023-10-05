using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Float para la vida máxima del player
    public float maxHealth;

    //Vida del jugador que va a ir bajando cuando le hagamos daño al player
    private float currentHealth;

    //La imagen de la interfaz que va a ir bajando cuando el player reciba daño
    public Image ImageHealth;

    //Variable para la pantalla de Game Over
    public GameObject gameOver;
    void Start()
    {
        //Con esto indicamos que la vida actual de la nave al principio del juego sea su vida máxima
        currentHealth = maxHealth;
    }

    //Bajar barra de vida cuando colisiona el rayo enemigo con el player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RayEnemy")) //busca lo que tenga el tag de RayEnemy
        {
            //Reducimos en 1 la variable de currentHealth
            currentHealth--;

            //El Fill amount va de 0 a 1, le asignamos la división entre la vida máxima
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
