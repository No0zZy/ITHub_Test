
using UnityEngine.UI;

public interface IFadeTextAnimation
{
    public float TextFadeDuration { get; }

    public void TextFadeShow(Text target);
    public void TextFadeHide(Text target);
}
