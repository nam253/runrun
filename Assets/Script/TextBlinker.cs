using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class TextBlinker : MonoBehaviour
{
    public Text text;

    public LoopType loopType;

    Tween fadeTween;

    void OEnable()
    {
        Start();
    }

    void Osable()
    {
        StopBlinking();
    }

    void OnDestroy()
    {
        if (text != null)
        {
            text.DOKill(true);
        }
    }

    void Start()
    {
        if (text != null)
        {
            text.DOKill(true);
            text.DOFade(0.0f, 1).SetLoops(-1, loopType);
        }
    }

    void StopBlinking()
    {
        if (fadeTween != null && fadeTween.IsActive())
        {
            fadeTween.Kill();
        }
    }
}
