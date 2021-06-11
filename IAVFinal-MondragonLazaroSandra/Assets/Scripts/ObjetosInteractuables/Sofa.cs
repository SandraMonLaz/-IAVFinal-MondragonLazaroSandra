using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : ObjetoInteractuable
{
    [SerializeField] Material[] materials;          //dos materiales para la tv(feedback)
    [SerializeField] Renderer tv;                   //renderer de la television
    [SerializeField] double aumentoDiversion;       //aumento de diversion por cada tick
    [SerializeField] float tiempo;                  //tiempo que dura la accion
    /// <summary>
    /// Modifica los textos y callback del boton
    /// </summary>
    public override void Interactuar()
    {
        base.Interactuar();
        textoBoton.text = "Ver la Tele";

        boton.onClick.AddListener(delegate { VeAlDestino(); });
        boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
    }
    /// <summary>
    /// En caso de poder realiza la accion de ver la tele cambiando el material de esta 
    /// para mayor feedback
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && activo && !algoUsandose)
        {
            player.estado = Player.Estado.verTele;
            player.aumentoDiversion = aumentoDiversion;
            tv.material = materials[1];
            algoUsandose = true;
            //Posicionamiento y rotacion
            player.transform.LookAt(tv.transform, Vector3.up);
            Invoke("DejarDeVer", tiempo);
        }
    }
    /// <summary>
    /// Deja de realizar la acción y "apaga" la tele
    /// </summary>
    void DejarDeVer()
    {
        base.DejarInteractuar();
        tv.material = materials[0];
    }
    /// <summary>
    /// Informa a la IA del objeto clicado
    /// </summary>
    public override void ModificarObjetoIA()
    {
        vistaPlayer.setDiversion(this);
    }
}
