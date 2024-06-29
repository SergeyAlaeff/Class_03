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


    public LayerMask lm;
    float Material;
    EventInstance runInstance;
    EventInstance walkInstance;
    EventInstance jumpInstance;
    EventInstance rollInstance;
    EventInstance landInstance;
    EventInstance idleInstance;
    EventInstance crouchInstance;
    // Start is called before the first frame update
    void Start()
    {
        tpController = GetComponent<vThirdPersonController>();
        tpInput = GetComponent<vThirdPersonInput>();
        runInstance = RuntimeManager.CreateInstance(runEvent);
        walkInstance = RuntimeManager.CreateInstance(walkEvent);
        jumpInstance = RuntimeManager.CreateInstance(jumpEvent);
        rollInstance = RuntimeManager.CreateInstance(rollEvent);
        landInstance = RuntimeManager.CreateInstance(landEvent);
        idleInstance = RuntimeManager.CreateInstance(idleEvent);
        crouchInstance = RuntimeManager.CreateInstance(crouchEvent);

    }

    // Update is called once per frame
    void Update()
    {

    }
   


    void footstepPlayer()
    {
        

        if (tpInput.cc.inputMagnitude > 0.1f)
        {
            MaterialCheck();
            if (tpController.isJumping == false)
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
            }
            runInstance.release();
            walkInstance.release();
        }

    }

    void footstepPlayerJump()
    {
        MaterialCheck();
        jumpInstance = RuntimeManager.CreateInstance(jumpEvent);
        RuntimeManager.AttachInstanceToGameObject(jumpInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
        jumpInstance.start();
        jumpInstance.release();
    }
    void footstepPlayerRoll()
    {
        MaterialCheck();
        rollInstance = RuntimeManager.CreateInstance(rollEvent);
        RuntimeManager.AttachInstanceToGameObject(rollInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
        rollInstance.start();
        rollInstance.release();
    }
    void footstepPlayerLand()
    {
        MaterialCheck();
        landInstance = RuntimeManager.CreateInstance(landEvent);
        RuntimeManager.AttachInstanceToGameObject(landInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
        landInstance.start();
        landInstance.release();
    }
    void footstepPlayerIdle()
    {
        MaterialCheck();
        idleInstance = RuntimeManager.CreateInstance(idleEvent);
        RuntimeManager.AttachInstanceToGameObject(idleInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
        idleInstance.start();
        idleInstance.release();
    }
    void footstepPlayerCrouch()
    {
        crouchInstance = RuntimeManager.CreateInstance(crouchEvent);
        RuntimeManager.AttachInstanceToGameObject(crouchInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
        crouchInstance.start();
        crouchInstance.release();
    }
    void MaterialCheck()
    {

        if (Physics.Raycast(gameObject.transform.position, Vector3.down, out RaycastHit hit, 1f, lm))
        {
            Debug.Log(hit.collider.tag);

            switch (hit.collider.tag)
            {
                case "Concrete":
                    Material = 0f;
                    break;
                case "Wood":
                    Material = 1f;
                    break;
                case "Carpet":
                    Material = 2f;
                    break;
                case "ladder concerte":
                    Material = 3f;
                    break;
               
                default:
                    Material = 0f;
                    break;
            }

        }

    }

    void OnDestroy()
    {
        // Освобождаем ресурсы FMOD
        runInstance.release();
        walkInstance.release();
        jumpInstance.release();
        rollInstance.release();
        landInstance.release();
        idleInstance.release();
        crouchInstance.release();
    }
}

