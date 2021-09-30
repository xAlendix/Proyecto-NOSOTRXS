using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrearCartas : MonoBehaviour
{
    public GameObject CartaPrefab;
    public int ancho;
    public int alto;
    public Transform CartasParent;
    private List<GameObject> cartas = new List<GameObject>();
    AudioSource audioSource;
    public AudioClip giraCartaSound;
    public AudioClip puntoSound;

    public Material[] materiales;
    public Texture2D[] texturas;
    public Carta CartaMostrada;
    public bool sePuedeMostrar = true;
    public int numParejasEncontradas;

    public int contadorClicks;
    public Text textoContadorIntentos;
    public float contador = 0.0f;

    public GameObject interfazVictoria;



    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        interfazVictoria = GameObject.Find("Scripts"); 
    }

    void Start()
    {
        Crear();
    }
    public void Crear()
    {
        int cont = 0;
        for (int i = 0; i < alto; i++)
        {
            for (int x = 0; x < ancho; x++)
            {
                float factorA = 3.0f / ancho;
                float factorB = 4.0f / alto;
                Vector3 posicionTemp = new Vector3(x*factorA, 0, i*factorB);
                GameObject cartaTemp = Instantiate(CartaPrefab, posicionTemp, 
                    Quaternion.Euler(new Vector3(0,180,0)));

                //cartaTemp.transform.localScale *= factor;

                cartas.Add(cartaTemp);

                cartaTemp.GetComponent<Carta>().posicionOriginal = posicionTemp;
                cartaTemp.GetComponent<Carta>().NumCarta = cont;
                cartaTemp.transform.parent = CartasParent;

                cont++;
            }
        }
        AsignarTexturas();
        Barajar();
    }
    void AsignarTexturas()
    {
        for (int i = 0; i < cartas.Count; i++)
        {
            cartas[i].GetComponent<Carta>().PonerColor(texturas[(i)/2]);
        }
    }

    void Barajar()
    {
        int aleatorio;

        for (int i = 0; i < cartas.Count; i++)
        {
            aleatorio = Random.Range(i, cartas.Count);

            cartas[i].transform.position = cartas[aleatorio].transform.position;
            cartas[aleatorio].transform.position = cartas[i].GetComponent<Carta>().posicionOriginal;

            cartas[i].GetComponent<Carta>().posicionOriginal = cartas[i].transform.position;
            cartas[aleatorio].GetComponent<Carta>().posicionOriginal = cartas[aleatorio].transform.position;
            //cartasTemp.RemoveAt(aleatorio);
        }
    }

    public void HacerClick(Carta _carta)
    {
        if(CartaMostrada == null){
            CartaMostrada = _carta;
            audioSource.PlayOneShot(giraCartaSound);
        }
        else
        {
            contadorClicks++;
            ActualizarUI();
            if (CompararCartas(_carta.gameObject, CartaMostrada.gameObject))
            {
                print("¡Acertaste!");
                audioSource.PlayOneShot(puntoSound);
                numParejasEncontradas++;
                if(numParejasEncontradas == cartas.Count / 2)
                {
                    print("Ganaste");
                    interfazVictoria.GetComponent<InterfazVictoria>().MostrarMenuGanador();
                }
                if (contador < 5.0f)
                {
                    contador = contador + 1 * Time.deltaTime;
                }
                else
                {
                    cargarnivel("Carga1");
                }
            
            }
            else
            {
                _carta.EsconderCarta();
                CartaMostrada.EsconderCarta();
            }
            CartaMostrada = null;
        }
        
    }

    public void cargarnivel(string NombreLevel)
    {
        SceneManager.LoadScene(NombreLevel);
    }
    public bool CompararCartas(GameObject carta1, GameObject carta2)
    {
        bool resultado;
        if (carta1.GetComponent<MeshRenderer>().material.mainTexture ==
            carta2.GetComponent<MeshRenderer>().material.mainTexture)
        {
            resultado = true;
        }
        else
        {
            resultado = false;
        }
        return resultado;
    }

    public void ActualizarUI()
    {
        textoContadorIntentos.text="Intentos: " + contadorClicks;
    }

}