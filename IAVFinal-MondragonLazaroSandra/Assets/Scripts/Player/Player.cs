using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;

public class Player : MonoBehaviour
{
    public enum Estado { idle, andar, lavar, verTele, comer, jugarOrdenador, baño, dormir, ejercicio, trabajar, muerto};
    public Estado estado = Estado.idle;
    //Tiempo que tiene que pasar en cada tick
    public float tiempoTick {get; set;}
    //Tiempo actual transcurrido
    float tiempoActual;
    float tiempoTotal;
    //Dinero del sim

    public bool accionControlada = false;
    [SerializeField] public int dinero;

    //Atributos del sim
    [SerializeField] public double higiene     = 60;
    [SerializeField] public double hambre      = 60;
    [SerializeField] public double sueño       = 100;
    [SerializeField] public double diversión   = 80;
    [SerializeField] public double baño        = 80;

    //Resta continua
    [SerializeField] double restaConstante = 0.01;
    [SerializeField] double restaHambre = 0.05;
    [SerializeField] double restaSueño = 0.05;
    [SerializeField] double restaHigiene = 0.07;
    [SerializeField] double restaDiversión = 0.3;
    [SerializeField] double restaBaño = 0.9;

    //Feedback al jugador
    [SerializeField] Scrollbar sliderHigiene;
    [SerializeField] Scrollbar sliderHambre;
    [SerializeField] Scrollbar sliderSueño;
    [SerializeField] Scrollbar sliderDiversion;
    [SerializeField] Scrollbar sliderBaño;

    [SerializeField] Text textoDinero;
    [SerializeField] GameObject panelMuerte;
    [SerializeField] GameObject panelVida;
    [SerializeField] GameObject pis;

    public double aumentoHambre { get; set; }
    public double aumentoSueño { get; set; }
    public double aumentoHigiene { get; set; }
    public double aumentoDiversion { get; set; }
    public double aumentoBaño { get; set; }

    Animator animator;

    void Start()
    {
        tiempoTick = 0.1f;
        tiempoActual = Time.time;
        tiempoTotal = Time.time;

        animator = GetComponent<Animator>();
    }
    /// <summary>
    /// Comprueba (si ha pasado el tiempo correspondiente) el estado en el que se encuentra realizando la accion 
    /// correspondiente al estado. Comprueba sys estadísticas y actualiza el feedback
    /// </summary>
    void Update()
    {
        tiempoTotal += Time.deltaTime;
        if(tiempoTotal - tiempoActual > tiempoTick)
        {
            tiempoActual = tiempoTotal;
            QuitarConstantes(); 
            switch (estado)
            {
                case Estado.idle:               Idle();             break;
                case Estado.andar:              Andar();            break;
                case Estado.lavar:              Lavar();            break;
                case Estado.verTele:            VerTele();          break;
                case Estado.comer:              Comer();            break;
                case Estado.jugarOrdenador:     JugarOrdenador();   break;
                case Estado.baño:               UsarBaño();         break;
                case Estado.dormir:             Dormir();           break;
                case Estado.ejercicio:          Ejercicio();        break;
                case Estado.trabajar:           Trabajar();         break;
            }
            CheckStats();

            sliderHigiene.size = (float)higiene / 100;
            sliderBaño.size = (float)baño / 100;
            sliderDiversion.size = (float)diversión / 100;
            sliderHambre.size = (float)hambre / 100;
            sliderSueño.size = (float)sueño / 100;

            textoDinero.text = "" + dinero;
        }
    }
    /// <summary>
    /// Comprueba sus estadísticas modificando el parámetros del player
    /// </summary>
    void CheckStats()
    {
        //Si el jugador tiene hambre o carece de diversion muere
        if (hambre <= 0 || diversión <= 0)
        {
            panelMuerte.SetActive(true);
            panelVida.SetActive(false);
            estado = Estado.muerto;
            accionControlada = true;
        }
        else if (baño <= 0)     //Si tiene qu ir al bañor lo hará en el mismo lugar
        {
            baño = 100;
            higiene -= 30;
            Instantiate(pis, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity);
        }
        else if (higiene <= 0 || sueño <= 0)  //Si carece de higiene o tiene mucho sueño su resta será mayor
            restaConstante = 0.1;
        else
            restaConstante = 0.01;
    }
    /// <summary>
    /// estado idle
    /// </summary>
    void Idle()
    {
        Debug.Log("Idle");
        animator.SetInteger("estado", 0);
    }
    /// <summary>
    /// estado andar
    /// </summary>
    void Andar()
    {
        Debug.Log("Andar");
        if(sueño > 0)
            sueño -= restaSueño / 3;
        //ANimacion Andar
        animator.SetInteger("estado", 1);
    }
    /// <summary>
    /// estado lavar
    /// </summary>
    void Lavar()
    {
        Debug.Log("Lavar");
        if (higiene < 100)
            higiene += aumentoHigiene;
        //Animacion lavar
        animator.SetInteger("estado", 4);
    }
    /// <summary>
    /// estado de ver la tele
    /// </summary>
    void VerTele()
    {
        Debug.Log("Ver la Tele");
        if (diversión < 100)
            diversión += aumentoDiversion;
        if (hambre > 0)
            hambre -= restaHambre;
        //Animacion ver tele
        animator.SetInteger("estado", 5);
    }
    /// <summary>
    /// estado de comer
    /// </summary>
    void Comer()
    {
        Debug.Log("Comer");
        if (hambre < 100)
            hambre += aumentoHambre;
        if (sueño > 0)
            sueño -= restaSueño;
        if (baño > 0)
            baño -= restaBaño;
        //Animacion comer
        animator.SetInteger("estado", 2);
    }

    void JugarOrdenador()
    {
        Debug.Log("Jugar Ordenador");
        Debug.Log(aumentoDiversion);
        if (diversión < 100)
            diversión += aumentoDiversion;
        if (hambre > 0)
            hambre -= restaHambre;
        //Animacion Ordenador
        animator.SetInteger("estado", 8);

    }
    void UsarBaño()
    {
        Debug.Log("Usar Baño");
        if (baño < 100)
            baño += aumentoBaño;
        //Animacion Baño
        animator.SetInteger("estado", 6);
    }
    void Dormir()
    {
        Debug.Log("Dormir");
        if (sueño < 100)
            sueño += aumentoSueño;
        if (hambre > 0)
            hambre -= restaHambre;
        animator.SetInteger("estado", 7);

    }
    void Ejercicio()
    {
        Debug.Log("Ejercicio");
        if (diversión < 100)
            diversión += aumentoDiversion;
        if (sueño > 0)
            sueño -= restaSueño * 4;
        if (hambre > 0)
            hambre -= restaHambre * 4;
        if (higiene > 0)
            higiene -= restaHigiene * 2;
        //Animacion Ejericio
        animator.SetInteger("estado", 3);

    }
    void Trabajar()
    {
        Debug.Log("Trabajar");
        if (diversión > 0)
            diversión -= restaDiversión * 4;
        if (sueño > 0)
            sueño -= restaSueño * 3;
        //Animacion Ordenador
        animator.SetInteger("estado", 8);

    }
    /// <summary>
    /// Resta las constantes al sim 
    /// </summary>
    void QuitarConstantes()
    {
        if (higiene > 0)
            higiene -= restaConstante;
        if (hambre > 0)
            hambre -= restaConstante;
        if (sueño > 0)
            sueño -= restaConstante;
        if (diversión > 0)
            diversión -= restaConstante;
        if (baño > 0)
            baño -= restaConstante;
    }
}
