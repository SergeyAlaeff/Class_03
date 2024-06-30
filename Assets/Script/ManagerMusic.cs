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

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            MusicInstance.setParameterByName("Intensity", 20f);
            MusicInstance.start();
            Debug.Log("MUZ VILLAGE");
        }
        else if (col.name.Equals("AMB_Zombi"))
        {
            MusicInstance.setParameterByName("Intensity", 60f);
            MusicInstance.start();
            Debug.Log("MUZ VILLAGE");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player") || col.name.Equals("AMB_Zombi"))
        {
            MusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }


    void Update()
    {
        if (Enemy != null) // Проверка на null, прежде чем обращаться к Enemy
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
                IntensityParameterValue = 100f; // Устанавливаем новое значение IntensityParameterValue
                Enemy.isDead = false;
            }
        }

        if (tpController != null) // Добавьте аналогичную проверку для tpController, если он может быть уничтожен
        {
            if (tpController.isDead)
            {
                MusicInstance.setParameterByName("Intensity", 0f);
                tpController.isDead = false;
            }
        }

        if (IntensityParameterValue == 100f)
        {
            MusicInstance.setParameterByName("Intensity", 20f);
            MusicInstance.start();
        }
    }

    void OnDestroy()
    {
        MusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}