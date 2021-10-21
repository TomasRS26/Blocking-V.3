using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorScript : MonoBehaviour
{
    //Variables
    public float Velocidad;
    public float VelocidadSalto;
    public float VelocidadCayendo;
    public float VelocidadAgachado;
    public float VelocidadSaltoAgachado;

    float VelocidadJugador;
    float FuerzaSalto;

    public float Gravedad;

    bool Agachado = false;
    bool Escalando = false;
    bool Cayendo = false;

    [SerializeField] GameObject Luz;
    //Variables

    //Vector de movimiento personaje
    Vector3 VectorMovimiento = Vector3.zero;

    //Conector con Character Controller
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        VelocidadJugador = Velocidad;
        FuerzaSalto = VelocidadSalto;
    }
    void Update()
    {
        MoverJugador();
    }

    void MoverJugador ()
    {

        //Movimiento normal

        VectorMovimiento.x = Input.GetAxis("Horizontal") * VelocidadJugador;

        //Salto

        if (characterController.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                VectorMovimiento.y = FuerzaSalto;
            }

            Cayendo = false;
        }
        else
        {
            Cayendo = true;
        }

        VectorMovimiento.y -= Gravedad * Time.deltaTime;


        //Caida

        if (Cayendo == true)
        {
            VectorMovimiento.y -= Gravedad * Time.deltaTime;
            VelocidadJugador = VelocidadCayendo;

        }
        else if(Cayendo == false)
        {
            VelocidadJugador = Velocidad;
        }


        //Agachar

        if(Input.GetKeyDown(KeyCode.G) && Agachado == false)
        {
            Agachado = true;
        }
        else if (Input.GetKeyDown(KeyCode.G) && Agachado == true)
        {
            Agachado = false;
        }

        if(Agachado == true)
        {
            Vector3 Escala = transform.localScale;
            Escala.y = 0.5f;
            transform.localScale = Escala;

            VelocidadJugador = VelocidadAgachado;
            FuerzaSalto = VelocidadSaltoAgachado;
        }
        else if(Agachado == false)
        {
            Vector3 Escala = transform.localScale;
            Escala.y = 1f;
            transform.localScale = Escala;

            VelocidadJugador = Velocidad;
            FuerzaSalto = VelocidadSalto;
        }


        //Escalar y trepar

        if(Escalando == true)
        {
            VectorMovimiento.y = Input.GetAxis("Vertical") * VelocidadJugador;
        }


        //Traductor de movimiento character controller
        characterController.Move(VectorMovimiento * Time.deltaTime);

    }

    //Triggers

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Escaleras y Lianas" && Escalando == false)
        {
            Escalando = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Escaleras y Lianas" && Escalando == true)
        {
            Escalando = false;

            VectorMovimiento.y = FuerzaSalto;
        }
    }
}
