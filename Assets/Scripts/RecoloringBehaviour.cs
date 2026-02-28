using UnityEngine;

public class RecoloringBehaviour : MonoBehaviour
{
    [SerializeField] private float colorChangeDuration = 1f; // Время смены цвета
    [SerializeField] private float delayBetweenChanges = 2f; // Задержка после смены цвета

    private Renderer objectRenderer;
    private Color targetColor;
    private Color startColor;
    private float currentTime = 0f;
    private float waitTime = 0f;
    private bool isChanging = true;
    private bool isWaiting = false;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        SetNewTargetColor();
    }

    private void Update()
    {
        if (isChanging)
        {
            // Фаза смены цвета
            currentTime += Time.deltaTime;
            float t = currentTime / colorChangeDuration;
            objectRenderer.material.color = Color.Lerp(startColor, targetColor, t);

            if (currentTime >= colorChangeDuration)
            {
                // Завершили смену цвета, переходим к ожиданию
                objectRenderer.material.color = targetColor;
                isChanging = false;
                isWaiting = true;
                waitTime = 0f;
            }
        }
        else if (isWaiting)
        {
            // Фаза ожидания
            waitTime += Time.deltaTime;

            if (waitTime >= delayBetweenChanges)
            {
                // Завершили ожидание, начинаем новую смену цвета
                isWaiting = false;
                isChanging = true;
                currentTime = 0f;
                startColor = objectRenderer.material.color;
                SetNewTargetColor();
            }
        }
    }

    private void SetNewTargetColor()
    {
        targetColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
        startColor = objectRenderer.material.color;
    }
}