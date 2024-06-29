using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController.AI;


public class FootstepFemale : MonoBehaviour
{
    
    public EventReference walkingEvent; // Сделаем переменную public

    FMOD.Studio.EventInstance walkingInstance;

    public LayerMask lm;
    float Material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   void footstepFemale()
    {
        MaterialCheck();
        walkingInstance = FMODUnity.RuntimeManager.CreateInstance(walkingEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(walkingInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
        walkingInstance.setParameterByName("MaterialCheck", Material);
        walkingInstance.start();
        walkingInstance.release();
    }
    void MaterialCheck()
    {
        RaycastHit rh;

        if (Physics.Raycast(gameObject.transform.position, Vector3.down, out rh, 0.3f, lm))
        {
            if (rh.collider != null)
            {
                Debug.Log("Raycast hit: " + rh.collider.tag);

                switch (rh.collider.tag)
                {
                    case "Concrуte":
                        Material = 0;
                        break;
                    case "Wood":
                        Material = 1;
                        break;
                    case "Carpet":
                        Material = 2;
                        break;

                    default:
                        Material = 0;
                        break;
                }
            }
        }
    }
}

