using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Invector.vCharacterController.AI;
using Invector.vCharacterController;


public class ManagerMusic : MonoBehaviour
{
    public EventReference MusicEvent;
    public float IntensityParameterValue = 20f;      
    FMOD.Studio.EventInstance MusicInstance;
    public vControlAIMelee Enemy;
    public bool Combat = false;
    public bool EnemyDead = false;

    private vThirdPersonController tpController;
    void Start()
    {
        tpController = GetComponent<vThirdPersonController>();
        MusicInstance = FMODUnity.RuntimeManager.CreateInstance(MusicEvent);
        MusicInstance.setParameterByName("Intensity", IntensityParameterValue);

    }

    private void OnTriggerEnter(Collider AMB_Sceleton_Music)
    {
        if (AMB_Sceleton_Music.CompareTag("Player"))
        {
            MusicInstance.setParameterByName("Intensity", 20f);
            MusicInstance.start();
           
        }
        else if (Enemy.isDead && AMB_Sceleton_Music.CompareTag("Player"))
        {
           MusicInstance.setParameterByName("Intensity", 60f);
            IntensityParameterValue = 100f;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            MusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }


    void Update()
    {
        if (Enemy != null)
        {
            if (Enemy.isInCombat && !Combat)
            {
                MusicInstance.setParameterByName("Intensity", 40f);
                Combat = true;
            }
            else if (!Enemy.isInCombat && Combat)
            {
                MusicInstance.setParameterByName("Intensity", 20f);
                Combat = false;
            }
            else if (Enemy.isDead)
            {
                Debug.Log("Enemy is dead. Setting Intensity to 100f and restarting music.");
                MusicInstance.setParameterByName("Intensity", 100f);
                IntensityParameterValue = 100f;
                Enemy.isDead = false;
                
            }
        }
        else if (tpController != null)
        {
            if (tpController.isDead)
            {
                MusicInstance.setParameterByName("Intensity", 0f);
                IntensityParameterValue = 0f;
                tpController.isDead = false;
            }
        }
        else
        {
            MusicInstance.setParameterByName("Intensity", 60f);
        }
    }
    private void OnDestroy()
    {
       MusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
       MusicInstance.release();
    }
}