using UnityEngine;
using Invector.vCharacterController.AI;

public class wDance1 : MonoBehaviour
{
    public Animator aiAnimator; // Ссылка на Animator AI
    public string playerTag = "Player"; // Тэг игрока
    public string animationParameterName = "wDance"; // Имя параметра анимации, которое можно изменить

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Если объект, вошедший в триггер, имеет тег "Player",
            // установить параметр animationParameterName в true
            aiAnimator.SetBool(animationParameterName, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Когда игрок покидает триггер, можно сбросить параметр обратно,
            // если это предполагается логикой игры
            aiAnimator.SetBool(animationParameterName, false);
        }
    }
} 