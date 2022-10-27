using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmarCuestionario : MonoBehaviour
{

    public Text componenteTextTitulo;
    public Image componenteImagePregunta;
    public Text componenteTextPregunta;
    int preguntaActual = 0;
    public Button BotonAnterior;
    public Button BotonSiguiente;
    public Text Puntaje;
    public int Puntos = 0;
    public Button Verdadero;
    public Button Falso;
    public GameObject cruz;


    Cuestionario cuestionarioACargar;


    
    private void Awake()
    {
        object archivoJSON = Resources.Load("Cuestionario");
        string archivoEnFormatoTexto = archivoJSON.ToString();
        cuestionarioACargar = JsonUtility.FromJson<Cuestionario>(archivoEnFormatoTexto);
    }
    void Start()
    {
        componenteTextTitulo.text = cuestionarioACargar.titulo;
        MostrarPregunta(0);
        ActualizarPuntaje();
    }
   void MostrarPregunta(int pregunta)
    {
        if (preguntaActual == 0)
        {
            BotonAnterior.interactable = false;
        }
        else
        {
            BotonAnterior.interactable = true;
        }
        if (cuestionarioACargar.preguntas[preguntaActual].preguntaRespondida == true)
        {
            Verdadero.interactable = false;
            Falso.interactable = false;
        }
        else
        {
            Verdadero.interactable = true;
            Falso.interactable = true;
        }
        if(preguntaActual == cuestionarioACargar.preguntas.Length - 1)
        {
            BotonSiguiente.interactable = false;
        }
        else
        {
            BotonSiguiente.interactable = true;
        }

        componenteImagePregunta.sprite = Resources.Load<Sprite>("Images/" + cuestionarioACargar.preguntas[pregunta].imagen);
        componenteTextPregunta.text = cuestionarioACargar.preguntas[pregunta].texto;
    }
    public void SiguientePregunta()
    {
        preguntaActual++;
        MostrarPregunta(preguntaActual);
        cruz.SetActive(false);


    }
    public void PreguntaAnterior()
    {
        preguntaActual--;
        MostrarPregunta(preguntaActual);
        cruz.SetActive(false);

    }

    public void ClickVerdadero()
    {
        cuestionarioACargar.preguntas[preguntaActual].preguntaRespondida = true;

        if (cuestionarioACargar.preguntas[preguntaActual].respuesta == true)
        {

            Debug.Log("Acierto");
            Puntos++;
            ActualizarPuntaje();
        }
        else
        {
            Debug.Log("Fallo");
            cruz.SetActive(true);
        }
        Verdadero.interactable = false;
        Falso.interactable = false;
    }
    public void ClickFalso()
    {
        cuestionarioACargar.preguntas[preguntaActual].preguntaRespondida = true;
        if (cuestionarioACargar.preguntas[preguntaActual].respuesta == false)
        {
            Debug.Log("Acierto");
            Puntos++;
            ActualizarPuntaje();
        }
        else
        {
            Debug.Log("Fallo");
            cruz.SetActive(true);
        }
        Verdadero.interactable = false;
        Falso.interactable = false;
    }

    public void ActualizarPuntaje()
    {
        Puntaje.text = Puntos + "/" + cuestionarioACargar.preguntas.Length;
    }

}
