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
    public float Material;
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
                    runInstance.setParameterByName("MaterialCheck", Material);
                    runInstance.start();
                }
                else
                {
                    walkInstance = RuntimeManager.CreateInstance(walkEvent);
                    RuntimeManager.AttachInstanceToGameObject(walkInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
                    walkInstance.setParameterByName("MaterialCheck", Material);
                    walkInstance.start();
                }
            }

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
    void footstepPlayerLandLow()
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
        RaycastHit rh;
        // Выполнение Raycast вниз от позиции текущего объекта
        if (Physics.Raycast(gameObject.transform.position, Vector3.down, out rh, 0.3f, lm))
        {
            Debug.Log(rh.collider.tag); // Вывод тега объекта, в который попал луч

            // Определение материала основываясь на теге объекта
            switch (rh.collider.tag)
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
                    Material = 0f; // Значение по умолчанию, если тег не совпадает
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
    void FootstepsAI()
    {
    }
}
