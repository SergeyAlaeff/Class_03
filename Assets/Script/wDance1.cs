using UnityEngine;
using Invector.vCharacterController.AI;

public class wDance1 : MonoBehaviour
{
    public Animator aiAnimator; // ������ �� Animator AI
    public string playerTag = "Player"; // ��� ������
    public string animationParameterName = "wDance"; // ��� ��������� ��������, ������� ����� ��������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // ���� ������, �������� � �������, ����� ��� "Player",
            // ���������� �������� animationParameterName � true
            aiAnimator.SetBool(animationParameterName, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // ����� ����� �������� �������, ����� �������� �������� �������,
            // ���� ��� �������������� ������� ����
            aiAnimator.SetBool(animationParameterName, false);
        }
    }
} 