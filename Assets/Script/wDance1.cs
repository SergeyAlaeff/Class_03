using UnityEngine;
using Invector.vCharacterController.AI;


public class wDance1 : MonoBehaviour
{
    public Animator aiAnimator; // ������ �� Animator AI
    public string playerTag = "Player"; // ��� ������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // ���� ������, �������� � �������, ����� ��� "Player",
            // ���������� �������� wDance � true
            aiAnimator.SetBool("wDance", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // ����� ����� �������� �������, ����� �������� �������� �������,
            // ���� ��� �������������� ������� ����
            aiAnimator.SetBool("wDance", false);
        }
    }
}