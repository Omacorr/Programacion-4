using UnityEngine;

public class ControladorUI : MonoBehaviour
{
    public ControladorPosta scriptPosta;
    public GameObject panelFinalizacion;

    public void Slider(float valor)
    {
        scriptPosta.ActualizarVelocidad(valor);
    }

    public void ClickCorrer()
    {
        scriptPosta.BotonCorrer();
    }

    public void ClickPosicionar()
    {
        scriptPosta.BotonPosicionarse();
    }

    public void MostrarFinalizacion()
    {
        panelFinalizacion.SetActive(true);
    }

    public void OcultarFinalizacion()
    {
        panelFinalizacion.SetActive(false);
    }
}