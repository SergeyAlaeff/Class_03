using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using Invector.vCharacterController;
using FMODUnity;


public class FmodFootstep : MonoBehaviour
{
    public EventReference runEvent;
    public EventReference walkEvent;
    public EventReference jumpEvent;
    public EventReference rollEvent;
    public EventReference landEvent;
    public EventReference idleEvent;
    public EventReference crouchEvent;
    
    private vThirdPersonController tpController;
    private vThirdPersonInput tpInput;
    private EventInstance runInstance;
    private EventInstance walkInstance;
    private EventInstance jumpInstance;
    private EventInstance rollInstance;
    private EventInstance landInstance;
    private EventInstance idleInstance;
    private EventInstance crouchInstance;

    
    // Start is called before the first frame update
    void Start()
    {
        tpController = GetComponent<vThirdPersonController>();
        tpInput = GetComponent<vThirdPersonInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void footstepPlayer()
    {
        
            if (tpInput.cc.inputMagnitude > 0.1f)
            {
                if (tpController.isSprinting)
                {
                    runInstance = RuntimeManager.CreateInstance(runEvent);
                    RuntimeManager.AttachInstanceToGameObject(runInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
                    runInstance.start();
                    
                }
                else
                {
                    walkInstance = RuntimeManager.CreateInstance(walkEvent);
                    RuntimeManager.AttachInstanceToGameObject(walkInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
                    walkInstance.start();
                   
                }
            walkInstance.release();
            runInstance.release();
        }  
        
    }

    void footstepPlayerJump()
        {
        jumpInstance = RuntimeManager.CreateInstance(jumpEvent);
        RuntimeManager.AttachInstanceToGameObject(jumpInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
        jumpInstance.start();
        jumpInstance.release();
         }
    void footstepPlayerRoll()
        {
        rollInstance = RuntimeManager.CreateInstance(rollEvent);
        RuntimeManager.AttachInstanceToGameObject(rollInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
        rollInstance.start();
        rollInstance.release();
        }
   
}