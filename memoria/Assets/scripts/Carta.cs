using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    public int NumCarta = 0;
    public Vector3 posicionOriginal;
    public Texture2D texturaAnverso;
    public Texture2D texturaReverso;
    public GameObject crearCartas;
    AudioSource audioSource;
    public bool Mostrando;
    
    public float tiempoDelay;

    public GameObject interfazVictoria;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        crearCartas = GameObject.Find("Scripts");
    }
    void Start()
    {
        EsconderCarta();
    }

    void OnMouseDown()
    {
        print(NumCarta.ToString());
        MostrarCarta();
    }

    public void PonerColor(Texture2D _textura)
    {
        texturaAnverso = _textura;
        
    }
    public void MostrarCarta()
    {
        if (!Mostrando && crearCartas.GetComponent<CrearCartas>().sePuedeMostrar)
        {
            Mostrando = true;
            GetComponent<MeshRenderer>().material.mainTexture = texturaAnverso;
            //Invoke("EsconderCarta", tiempoDelay);
            crearCartas.GetComponent<CrearCartas>().HacerClick(this);
        }
    }

    public void EsconderCarta()
    {
        Invoke("Esconder", tiempoDelay);
        crearCartas.GetComponent<CrearCartas>().sePuedeMostrar = false;
    }

    void Esconder()
    {
        GetComponent<MeshRenderer>().material.mainTexture = texturaReverso;
        Mostrando = false;
        crearCartas.GetComponent<CrearCartas>().sePuedeMostrar = true;
    }

}
