using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator; // ��������, ��������� � ������
    private bool isOpen = false; // ���� ��� ��������, ������� �� �����

    
    public EventReference doorOpen;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            Debug.Log("Player entered the trigger");
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        isOpen = true;
        doorAnimator.SetTrigger("Open"); // ��������������, ��� � ��� ���� ������� "Open" � ���������
        FMODUnity.RuntimeManager.PlayOneShot(doorOpen,  gameObject.transform.position);
    }
}
