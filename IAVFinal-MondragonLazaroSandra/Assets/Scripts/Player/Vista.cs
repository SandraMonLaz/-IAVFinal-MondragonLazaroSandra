using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Vista del agente según lo que ve en el escenario
/// </summary>
public class Vista : MonoBehaviour
{
    ObjetoInteractuable baño;
    ObjetoInteractuable higiene;
    DispensadorComida hambre;
    ObjetoInteractuable diversion;
    ObjetoInteractuable sueño;
    Ordenador ordenador;

    /// <summary>
    /// Se coge de forma aleatoria un ojeto de cada tipo
    /// </summary>
    void Start()
    {
        baño = GameObject.FindGameObjectWithTag("Baño").GetComponent<ObjetoInteractuable>();
        higiene = GameObject.FindGameObjectWithTag("Higiene").GetComponent<ObjetoInteractuable>();
        hambre = GameObject.FindGameObjectWithTag("Hambre").GetComponent<DispensadorComida>();
        diversion = GameObject.FindGameObjectWithTag("Diversion").GetComponent<ObjetoInteractuable>();
        sueño = GameObject.FindGameObjectWithTag("Sueño").GetComponent<ObjetoInteractuable>();
        ordenador = GameObject.FindGameObjectWithTag("Ordenador").GetComponent<Ordenador>();
    }
   //Setter y getters
    public void setBaño(ObjetoInteractuable b) { baño = b; }
    public ObjetoInteractuable getBaño() { return baño; }
    public void setHigiene(ObjetoInteractuable b) { higiene = b; }
    public ObjetoInteractuable getHigiene() { return higiene; }
    public void setHambre(DispensadorComida b) { hambre = b; }
    public ObjetoInteractuable getHambre() { return hambre; }
    public float getPrecioHambre() { return hambre.gasto; }
    public void setDiversion(ObjetoInteractuable b) { diversion = b; }
    public ObjetoInteractuable getDiversion() { return diversion; }
    public void setSueño(ObjetoInteractuable b) { sueño = b; }
    public ObjetoInteractuable getSueño() { return sueño; }
    public void setOrdenador(Ordenador b) { ordenador = b; }
    public Ordenador getOrdenador() { return ordenador; }

}
