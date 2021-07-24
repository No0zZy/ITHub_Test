using UnityEngine.UI;

public interface IFadeImageAnimation 
{
    public float ImageFadeDuration { get; }
    public void ImageFadeShow(Image target);
    public void ImageFadeHide(Image target);
}