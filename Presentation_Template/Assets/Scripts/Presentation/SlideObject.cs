using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlideObject : MonoBehaviour
{
    private RectTransform _rectTransform;
    public RectTransform RectTransform
    {
        get
        {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
            return _rectTransform;
        }
    }

    private OverlayObject _overlayObject;
    public OverlayObject Overlay
    {
        get
        {
            if (_overlayObject == null)
                _overlayObject = GetComponentInChildren<OverlayObject>();
            return _overlayObject;
        }
    }

    public float AngleY;
    public float Period;

    [HideInInspector]
    public string SpriteName;

    private float initialRotation;
    private float deltaTime;

    void Start()
    {
        deltaTime = Time.deltaTime;
        initialRotation = transform.localEulerAngles.y;
    }

    public void Update()
    {
        deltaTime = deltaTime + Time.deltaTime;
        float phase = Mathf.Sin(deltaTime / Period);
        transform.localRotation = Quaternion.AngleAxis(initialRotation + (phase * AngleY), Vector3.up);

        if(Overlay!=null)
            Overlay.SetShadow(phase);
    }

    public void SetSprite(Sprite sprite)
    {
        var image = GetComponent<Image>();
        if(image!=null)
            image.sprite = sprite;
    }

    public void SetOverlay(Sprite sprite)
    {
        if (sprite == null && Overlay!=null)
            Overlay.gameObject.SetActive(false);
        else if(Overlay != null)
            Overlay.SetOverlay(sprite);
    }
}
