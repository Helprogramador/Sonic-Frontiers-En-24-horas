using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Railes : MonoBehaviour
{
    [SerializeField] GameObject sonic;
    [SerializeField] GameObject sonic2;
    [SerializeField] GameObject rail;
    [SerializeField] GameObject rail_final;
    [SerializeField] GameObject scene;
    [SerializeField] GameObject animador;
    [SerializeField] Sonic_Control sonic_script;
    bool isTouch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouch)
        {
            sonic.transform.position = rail.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Debug.Log("Tocando el rail 1");
            sonic.GetComponent<Rigidbody>().useGravity = false;
            sonic_script.move = false;
            sonic2.GetComponent<Animator>().SetBool("Jump", false);
            sonic2.GetComponent<Animator>().SetBool("Run", false);
            sonic.transform.SetParent(rail.transform);
            isTouch = true;
            animador.GetComponent<Animator>().SetBool("WithSonic", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Debug.Log("Saliendo de  el rail 1");
            sonic.GetComponent<Rigidbody>().useGravity = true;
            sonic_script.move = true;
            sonic2.GetComponent<Animator>().SetBool("Jump", false);
            sonic2.GetComponent<Animator>().SetBool("Run", false);
            sonic.transform.SetParent(scene.transform);
            isTouch = false;
            sonic.transform.position = rail_final.transform.position;
            animador.GetComponent<Animator>().SetBool("WithSonic", false);
        }
    }

}
