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
        // ∆дем заданное количество секунд
        yield return new WaitForSeconds(delay);

        // —крываем канвас
        gameObject.SetActive(false);
    }
}
