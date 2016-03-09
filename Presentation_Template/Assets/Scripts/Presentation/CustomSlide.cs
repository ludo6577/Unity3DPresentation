using UnityEngine;
using System.Collections;

public class CustomSlide : SlideObject
{
    public int SlideIndex;

    public bool IsVideo = false;

    private MovieTexture _movie;
    private MovieTexture Movie
    {
        get
        {
            if (_movie == null)
            {
                Renderer r = GetComponentInChildren<Renderer>();
                _movie = (MovieTexture)r.material.mainTexture;
            }
            return _movie;
        }
    }

    void Start()
    {
        
    }

    public new void Update()
    {
        //base.Update();

        if (IsVideo && CarrousselScript.CurrentSlide == SlideIndex && !Movie.isPlaying)
        {
            Movie.Play();
        }
        else if(IsVideo && CarrousselScript.CurrentSlide != SlideIndex && Movie.isPlaying)
        {
            Movie.Stop();
        }
    }
}
