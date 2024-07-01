using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Invector.vCharacterController.AI;
using Invector.vCharacterController;


public class ManagerMusic : MonoBehaviour
{
    public EventReference MusicEvent;
    public float? IntensityParameterValue = null;
    FMOD.Studio.EventInstance MusicInstance;
    public vControlAIMelee Enemy;
    public bool Combat = false;
    public bool EnemyDead = false;
    

    private vThirdPersonController tpController;
    void Start()
    {
        tpController = GetComponent<vThirdPersonController>();
        MusicInstance = FMODUnity.RuntimeManager.CreateInstance(MusicEvent);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Если враг мертв, устанавливаем интенсивность на 60, в противном случае на 20
            float intensity = (EnemyDead == true) ? 60f : 20f;
            MusicInstance.setParameterByName("Intensity", intensity);
            MusicInstance.start();

            // Если нужно обновить IntensityParameterValue в зависимости от состояния
            IntensityParameterValue = intensity;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
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
                
                MusicInstance.setParameterByName("Intensity", 100f);
                IntensityParameterValue = 60f;
                Enemy.isDead = false;
                EnemyDead = true;
                
            }
        }
        else if (tpController != null)
        {
            if (tpController.isDead)
            {
                MusicInstance.setParameterByName("Intensity", 0f);
                IntensityParameterValue = 0f;
                
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