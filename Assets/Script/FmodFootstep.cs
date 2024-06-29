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


    LayerMask lm;
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
    private void PlayFootstep(ref EventInstance instance)
    {
        PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        if (state != PLAYBACK_STATE.PLAYING)
        {
            RuntimeManager.AttachInstanceToGameObject(instance, transform, GetComponent<Rigidbody>());
            instance.start();
        }
    }


    void footstepPlayer()
    {

        if (tpInput.cc.inputMagnitude > 0.1f && tpController.isJumping == false)
        {
            if (tpController.isSprinting)
            {
                PlayFootstep(ref runInstance);
            }
            else
            {
                PlayFootstep(ref walkInstance);
            }

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
    void footstepPlayerLand()
    {
        landInstance = RuntimeManager.CreateInstance(landEvent);
        RuntimeManager.AttachInstanceToGameObject(landInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
        landInstance.start();
        landInstance.release();
    }
    void footstepPlayerIdle()
    {
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

    void MatterialCheck()
    {
        RaycastHit rh;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out rh, 0.3f, lm))
        {
            if (rh.transform.tag == "Contert") Material = 0;
            {

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