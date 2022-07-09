using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron : MonoBehaviour
{
    int lugar_a_ir;
    int nuevo_lugar;

    [SerializeField] Transform m_1;
    [SerializeField] Transform m_2;
    [SerializeField] Transform m_3;
    [SerializeField] float velocity;
    [SerializeField] GameObject misil;
    // Start is called before the first frame update
    void Start()
    {
        ElegirObjetivo(lugar_a_ir); // Por si misma, esta función no hace nada, ya que sólo regresa un número.
        CompararObjetivo();
    }

    // Update is called once per frame
    void Update()
    {
        ComprobarObjetivo();
    }


    // Esta función está definida para regresar un número entero, el return al final es el encargado de definir el valor de regreso.
    int ElegirObjetivo(int lugar_previo) 
    {
      int nuevo_objetivo = Random.Range(1, 4);

      if(nuevo_objetivo == lugar_previo) {

        nuevo_objetivo = ElegirObjetivo(lugar_previo);

      }
      return nuevo_objetivo;
    }

    void CompararObjetivo()
    {
        nuevo_lugar = ElegirObjetivo(lugar_a_ir); // Al pasar la variable lugar a ir como parámetro, podemos
                                                  // hacer la comparación al elegir el objetivo
        lugar_a_ir = nuevo_lugar; // Esto está garantizado ser un lugar diferente al de inicio
        Debug.Log("Actual Objetivo [" + lugar_a_ir + "]");
    }

    void ComprobarObjetivo()
    {
        switch (lugar_a_ir)
        {

            case 1:

                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, m_1.position, velocity * Time.deltaTime);
                gameObject.transform.LookAt(m_1.position);
                
                break;

            case 2:

                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, m_2.position, velocity * Time.deltaTime);
                gameObject.transform.LookAt(m_2.position);

                break;

            case 3:

                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, m_3.position, velocity * Time.deltaTime);
                gameObject.transform.LookAt(m_3.position);
                
                break;
        }
    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag == "Objetive")
        {
            ElegirObjetivo(lugar_a_ir);
            CompararObjetivo();
        }

        else if(other.transform.tag == "Player")
        {
            Quaternion rotation = new Quaternion();
            Instantiate(misil, gameObject.transform.position, rotation);
        }
    }
}
