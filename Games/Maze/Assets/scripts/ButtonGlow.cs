using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonGlow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Glow")]
    public CanvasGroup glow;
    public float fadeSpeed = 5f;
    public float pulseSpeed = 3f;
    public float minGlow = 0.65f;
    public float maxGlow = 1f;

    [Header("Button Scale")]
    public RectTransform button;
    public float hoverScale = 1.04f;
    public float scaleSpeed = 8f;

    private bool isHovered;
    private Vector3 originalScale;

    public Texture2D NormalCursor;
    public Texture2D pointerCursor;

    void Start()
    {
        Cursor.SetCursor(NormalCursor, new Vector2(8, 0), CursorMode.Auto);
        if (glow != null)
            glow.alpha = 0f;

        if (button != null)
            originalScale = button.localScale;
    }

    void Update()
    {
        if (glow != null)
        {
            float targetAlpha = 0f;

            if (isHovered)
            {
                float pulse = (Mathf.Sin(Time.unscaledTime * pulseSpeed) + 1f) / 2f;

                targetAlpha = Mathf.Lerp(minGlow, maxGlow, pulse);
            }

            glow.alpha = Mathf.MoveTowards(
                glow.alpha,
                targetAlpha,
                fadeSpeed * Time.unscaledDeltaTime
            );
        }

        if (button != null)
        {
            Vector3 targetScale = originalScale * (isHovered ? hoverScale : 1f);

            button.localScale = Vector3.Lerp(
                button.localScale,
                targetScale,
                scaleSpeed * Time.unscaledDeltaTime
            );
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        Cursor.SetCursor(pointerCursor, new Vector2(8, 0), CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        Cursor.SetCursor(NormalCursor, new Vector2(8, 0), CursorMode.Auto);    
    }
}
