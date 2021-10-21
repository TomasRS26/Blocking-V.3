using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointScript : MonoBehaviour
{

    int ZonaDeMuerte;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Lava")
        {
            Muerte();
        }

        if (other.tag == "Zona 1")
        {
            ZonaDeMuerte = 1;
        }

        if (other.tag == "Zona 2")
        {
            ZonaDeMuerte = 2;
        }

        if (other.tag == "Zona 3")
        {
            ZonaDeMuerte = 3;
        }

        if (other.tag == "Zona 4")
        {
            ZonaDeMuerte = 4;
        }

        if (other.tag == "Zona 5")
        {
            ZonaDeMuerte = 5;
        }

        if (other.tag == "Zona 6")
        {
            ZonaDeMuerte = 6;
        }

        if (other.tag == "Zona 7")
        {
            ZonaDeMuerte = 7;
        }

        if (other.tag == "Tutorial")
        {
            ZonaDeMuerte = 8;
        }

        if (other.tag == "Puerta")
        {
            SceneManager.LoadScene(1);
        }

        if (other.tag == "Puerta Final")
        {
            SceneManager.LoadScene(9);
        }
    }
    void Muerte()
    {
        if(ZonaDeMuerte == 1)
        {
            SceneManager.LoadScene(1);
        }

        if (ZonaDeMuerte == 2)
        {
            SceneManager.LoadScene(2);
        }

        if (ZonaDeMuerte == 3)
        {
            SceneManager.LoadScene(3);
        }

        if (ZonaDeMuerte == 4)
        {
            SceneManager.LoadScene(4);
        }

        if (ZonaDeMuerte == 5)
        {
            SceneManager.LoadScene(5);
        }

        if (ZonaDeMuerte == 6)
        {
            SceneManager.LoadScene(6);
        }

        if (ZonaDeMuerte == 7)
        {
            SceneManager.LoadScene(7);
        }

        if (ZonaDeMuerte == 8)
        {
            SceneManager.LoadScene(8);
        }
    }
}
