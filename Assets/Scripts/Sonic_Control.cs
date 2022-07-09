using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonic_Control : MonoBehaviour
{
    float timer_jump;
    [SerializeField] GameObject sonic;
    [SerializeField] GameObject camara;
    [SerializeField] bool canjump;
    [SerializeField] float jump_force;
    [SerializeField] float velocity;
    public bool move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Controles

        if(move)
        {
            if(Input.GetKey("space") && canjump)
            {
                canjump = false;
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000 * jump_force * Time.deltaTime, 0));
                sonic.GetComponent<Animator>().SetBool("Jump", true);
                sonic.GetComponent<Animator>().SetBool("Run", false);
            }

            if(Input.GetKey("space"))
            {
                sonic.GetComponent<Animator>().SetBool("Jump", true);
                sonic.GetComponent<Animator>().SetBool("Run", false);
            }

            if(Input.GetKeyUp("space"))
            {

                sonic.GetComponent<Animator>().SetBool("Jump", false);
                sonic.GetComponent<Animator>().SetBool("Run", false);
            }

            if(Input.GetKey("w"))
            {
                sonic.GetComponent<Animator>().SetBool("Run", true);
                sonic.GetComponent<Animator>().SetBool("Jump", false);
                gameObject.transform.Translate(0, 0, 1f * Time.deltaTime * velocity);  
            }

            if(Input.GetKeyUp("w"))
            {
                sonic.GetComponent<Animator>().SetBool("Run", false);
                sonic.GetComponent<Animator>().SetBool("Jump", false);
            }

            
        }

            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                camara.transform.Translate(0, 0, -0.5f);
                velocity = 5;
            }

            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                camara.transform.Translate(0, 0, 0.5f);
                velocity = 2;
            } 
        

        #endregion

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Floor")
        {
            canjump = true;
        }

    }
}
