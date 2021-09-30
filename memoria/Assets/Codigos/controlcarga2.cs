using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlcarga2 : MonoBehaviour
{
    public float contador = 0.0f;

    // Update is called once per frame
    void Update()
    {

        if (contador < 5.0f)
        {
            contador = contador + 1 * Time.deltaTime;

        }
        else
        {
            cargarnivel("Menu");
        }
    }

    public void cargarnivel(string NombreLevel)
    {
        SceneManager.LoadScene(NombreLevel);
    }
}

