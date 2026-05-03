using UnityEngine;
using TMPro;

public class Corredor : MonoBehaviour
{
    [SerializeField] TextMeshPro textopasos;
    [SerializeField] Transform[] objetivos;
    [SerializeField] Vector3 posicionSalida;

    private float distance;
    private bool puedoCorrer = false;
    private ControladorPosta controladorposta;
    private int pasosTotales;
    private int indiceObjetivoActual = 0;

    public void Configurar(ControladorPosta parametro)
    {
        controladorposta = parametro;
    }

    public void IniciarCarrera()
    {
        puedoCorrer = true;
    }

    public void IrAPosicionInicial()
    {
        transform.position = posicionSalida;
        indiceObjetivoActual = 0;
        pasosTotales = 0;
        textopasos.text = "0";
        puedoCorrer = false;
    }

    void Update()
    {
        if (puedoCorrer)
        {
            Transform targetActual = objetivos[indiceObjetivoActual];
            float step = controladorposta.VelocidadActual * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetActual.position, step);
            distance = Vector3.Distance(transform.position, targetActual.position);

            pasosTotales++;
            textopasos.text = pasosTotales.ToString();

            if (distance < 0.1f)
            {
                puedoCorrer = false;
                indiceObjetivoActual++;

                if (indiceObjetivoActual >= objetivos.Length)
                {
                    indiceObjetivoActual = 0;
                    controladorposta.CorredorLlego();
                }
                else
                {
                    controladorposta.PasarBandera();
                }
            }
        }
    }
}