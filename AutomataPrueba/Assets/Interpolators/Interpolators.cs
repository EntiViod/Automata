using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Interpolators
{
    public enum INTERPOLATORTYPE
    {
        LINEAR,
        QUADIN,
        QUADOUT,
        QUADINOUT,
        CUBICIN,
        CUBICOUT,
        CUBICINOUT,
        QUARTIN,
        QUARTOUT,
        QUARTINOUT,
        QUINTIN,
        QUINOUT,
        QUININOUT,
        BACKIN,
        BACKOUT,
        BACKINOUT,
        ELASTICIN,
        ELASTICOUT
    }
    public delegate  float interpolatorFunc(float start, float end, float ratio);

   
    // ------------------------------
    // linear
    // ------------------------------
    public static float linear(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
        return end * ratio + start * (1 - ratio);
    }

    // ------------------------------
    // quadratic
    // ------------------------------
    public static float quadIn(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        return c * ratio * ratio + start;
    }
    public static float quadOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        return -c * ratio * (ratio - 2.0f) + start;
    }
    public static float quadInOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        float t = ratio * 2.0f;
        if (t < 1.0f) return ((c * 0.5f) * t * t) + start;
          float tm = t - 1;
        return -(c * 0.5f) * (((tm - 2.0f) * (tm)) - 1.0f) + start;
    }

    // ------------------------------
    // cubic
    // ------------------------------
    public static float cubicIn(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        return c * ratio * ratio * ratio + start;
    }
    public static float cubicOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
          float ratio2 = ratio - 1;
        return c * (ratio2 * ratio2 * ratio2 + 1) + start;
    }
    public static float cubicInOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        float ratio2 = 2 * ratio;
        if (ratio2 < 1) return c / 2 * ratio2 * ratio2 * ratio2 + start;
        ratio2 -= 2;
        return c / 2 * (ratio2 * ratio2 * ratio2 + 2) + start;
    }

    // ------------------------------
    // quart
    // ------------------------------
    public static float quartIn(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        return c * ratio * ratio * ratio * ratio + start;
    }
    public static float quartOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
          float t = ratio - 1;
        return -c * (t * t * t * t - 1.0f) + start;
    }
    public static float quartInOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        float t = ratio * 2.0f;
        if (t < 1.0f) return c * 0.5f * t * t * t * t + start;
        t -= 2.0f;
        return -c * 0.5f * ((t) * t * t * t - 2.0f) + start;
    }

    // ------------------------------
    // quint
    // ------------------------------
    public static float quintIn(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        return c * ratio * ratio * ratio * ratio * ratio + start;
    }
    public static float quintOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        float ratio2 = ratio - 1.0f;
        return c * ((ratio2) * ratio2 * ratio2 * ratio2 * ratio2 + 1.0f) + start;
    }
    public static float quintInOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        float t = ratio * 2.0f;
        if (t < 1.0f) return c * 0.5f * t * t * t * t * t + start;
        t -= 2.0f;
        return c * 0.5f * ((t) * t * t * t * t + 2.0f) + start;
    }

    // ------------------------------
    // back
    // ------------------------------
    public static float backIn(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        float s = 1.70158f;
        return c * (ratio) * ratio * ((s + 1) * ratio - s) + start;
    }
    public static float backOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
          float s = 1.70158f;
          float ratio2 = ratio - 1;
        return c * (ratio2 * ratio2 * ((s + 1) * ratio2 + s) + 1) + start;
    }
    public static float backInOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        float s = 1.70158f;
        s *= (1.525f);
        float ratio2 = ratio;
        if ((ratio2 *= 2) < 1) return c / 2 * (ratio2 * ratio2 * (((s) + 1) * ratio2 - s)) + start;
          float postFix = ratio2 -= 2;
        return c / 2 * ((postFix) * ratio2 * (((s) + 1) * ratio2 + s) + 2) + start;
    }

    // ------------------------------
    // elastic
    // ------------------------------
    public static float elasticIn(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
          float p = 0.3f;
          float a = c;
          float s = p * 0.25f;
        float ratio2 = ratio;
          float postFix = a * Mathf.Pow(2.0f, 10.0f * (ratio2 -= 1)); // this is a fix, again, with post-increment operators
        return -(postFix * Mathf.Sin((float)((ratio2 - s) * (2 * Mathf.PI) / p))) + start;
    }
    public static float elasticOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end; 
          float c = end - start;
          float p = 0.3f;
          float a = c;
          float s = p * 0.25f;
        return (a * Mathf.Pow(2.0f, -10 * ratio) * Mathf.Sin((float)((ratio - s) * (2 * Mathf.PI) / p)) + c + start);
    }
    public static float elasticInOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
        float ratio2 = 2 * ratio;
          float c = end - start;
          float p = (.3f * 1.5f);
          float a = c;
          float s = p * 0.25f;
        float postFix;
        if (ratio2 < 1)
        {
            postFix = a * Mathf.Pow(2.0f, 10.0f * (ratio2 -= 1)); // postIncrement is evil
            return -.5f * (postFix * Mathf.Sin((float)((ratio2 - s) * (2 * Mathf.PI) / p))) + start;
        }
           postFix = a * Mathf.Pow(2.0f, -10.0f * (ratio2 -= 1)); // postIncrement is evil
        return postFix * Mathf.Sin((float)((ratio2 - s) * (2 * Mathf.PI) / p)) * .5f + c + start;
    }

    // ------------------------------
    // bounce
    // ------------------------------
    public static float bounceOut(  float  start,   float  end,   float ratio)
    {
        float t;
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        if (ratio < (1.0f / 2.75f)) return c * (7.5625f * ratio * ratio) + start;
        if (ratio < (2 / 2.75f))
        {
               t = ratio - (1.5f / 2.75f);
            return c * (7.5625f * t * t + .75f) + start;
        }
        if (ratio < (2.5 / 2.75))
        {
               t = ratio - (2.25f / 2.75f);
            return c * (7.5625f * t * t + .9375f) + start;
        }

           t = ratio - (2.625f / 2.75f);
        return c * (7.5625f * t * t + .984375f) + start;
    }
    public static float bounceIn(  float  start,   float  end,   float ratio)
    {
        return bounceOut(end, start, 1.0f - ratio);
    }
    public static float bounceInOut(  float  start,   float  end,   float ratio)
    {
          float m = (start + end) * 0.5f;
        if (ratio < 0.5f) return bounceIn(start, m, ratio * 2.0f);
        return bounceOut(m, end, ratio * 2.0f - 1.0f);
    }

    // ------------------------------
    // circular
    // ------------------------------
    public static float circularIn(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        return -c * (Mathf.Sqrt(1.0f - ratio * ratio) - 1.0f) + start;
    }
    public static float circularOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
          float t = ratio - 1.0f;
        return c * Mathf.Sqrt(1.0f - t * t) + start;
    }
    public static float circularInOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        float t = ratio * 2.0f;
        if (t < 1.0f) return -c * 0.5f * (Mathf.Sqrt(1.0f - t * t) - 1.0f) + start;
          float t2 = t - 2.0f;
        return c * 0.5f * (Mathf.Sqrt(1.0f - t2 * (t2)) + 1.0f) + start;
    }

    // ------------------------------
    // expo
    // ------------------------------
    public static float expoIn(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        return c * Mathf.Pow(2.0f, 10 * (ratio - 1.0f)) + start;
    }
    public static float expoOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        return c * (-Mathf.Pow(2.0f, -10 * ratio) + 1.0f) + start;
    }
    public static float expoInOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        float t = ratio * 2.0f;
        if (t < 1.0f) return c * 0.5f * Mathf.Pow(2.0f, 10 * (t - 1.0f)) + start;
        return c * 0.5f * (-Mathf.Pow(2.0f, -10.0f * --t) + 2) + start;
    }

    // ------------------------------
    // sine
    // ------------------------------
    public static float sineIn(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        return -c * Mathf.Cos((float)(ratio * Mathf.PI * 0.5f)) + c + start;
    }

    public static float sineOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        return c * Mathf.Sin((float)(ratio * Mathf.PI * 0.5f)) + start;
    }
    public static float sineInOut(  float  start,   float  end,   float ratio)
    {
        if (ratio <= 0.0f) return start;
        if (ratio >= 1.0f) return end;
          float c = end - start;
        return -c * 0.5f * (Mathf.Cos((float)(Mathf.PI * ratio)) - 1.0f) + start;
    }
}


