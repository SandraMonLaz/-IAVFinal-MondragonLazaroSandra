﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Estado { idle, andar, lavar, verTele, comer, jugarOrdenador, baño, dormir, ejercicio, trabajar };
    public Estado estado = Estado.idle;
    //Tiempo que tiene que pasar en cada tick
    public float tiempoTick {get; set;}
    //Tiempo actual transcurrido
    float tiempoActual;
    float tiempoTotal;
    //Dinero del sim
    public int dinero {get; set;}

    //Atributos del sim
    [SerializeField] double higiene     = 60;
    [SerializeField] double hambre      = 60;
    [SerializeField] double sueño       = 100;
    [SerializeField] double diversión   = 80;
    [SerializeField] double baño        = 80;

    //Resta continua
    [SerializeField] double restaConstante = 0.01;
    [SerializeField] double restaHambre = 0.05;
    [SerializeField] double restaSueño = 0.05;
    [SerializeField] double restaHigiene = 0.07;
    [SerializeField] double restaDiversión = 0.1;
    [SerializeField] double restaBaño = 0.9;

    public double aumentoHambre { get; set; }
    public double aumentoSueño { get; set; }
    public double aumentoHigiene { get; set; }
    public double aumentoDiversion { get; set; }
    public double aumentoBaño { get; set; }

    void Start()
    {
        dinero = 100;
        tiempoActual = Time.time;
        tiempoTotal = Time.time;
        tiempoTick = 0.2f;
    }
    // Update is called once per frame
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

            if(hambre <= 0 || diversión <= 0)
            {
                //FIN DE PARTIDA SIM MUERE
            }
            else if(sueño <= 0)
            {
                estado = Estado.dormir;
            }
            else if(baño <= 0)
            {
                baño = 100;
                //Hacer que se mee
            }
            else if(higiene <= 0)
            {
                restaConstante = 0.05;
            }
            else
            {
                restaConstante = 0.01;
            }
        }
    }
    void Idle()
    {
        Debug.Log("Idle");
        //Animacion idle
    }
    void Andar()
    {
        Debug.Log("Andar");
        if(sueño > 0)
            sueño -= restaSueño / 3;
        //ANimacion Andar
    }
    void Lavar()
    {
        Debug.Log("Lavar");
        if (higiene < 100)
            higiene += aumentoHigiene;
        //Animacion lavar
    }

    void VerTele()
    {
        Debug.Log("Ver la Tele");
        if (diversión < 100)
            diversión += aumentoDiversion;
        if (hambre > 0)
            hambre -= restaHambre;
        //Animacion ver tele
    }
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
    }

    void JugarOrdenador()
    {
        Debug.Log("Jugar Ordenador");
        if (diversión < 100)
            diversión += aumentoDiversion;
        if (hambre > 0)
            hambre -= restaHambre;
        //Animacion Ordenador
    }
    void UsarBaño()
    {
        Debug.Log("Usar Baño");
        if (baño < 100)
            baño += aumentoBaño;
        //Animacion Baño
    }
    void Dormir()
    {
        Debug.Log("Dormir");
        if (sueño < 100)
            sueño += aumentoSueño;
        if (hambre > 0)
            hambre -= restaHambre;
        //Animacion Dormir
    }
    void Ejercicio()
    {
        Debug.Log("Ejercicio");
        if (diversión < 100)
            diversión += aumentoDiversion;
        if (sueño > 0)
            sueño -= restaSueño * 2;
        if (hambre > 0)
            hambre -= restaHambre;
        if (higiene > 0)
            higiene -= restaHigiene;
        //Animacion Ejericio
    }
    void Trabajar()
    {
        Debug.Log("Ejercicio");
        if (diversión > 0)
            diversión -= restaDiversión;
        if (sueño > 0)
            sueño -= restaSueño * 2;
        //Animacion Ordenador
    }
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
