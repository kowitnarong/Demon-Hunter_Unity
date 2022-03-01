using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkImage : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer Image;
    public float BlinkFadeInTime = 0.5f;
    public float BlinkStayTime = 0.8f;
    public float BlinkFadeOutTime = 0.7f;
    private float _timeChecker = 0;
    private Color _color;
    void Start()
    {
        _color = Image.color;
    }
    void Update()
    {
        _timeChecker += Time.deltaTime;
        if (_timeChecker < BlinkFadeInTime)
        {
            Image.color = new Color(_color.r, _color.g, _color.b, _timeChecker / BlinkFadeInTime);
        }
        else if (_timeChecker < BlinkFadeInTime + BlinkStayTime)
        {
            Image.color = new Color(_color.r, _color.g, _color.b, 1);
        }
        else if (_timeChecker < BlinkFadeInTime + BlinkStayTime + BlinkFadeOutTime)
        {
            Image.color = new Color(_color.r, _color.g, _color.b, 1 - (_timeChecker - (BlinkFadeInTime + BlinkStayTime))/BlinkFadeOutTime);
        }
        else
        {
            _timeChecker = 0;
        }
    }
}
