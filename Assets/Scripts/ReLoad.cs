using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLoad : MonoBehaviour
{
    //Vamos a hacer que se recargue la escena.
    //Necesitamos la librería UnityEngine.SceneManagement

    public void DoReload()
    {
        //Reactivamos el tiempo del juego (quitando la pausa) 
        Time.timeScale = 1;

        //Le decimos al scene manager que cargue una nueva escena y le decimos la escena que
        //queremos que cargue, en este caso la misma
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //si quisiéramos cargar otra escena distinta le pondríamos entre paréntesis después
        //de LoadScene la escena que queremos que cargue
    }
}
