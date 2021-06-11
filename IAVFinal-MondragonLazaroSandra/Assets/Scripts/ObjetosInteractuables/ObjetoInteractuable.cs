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
    [SerializeField]
    protected Vista vistaPlayer;            //Player
    [SerializeField]
    protected Button boton2;                //Segundo Botón para que el jugador interactua


    [SerializeField] protected bool activo = false;     //Si el objeto se encuentra activo o no(se encuentra activo cuando va a ser usado)
    protected static bool algoUsandose = false;         //Si existe algún interactuable en la escena siendo usado
    protected static bool algoEnCola = false;           //Si existe una acción que esté en cola o haya sido interrumpida

    /// <summary>
    /// Método que se llama cuando se clicla al objeto.
    /// </summary>
    public virtual void Interactuar()
    {
        boton.onClick.RemoveAllListeners();
        boton.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        boton.gameObject.SetActive(true);
        if (algoUsandose)
            algoEnCola = true;
    }
    /// <summary>
    /// Modifica el objeto interactuable para que la IA lo use
    /// </summary>
    public virtual void ModificarObjetoIA()
    {
        //Cada interactuable lo modifica.
    }
    /// <summary>
    /// Manda al agente a una zona para que interactue
    /// </summary>
    public void VeAlDestino()
    {
        ModificarObjetoIA();
        activo = true;
        player.accionControlada = true;

        navMesh.destination = transform.position;
        player.estado = Player.Estado.andar;

        boton.gameObject.SetActive(false);
        boton2.gameObject.SetActive(false);
    }
    /// <summary>
    /// El agente deja de interactuar con el objeto
    /// </summary>
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
    /// <summary>
    /// Cuando el agente sale del trigger dejamos de ponerlo en uso
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        algoUsandose = false;
    }
    /// <summary>
    /// Si algun objeto está siendo usado por el jugador
    /// </summary>
    /// <returns></returns>
    public bool AlgoUsandose()
    {
        return algoUsandose && player.accionControlada;
    }
    /// <summary>
    /// pone el objeto activo en funcion de su parámetro
    /// </summary>
    /// <param name="t"></param>
    public void SetActivo(bool t)
    {
        activo = t;
    }
}
