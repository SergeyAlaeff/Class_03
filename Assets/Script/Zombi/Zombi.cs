using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    public EventReference idleEvent;
    public EventReference attackEvent;

    FMOD.Studio.EventInstance idleInstance;
    FMOD.Studio.EventInstance attackInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void idle()
    {
        FMODUnity.RuntimeManager.PlayOneShot(idleEvent, gameObject.transform.position);
       
    }
    void attack()
    {
        FMODUnity.RuntimeManager.PlayOneShot(attackEvent, gameObject.transform.position);
    }
}
