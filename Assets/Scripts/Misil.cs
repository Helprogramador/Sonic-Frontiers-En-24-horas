using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Misil : MonoBehaviour
{
    [SerializeField] GameObject jugador;
    [SerializeField] GameObject scene; 
    [SerializeField] float velocity;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        scene = GameObject.FindGameObjectWithTag("Respawn");
        gameObject.transform.SetParent(scene.transform);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 7.5f)
        {
            Destroy(gameObject);
        }
        
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, jugador.transform.position, velocity * Time.deltaTime);
        gameObject.transform.LookAt(new Vector3(transform.position.x, jugador.transform.position.y, jugador.transform.position.z));
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene");
        }

        else if(other.transform.tag == "Enemy")
        {
            Debug.Log("Spawneado");
        }
    }
}

