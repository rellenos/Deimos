using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public GameObject particlesCircle, particlesSplash;
    public AudioSource monolith;
    public Animator ani;

    private GameMaster gm;

    void Start()
    {
        ani = GetComponent<Animator>();
        ani.SetBool("activated", false);
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("checkpoint");
            gm.lastCheckpointPos = transform.position;
            ani.SetBool("activated", true);
            monolith.Play();
            particlesCircle.SetActive(true);
            particlesSplash.SetActive(true);
        }            
    }
}
