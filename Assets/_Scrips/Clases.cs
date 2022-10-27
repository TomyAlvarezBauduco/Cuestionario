using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cuestionario
{
    public string titulo;
    public Pregunta[] preguntas = new Pregunta[5];
}

[System.Serializable]
public class Pregunta
{
   public string texto;
   public string imagen;
   public bool respuesta;
    public bool preguntaRespondida = false;
}

