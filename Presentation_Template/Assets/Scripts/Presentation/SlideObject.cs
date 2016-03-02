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

    private Image _image;
    public Image Image
    {
        get
        {
            if (_image == null)
                _image = GetComponent<Image>();
            return _image;
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

    public float Angle;
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

    void Update()
    {
        deltaTime = deltaTime + Time.deltaTime;
        float phase = Mathf.Sin(deltaTime / Period);
        transform.localRotation = Quaternion.AngleAxis(initialRotation + (phase * Angle), Vector3.up);
    }

    public void SetSprite(Sprite sprite)
    {
        Image.sprite = sprite;
    }

    public void SetOverlay(Sprite sprite)
    {
        Debug.Log(sprite == null ? "null" : "notnull");
        if (sprite == null)
            Overlay.gameObject.SetActive(false);
        else 
            Overlay.SetOverlay(sprite);
    }
}
