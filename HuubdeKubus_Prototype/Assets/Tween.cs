using UnityEngine;
using System.Collections;

public class Tween : MonoBehaviour
{

    public float time = 3;
    private float start;
    private float end;
    private float startTime;
    public AnimationCurve curve;

    public enum Tweens
    {
        LINEAR,
        EASE_IN,
        CURVE
    }

    public Tweens tweenType;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        start = transform.position.y;
        end = start -450;
    }

    // Update is called once per frame
    void Update()
    {
        float move;


        switch (tweenType)
        {
            case Tweens.LINEAR:
                move = Linear(DeltaTime());
                break;

            case Tweens.EASE_IN:
                move = EaseIn(DeltaTime());
                break;

            case Tweens.CURVE:
                move = Curve(DeltaTime());
                break;

            default:
                move = 0;
                break;
        }

        transform.position = new Vector3(
            transform.position.x,
            move,
            transform.position.z
        );

        Bounce();
    }

    float DeltaTime()
    {
        float timeDelta = Time.time - startTime;

        if (timeDelta < time)
        {
            return timeDelta / time;
        }
        else
        {
            return 1;
        }
    }

    void Bounce()
    {
        if (DeltaTime() == 1)
        {
            float temp = end;

            end = start;
            start = temp;
            startTime = Time.time;
        }
    }

    float Linear(float delta)
    {
        return Mathf.Lerp(start, end, delta);
    }

    float EaseIn(float delta)
    {
        return Mathf.Lerp(start, end, delta * delta);
    }

    float Curve(float delta)
    {
        return (end - start) * curve.Evaluate(delta) + start;
    }

    float EaseOutBounce(float start, float end, float value)
    {
        value /= 1f;
        end -= start;
        if (value < (1 / 2.75f))
        {
            return end * (7.5625f * value * value) + start;
        }
        else if (value < (2 / 2.75f))
        {
            value -= (1.5f / 2.75f);
            return end * (7.5625f * (value) * value + .75f) + start;
        }
        else if (value < (2.5 / 2.75))
        {
            value -= (2.25f / 2.75f);
            return end * (7.5625f * (value) * value + .9375f) + start;
        }
        else
        {
            value -= (2.625f / 2.75f);
            return end * (7.5625f * (value) * value + .984375f) + start;
        }
    }
}