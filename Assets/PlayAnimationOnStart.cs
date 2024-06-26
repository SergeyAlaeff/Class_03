using UnityEngine;

public class PlayAnimationOnStart : MonoBehaviour
{
    public Animator animator; // ������ �� ��������� Animator � ���������
     string Dance01Dance01; // �������� ��������, ������� ����� ���������

    void Start()
    {
        if (animator != null)
        {
            animator.Play(Dance01Dance01); // ������ �������� �� � ��������
        }
        else
        {
            Debug.LogError("Animator component is missing!");
        }
    }
}