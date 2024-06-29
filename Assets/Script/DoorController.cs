using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator; // Аниматор, связанный с дверью
    private bool isOpen = false; // Флаг для проверки, открыта ли дверь

    
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
        doorAnimator.SetTrigger("Open"); // Предполагается, что у вас есть триггер "Open" в аниматоре
        FMODUnity.RuntimeManager.PlayOneShot(doorOpen,  gameObject.transform.position);
    }
}
