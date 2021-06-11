using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoHigiene : ObjetoInteractuable
{
    [SerializeField] double aumentoHigiene = 2;         //aumento de la constante vital de higiene por tick
    [SerializeField] float tiempo = 5;                  //tiempo que realiza la accion
    [SerializeField] string texto = "Lavarse manos";    //texto que aparece en el boton

    /// <summary>
    /// Modifica el texto del boton y su callback
    /// </summary>
    public override void Interactuar()
    {
        base.Interactuar();
        textoBoton.text = texto;

        boton.onClick.AddListener(delegate { VeAlDestino(); });
        boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
    }
    /// <summary>
    /// En caso de poder usarse va a lavarse
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && activo && !algoUsandose)
        {
            player.estado = Player.Estado.lavar;
            player.aumentoHigiene = aumentoHigiene;
            algoUsandose = true;

            Invoke("DejarInteractuar", tiempo);
        }
    }
    /// <summary>
    /// Informa a la IA del objeto clicado
    /// </summary>
    public override void ModificarObjetoIA()
    {
        vistaPlayer.setHigiene(this);
    }
}
