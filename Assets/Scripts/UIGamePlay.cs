using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : MonoBehaviour
{
    [SerializeField] private UIAnimations anim;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private IBounceAnimation animBounce;
    [SerializeField] private IFadeTextAnimation animText;

    [SerializeField] private Button buttonPause;
    [SerializeField] private Text textScore;

    private void Awake()
    {
        animBounce = anim;
        animText = anim;
    }

    public void OnPrepare()
    {
        buttonPause.transform.localScale = new Vector3(0, 0, 0);
        textScore.color = new Color(textScore.color.r, textScore.color.g, textScore.color.b, 0f);

        buttonPause.gameObject.SetActive(false);
        textScore.gameObject.SetActive(false);
    }

    public void OnGamePlay()
    {
        buttonPause.gameObject.SetActive(true);
        textScore.gameObject.SetActive(true);

        animText.TextFadeShow(textScore);
        animBounce.BounceShow(buttonPause.transform);
    }

    public void OnPauseAndGameOver()
    {
        animText.TextFadeHide(textScore);
        animBounce.BounceHide(buttonPause.transform);

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
        buttonPause.gameObject.SetActive(false);
    }
}
