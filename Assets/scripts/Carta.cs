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
        StartCoroutine(MostrarCarta());
    }

    public void PonerColor(Texture2D _textura)
    {
        texturaAnverso = _textura;
        
    }
    public IEnumerator MostrarCarta()
    {
        for (int i = 0; i < 90; i+=2)
        {
            transform.eulerAngles = new Vector3(0, 0, i);
            yield return new WaitForSeconds(0.15f / 180f);
        }
        if (!Mostrando && crearCartas.GetComponent<CrearCartas>().sePuedeMostrar)
        {
            Mostrando = true;
            GetComponent<MeshRenderer>().material.mainTexture = texturaAnverso;
            //Invoke("EsconderCarta", tiempoDelay);
            crearCartas.GetComponent<CrearCartas>().HacerClick(this);
        }
        for (int i = 0; i < 90; i+=2)
        {
            transform.eulerAngles = new Vector3(0, 0, 90+i);
            yield return new WaitForSeconds(0.15f / 180f);
        }
    }

    public void EsconderCarta()
    {
        StartCoroutine(Esconder());
        crearCartas.GetComponent<CrearCartas>().sePuedeMostrar = false;
    }

    IEnumerator Esconder()
    {
        yield return new WaitForSeconds(tiempoDelay);
        for (int i = 180; i > 90; i -= 2)
        {
            transform.eulerAngles = new Vector3(0, 0, i);
            yield return new WaitForSeconds(0.15f / 180f);
        }
        GetComponent<MeshRenderer>().material.mainTexture = texturaReverso;
        Mostrando = false;
        crearCartas.GetComponent<CrearCartas>().sePuedeMostrar = true;
        for (int i = 90; i > 0; i -= 2)
        {
            transform.eulerAngles = new Vector3(0, 0, i);
            yield return new WaitForSeconds(0.15f / 180f);
        }
    }

}
