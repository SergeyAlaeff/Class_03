using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator; // Ссылка на Animator двери
    public string playerTag = "Player"; // Тэг игрока
    private bool hasOpened = false; // Флаг, показывающий, была ли дверь уже открыта

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) && !hasOpened)
        {
            // Если объект игрока входит в коллайдер двери и дверь еще не открыта,
            // устанавливаем параметр "DoorOpen" в true для открытия двери
            doorAnimator.SetBool("Door_Open", true);
            hasOpened = true; // Устанавливаем флаг, что дверь была открыта
        }
    }
}