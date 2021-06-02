using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoIntMultiple : ObjetoInteractuable
{
    [SerializeField]
    protected Button boton2;             //Segundo Botón para que el jugador interactua
    [SerializeField]
    protected Text textoBoton2;          //Texto del segundo botón

    public int accion;
    public override void Interactuar()
    {
        base.Interactuar();
        boton.onClick.AddListener(delegate { Accion1(); });
        boton.SendMessage("Accion1", SendMessageOptions.DontRequireReceiver);

        boton2.gameObject.SetActive(true);
        boton2.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y - 80, 0);
        boton2.onClick.AddListener(delegate { Accion2(); });
        boton2.SendMessage("Accion2", SendMessageOptions.DontRequireReceiver);
    }
    void Accion1()
    {
        accion = 1;
        boton2.gameObject.SetActive(false);
        VeAlDestino();
    }
    void Accion2()
    {
        accion = 2;
        boton2.gameObject.SetActive(false);
        VeAlDestino();
    }
}
