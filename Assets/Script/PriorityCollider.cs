using UnityEngine;
using FMODUnity;

public class SnapshotRestriction : MonoBehaviour
{
    public Collider targetCollider; // ���������, � ������� ���������� ���������� ������������ ������ FMOD
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
            // ����� ����� �������� ������, ������� �� �������� ����������� ������ FMOD
            // ��������, ����� ��������� ����������� ������ ����������� ������
            // ��� ������� �� ����, ��� �� ���������� �������� FMOD � ����� �������
        }
    }
}