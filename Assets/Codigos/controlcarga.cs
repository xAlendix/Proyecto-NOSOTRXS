using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlcarga : MonoBehaviour
{

    public void cargarnivel(string NombreLevel)
    {
        SceneManager.LoadScene(NombreLevel);
    }
}
