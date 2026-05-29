using System.Collections.Generic;
using UnityEngine;

public class ControladorPosta : MonoBehaviour
{
    [SerializeField] int cantidadVueltas = 2;
    public Corredor[] corredores;
    public ControladorUI controladorUI;

    private float velocidadActual = 1f;
    private int vueltasDadas = 0;
    private int indiceCorredorActual = 0;

    public float VelocidadActual => velocidadActual;

    void Start()
    {
        foreach (Corredor c in corredores)
        {
            c.Configurar(this);
        }
    }

    public void ActualizarVelocidad(float nuevaVel)
    {
        velocidadActual = nuevaVel;
    }

    public void BotonCorrer()
    {
        corredores[indiceCorredorActual].IniciarCarrera();
    }

    public void BotonPosicionarse()
    {
        vueltasDadas = 0;
        indiceCorredorActual = 0;
        foreach (Corredor c in corredores)
        {
            c.IrAPosicionInicial();
        }
        controladorUI.OcultarFinalizacion();
    }

    public void CorredorLlego()
    {
        indiceCorredorActual++;
        if (indiceCorredorActual >= corredores.Length)
        {
            indiceCorredorActual = 0;
            vueltasDadas++;
            if (vueltasDadas >= cantidadVueltas)
            {
                controladorUI.MostrarFinalizacion();
                return;
            }
        }
        corredores[indiceCorredorActual].IniciarCarrera();
    }
    public void PasarBandera()
    {
        indiceCorredorActual++;
        if (indiceCorredorActual >= corredores.Length)
        {
            indiceCorredorActual = 0;
        }
        corredores[indiceCorredorActual].IniciarCarrera();
    }
}
