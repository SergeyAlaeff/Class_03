using UnityEngine;

public class PlayAnimationOnStart : MonoBehaviour
{
    public Animator animator; // Ссылка на компонент Animator у персонажа
     string Dance01Dance01; // Название анимации, которую нужно проиграть

    void Start()
    {
        if (animator != null)
        {
            animator.Play(Dance01Dance01); // Запуск анимации по её названию
        }
        else
        {
            Debug.LogError("Animator component is missing!");
        }
    }
}