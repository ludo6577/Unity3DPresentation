using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OverlayObject : MonoBehaviour {

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

    public void SetOverlay(Sprite sprite)
    {
        Image.sprite = sprite;
    }
}
