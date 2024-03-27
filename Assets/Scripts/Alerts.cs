using System.Collections;
using TMPro;
using UnityEngine;

public class Alerts : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void HideAlert()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator HideCanvasAfterDelay(float delay)
    {
        // ���� �������� ���������� ������
        yield return new WaitForSeconds(delay);

        // �������� ������
        gameObject.SetActive(false);
    }
}
