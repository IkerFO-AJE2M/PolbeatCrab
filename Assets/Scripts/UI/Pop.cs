using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pop : MonoBehaviour
{
    public float popScale = 1.3f;   // Cuánto se agranda el botón
    public float duration = 0.1f;   // Duración de la animación

    void Start()
    {
        // Busca todos los botones en el Canvas
        Button[] buttons = GetComponentsInChildren<Button>();

        foreach (Button btn in buttons)
        {
            AddPopEffect(btn);
        }
    }

    void AddPopEffect(Button btn)
    {
        EventTrigger trigger = btn.gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = btn.gameObject.AddComponent<EventTrigger>();

        // OnPointerDown
        EventTrigger.Entry entryDown = new EventTrigger.Entry();
        entryDown.eventID = EventTriggerType.PointerDown;
        entryDown.callback.AddListener((data) => { StartCoroutine(PopCorrutina(btn.transform, popScale)); });
        trigger.triggers.Add(entryDown);

        // OnPointerUp
        EventTrigger.Entry entryUp = new EventTrigger.Entry();
        entryUp.eventID = EventTriggerType.PointerUp;
        entryUp.callback.AddListener((data) => { StartCoroutine(PopCorrutina(btn.transform, 1f)); });
        trigger.triggers.Add(entryUp);
    }

    IEnumerator PopCorrutina(Transform target, float targetScale)
    {
        Vector3 originalScale = target.localScale;
        Vector3 endScale = Vector3.one * targetScale;
        float t = 0f;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            target.localScale = Vector3.Lerp(originalScale, endScale, t / duration);
            yield return null;
        }

        target.localScale = endScale;
    }
}
