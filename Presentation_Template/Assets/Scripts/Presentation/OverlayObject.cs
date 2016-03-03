using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OverlayObject : MonoBehaviour
{

    private Shadow shadow;

    void Start()
    {
        shadow = GetComponent<Shadow>();
    }

    public void SetShadow(float phase)
    {
        if(shadow!=null)
            shadow.effectDistance = new Vector2(phase * -3, shadow.effectDistance.y);
    }

    public void SetOverlay(Sprite sprite)
    {
        var image = GetComponent<Image>();
        image.sprite = sprite;
    }
}
