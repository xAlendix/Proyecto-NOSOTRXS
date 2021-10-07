using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlcarga1 : MonoBehaviour
{
    public float contador = 0.0f;

    // Update is called once per frame
    public void Update()
    {

        if (contador < 5.0f)
        {
            contador = contador + 1 * Time.deltaTime;

        }
        else
        {
            cargarnivel("Niveles");
        }
    }

    public void cargarnivel(string NombreLevel)
    {
        SceneManager.LoadScene(NombreLevel);
    }
}
