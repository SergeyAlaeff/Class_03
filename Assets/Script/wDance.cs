using UnityEngine;
using Invector.vCharacterController.AI;

public class wDance : MonoBehaviour
{
    public Animator aiAnimator; // ������ �� Animator AI
    public string playerTag = "Player"; // ��� ������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            aiAnimator.SetBool("wDance", true);

            // �������� ��� ������, ����� ��������� ��������� ������ �� ����� ����� ����� ��������
            aiAnimator.SetFloat("MovementSpeed", 0f); // �����������, ��� "MovementSpeed" - ��� ��������, ����������� ���������
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            aiAnimator.SetBool("wDance", false);

            // �������� ��� ������, ����� ���������� ��������� �� ��������, ����� ����� �������� �������
            aiAnimator.SetFloat("MovementSpeed", 0f); // �����������, ��� "MovementSpeed" - ��� ��������, ����������� ���������
        }
    }
}