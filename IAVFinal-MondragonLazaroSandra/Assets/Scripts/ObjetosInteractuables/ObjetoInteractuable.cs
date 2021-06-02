using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ObjetoInteractuable : MonoBehaviour
{
    [SerializeField]
    protected Button boton;                 //Botón para que el jugador interactua
    [SerializeField]
    protected Text textoBoton;              //Texto del botón
    [SerializeField]
    protected NavMeshAgent navMesh;         //NavMesh del agente que controla el jugador
    [SerializeField]
    protected Player player;                //Player


    protected bool activo = false;
    protected static bool algoUsandose = false;
    protected static bool algoEnCola = false;

    /// <summary>
    /// Método que se llama cuando se clicla al objeto.
    /// </summary>
    public virtual void Interactuar()
    {
        boton.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        boton.gameObject.SetActive(true);
        //Debug.Log(gameObject.name);
        player.accionControlada = true;
        if (algoUsandose)
            algoEnCola = true;
    }
    public void VeAlDestino()
    {
        navMesh.destination = transform.position;
        player.estado = Player.Estado.andar;
        boton.gameObject.SetActive(false);
        activo = true;
        navMesh.destination = transform.position;
    }

    protected void DejarInteractuar()
    {
        if (!algoEnCola)
        {
            player.accionControlada = false;
            player.estado = Player.Estado.idle;
            algoUsandose = false;        
        }
        activo = false;
        algoEnCola = false;
    }
    public bool AlgoUsandose()
    {
        return algoUsandose && player.accionControlada;
    }

    public void SetActivo(bool t)
    {
        activo = t;
    }
}
