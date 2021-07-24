using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIAnimations : MonoBehaviour, IFadeImageAnimation, IFadeTextAnimation, IBounceAnimation
{
    [Header("Bounce")]
    [SerializeField] private float bounceTouchDuration;
    public float BounceTouchDuration => bounceTouchDuration;
    [SerializeField] private float bounceShowDuration;
    public float BounceShowDuration => bounceShowDuration;
    [SerializeField] private float bounceHideDuration;
    public float BounceHideDuration => bounceShowDuration;
    [Header("Fade")]
    [SerializeField] private float fadeImageDuration;
    public float ImageFadeDuration => fadeImageDuration;
    [SerializeField] private float fadeTextDuration;
    public float TextFadeDuration => fadeTextDuration;


    public void BounceHide(Transform target)
    {
        target.DOScale(1.2f, bounceHideDuration * 0.3f)
            .OnComplete(() => target.DOScale(0f, bounceHideDuration * 0.7f));
    }

    public void BounceShow(Transform target)
    {
        target.DOScale(1.2f, bounceShowDuration * 0.5f)
            .OnComplete(() => target.DOScale(0.9f, bounceShowDuration * 0.25f)
                .OnComplete(() => target.DOScale(1f, bounceShowDuration * 0.25f)));
    }

    public void BounceTouch(Transform target)
    {
        target.DOScale(1.2f, bounceShowDuration * 0.33f)
            .OnComplete(() => target.DOScale(0.9f, bounceShowDuration * 0.33f)
                .OnComplete(() => target.DOScale(1f, bounceShowDuration * 0.33f)));
    }

    public void ImageFadeHide(Image target)
    {
        target.DOFade(0f, fadeImageDuration);
    }

    public void ImageFadeShow(Image target)
    {
        target.DOFade(1f, fadeImageDuration);
    }

    public void TextFadeHide(Text target)
    {
        target.DOFade(0f, fadeTextDuration);
    }

    public void TextFadeShow(Text target)
    {
        target.DOFade(1f, fadeTextDuration);
    }
}
