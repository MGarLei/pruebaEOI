using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Necesitamos la librer�a TMPro

    //Creamos una variable est�tica del propio script para acceder r�pidamente a �l

    //Est�tico es algo que no se mueve, la memoria ram escribe y borra datos, si
    //hacemos una variable static en un script no se borra nunca (solo cuando se ciera el juego)
    public static GameManager instance;

    //Para llevar la cuenta de los enemigos derrotados
    private int enemies = 0;

    //Referencia al texto creado en el canvas
    public TextMeshProUGUI textEnemies;

    private void Start()
    {
        //Variable que no se borra en la memoria (est�tica), podemos acceder a �l a trav�s de la memoria
        instance = this; //this = este componente
    }

    //Actualizar el texto que vemos en el canvas (enemigos que hemos matado)
    public void IncreaseEnemies()
    {
        enemies++;
        textEnemies.text = "enemies: " + enemies;
    }

    //Desde cualquier otro script escribiendo la variable "instance" hacemos que ese script acceda a los
    //m�todos y variables de este script, es un acceso r�pido y eficiente

    //No se pueden tener 2 scripts GameManager en la misma escena!

}
