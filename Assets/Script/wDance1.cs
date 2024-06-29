using UnityEngine;
using Invector.vCharacterController.AI;


public class wDance1 : MonoBehaviour
{
    public Animator aiAnimator; // Ссылка на Animator AI
    public string playerTag = "Player"; // Тэг игрока

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Если объект, вошедший в триггер, имеет тег "Player",
            // установить параметр wDance в true
            aiAnimator.SetBool("wDance", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Когда игрок покидает триггер, можно сбросить параметр обратно,
            // если это предполагается логикой игры
            aiAnimator.SetBool("wDance", false);
        }
    }
}