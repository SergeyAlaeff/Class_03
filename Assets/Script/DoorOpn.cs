using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator; // ������ �� Animator �����
    public string playerTag = "Player"; // ��� ������
    private bool hasOpened = false; // ����, ������������, ���� �� ����� ��� �������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) && !hasOpened)
        {
            // ���� ������ ������ ������ � ��������� ����� � ����� ��� �� �������,
            // ������������� �������� "DoorOpen" � true ��� �������� �����
            doorAnimator.SetBool("Door_Open", true);
            hasOpened = true; // ������������� ����, ��� ����� ���� �������
        }
    }
}