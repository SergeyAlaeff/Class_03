using UnityEngine;
using FMODUnity;

public class SnapshotRestriction : MonoBehaviour
{
    public Collider targetCollider; // Коллайдер, в котором необходимо ограничить переключение снимка FMOD
    public EventReference snapshotToActivate; // Ссылка на снимок FMOD, который нужно активировать

    private FMOD.Studio.EventInstance snapshotInstance;

    private void Start()
    {
        snapshotInstance = RuntimeManager.CreateInstance(snapshotToActivate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other == targetCollider)
        {
            snapshotInstance.start();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other == targetCollider)
        {
            snapshotInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}