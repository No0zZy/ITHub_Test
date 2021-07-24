using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
{
    [SerializeField] private UIAnimations anim;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private IBounceAnimation animBounce;
    [SerializeField] private IFadeTextAnimation animText;

    [SerializeField] private Button buttonPlay;
    [SerializeField] private Text textScore;

    private void Awake()
    {
        animBounce = anim;
        animText = anim;
    }

    public void OnPrepare()
    {
        buttonPlay.transform.localScale = new Vector3(0, 0, 0);
        textScore.color = new Color(textScore.color.r, textScore.color.g, textScore.color.b, 0f);

        buttonPlay.gameObject.SetActive(false);
        textScore.gameObject.SetActive(false);
    }

    public void OnPause()
    {
        buttonPlay.gameObject.SetActive(true);
        textScore.gameObject.SetActive(true);

        animText.TextFadeShow(textScore);
        animBounce.BounceShow(buttonPlay.transform);
    }

    public void OnGamePlay()
    {
        animText.TextFadeHide(textScore);
        animBounce.BounceHide(buttonPlay.transform);

        StartCoroutine(WaitFadeHideEnd());
        StartCoroutine(WaitBounceHideEnd());
    }

    public void OnScoreChanged()
    {
        textScore.text = "Score: " + gameManager.Score;
    }

    private IEnumerator WaitFadeHideEnd()
    {
        yield return new WaitForSeconds(animText.TextFadeDuration);
        textScore.gameObject.SetActive(false);
    }

    private IEnumerator WaitBounceHideEnd()
    {
        yield return new WaitForSeconds(animBounce.BounceHideDuration);
        buttonPlay.gameObject.SetActive(false);
    }
}
