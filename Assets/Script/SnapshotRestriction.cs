using UnityEngine;
using FMODUnity;

public class SnapshotRestriction : MonoBehaviour
{
    public Collider targetCollider; // ���������, � ������� ���������� ���������� ������������ ������ FMOD
    public EventReference snapshotToActivate; // ������ �� ������ FMOD, ������� ����� ������������

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