using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoIntMultiple : ObjetoInteractuable
{
    [SerializeField]
    protected Text textoBoton2;          //Texto del segundo botón

    public int accion;
    /// <summary>
    /// Modifica el texto de los botones y sus respectivos callbacks asociacidos a los métodos accion1 y accion2
    /// </summary>
    public override void Interactuar()
    {
        base.Interactuar();
        boton.onClick.AddListener(delegate { Accion1(); });
        boton.SendMessage("Accion1", SendMessageOptions.DontRequireReceiver);

        boton2.onClick.RemoveAllListeners();
        boton2.gameObject.SetActive(true);
        boton2.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y - 80, 0);
        boton2.onClick.AddListener(delegate { Accion2(); });
        boton2.SendMessage("Accion2", SendMessageOptions.DontRequireReceiver);
    }
    /// <summary>
    /// Callback para el primer botón. Manda al agente a un destino y desactiva el botón
    /// </summary>
    void Accion1()
    {
        accion = 1;
        boton2.gameObject.SetActive(false);
        VeAlDestino();
    }
    /// <summary>
    /// Callback para el segundo botón. Manda al agente a un destino y desactiva el botón
    /// </summary
    void Accion2()
    {
        accion = 2;
        boton2.gameObject.SetActive(false);
        VeAlDestino();
    }
}
