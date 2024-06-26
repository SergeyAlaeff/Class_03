using UnityEngine;
using FMODUnity;

public class SnapshotRestriction : MonoBehaviour
{
    public Collider targetCollider; // Коллайдер, в котором необходимо ограничить переключение снимка FMOD
    private bool inRestrictedCollider = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other == targetCollider)
        {
            inRestrictedCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == targetCollider)
        {
            inRestrictedCollider = false;
        }
    }

    private void Update()
    {
        if (inRestrictedCollider)
        {
            // Здесь можно добавить логику, которая не позволит переключить снимок FMOD
            // Например, можно отключить возможность игрока переключить снимок
            // Это зависит от того, как вы управляете снимками FMOD в вашем проекте
        }
    }
}