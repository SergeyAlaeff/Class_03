using UnityEngine;
using Invector.vCharacterController.AI;

public class wDance : MonoBehaviour
{
    public Animator aiAnimator; // Ссылка на Animator AI
    public string playerTag = "Player"; // Тэг игрока

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            aiAnimator.SetBool("wDance", true);

            // Добавьте эту строку, чтобы заставить персонажа стоять на месте после смены анимации
            aiAnimator.SetFloat("MovementSpeed", 0f); // Предполагая, что "MovementSpeed" - это параметр, управляющий движением
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            aiAnimator.SetBool("wDance", false);

            // Добавьте эту строку, чтобы остановить персонажа от движения, когда игрок покидает триггер
            aiAnimator.SetFloat("MovementSpeed", 0f); // Предполагая, что "MovementSpeed" - это параметр, управляющий движением
        }
    }
}