using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfazVictoria : MonoBehaviour
{
    public GameObject menuGanador;
    public GameObject menuMarco;
    public GameObject menuEstrella3;
    public GameObject menuEstrella2;
    public GameObject menuEstrella1;
    public GameObject niveles;
    public bool menuMostradoGanador;
    AudioSource audioSource;

    public AudioClip victoriaSound;
    public GameObject crearcartas;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void MostrarMenuGanador()
    {
        audioSource.PlayOneShot(victoriaSound);
        menuGanador.SetActive(true);
        menuMarco.SetActive(true);
        niveles.SetActive(true);
        if(crearcartas.GetComponent<CrearCartas>().contadorClicks <= 15)
        {
            menuEstrella3.SetActive(true);
        }else if((crearcartas.GetComponent<CrearCartas>().contadorClicks > 15) && 
            (crearcartas.GetComponent<CrearCartas>().contadorClicks <= 21))

        {
            menuEstrella2.SetActive(true);
            menuEstrella3.SetActive(false);
        }
        else
        {
            menuEstrella1.SetActive(true);
            menuEstrella2.SetActive(false);
            menuEstrella3.SetActive(false);
        }
        menuMostradoGanador = true;
    }

    public void EsconderMenuGanador()
    {
        menuGanador.SetActive(false);
        menuMarco.SetActive(false);
        menuEstrella1.SetActive(false);
        menuEstrella2.SetActive(false);
        menuEstrella3.SetActive(false);
        niveles.SetActive(false);
        menuMostradoGanador = false;
    }
}
