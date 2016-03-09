using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CarrousselScript : MonoBehaviour 
{
    public SlideObject SlidePrefab;

    public List<CustomSlide> CustomsSlides;

    public float SlideScale;
    public float CircleSize;
    public float AngleBetweenSlides;

    public float RotationSpeed = 5.0f;

    [HideInInspector] public static int CurrentSlide;

    private static string SlidesPaths = "Slides";
    private static string OverlaysPaths = "Overlays";

    private List<SlideObject> slides;

    private Vector3 destEuler;
    private Vector3 currEuler;




	// Use this for initialization
	void Start ()
	{
	    CurrentSlide = 0;
        slides = new List<SlideObject>();
        currEuler = destEuler = transform.rotation.eulerAngles;

        var index = 0;
        Sprite[] sprites = Resources.LoadAll<Sprite>(SlidesPaths);
        foreach (var sprite in sprites)
        {
            var slideToInstanciate = (SlideObject) CustomsSlides.FirstOrDefault(slide => slide.SlideIndex == index);
            if (slideToInstanciate == null)
                slideToInstanciate = SlidePrefab;

            var obj = (SlideObject)Instantiate(slideToInstanciate, new Vector3(0, 0, CircleSize), Quaternion.identity);
            obj.transform.localScale = new Vector3(SlideScale, SlideScale, SlideScale);
            obj.transform.SetParent(transform, false);
            obj.transform.RotateAround(transform.position, Vector3.up, AngleBetweenSlides * (index++));
            obj.name = "Slide: " + sprite.name;
            obj.SpriteName = sprite.name;
            obj.SetSprite(sprite);
            slides.Add(obj);
        }

        sprites = Resources.LoadAll<Sprite>(OverlaysPaths);
        foreach (var slide in slides)
        {
            var hasOverlay = false;
            foreach (var overlay in sprites)
            {
                if (slide.SpriteName == overlay.name)
                {
                    hasOverlay = true;
                    slide.SetOverlay(overlay);
                    slide.name += " (with overlay)";
                    break;
                }
            }
            if(!hasOverlay)
                slide.SetOverlay(null);
        }
	}


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            destEuler.y += -AngleBetweenSlides;
            CurrentSlide++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            destEuler.y += AngleBetweenSlides;
            CurrentSlide--;
        }

        currEuler = Vector3.Lerp(currEuler, destEuler, Time.deltaTime * RotationSpeed);
        transform.eulerAngles = currEuler;
    }
}
