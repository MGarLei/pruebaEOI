using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    
    public GameObject pausePanel;
    public AudioMixer mixer;
    public AudioMixerSnapshot unPausedSnap, pausedSnap;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //si presionamos escape...
        {
            if (pausePanel.activeInHierarchy) //si el panel de pausa está activo en jerarquía...
            {
                unPausedSnap.TransitionTo(0); //Hace una transición a 0 al snapshot de quitar pausa
                pausePanel.SetActive(false); //si no está activo
                Cursor.lockState = CursorLockMode.Locked; //bloquear el ratón
                Time.timeScale = 1; //hacemos que corra el tiempo de juego
            }
            else 
            {
                pausedSnap.TransitionTo(0); //Hace una transición a 0 al snapshot de poner pausa
                pausePanel.SetActive(true); //si está activo panel de pausa
                Cursor.lockState = CursorLockMode.None; //desbloquear el ratón
                Time.timeScale = 0; //pausamos tiempo del juego
            }
        }
    }

    //3 funciones que modifican el volumen del Audio Mixer
    public void volumeMaster(float volume) //método para el volume master
    {
        mixer.SetFloat("volumeMaster", volume); //el nombre del parámetro expuesto

    }
    public void volumeMusic(float volume) //método para el volume music
    {
        mixer.SetFloat("volumeMusic", volume); //el nombre del parámetro expuesto

    }
    public void volumeSfx(float volume) //método para el volume sfx
    {
        mixer.SetFloat("volumeSfx", volume); //el nombre del parámetro expuesto

    }
}
