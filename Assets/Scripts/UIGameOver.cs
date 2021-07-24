using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIGameOver : MonoBehaviour
{
    //Попытался сделать реализацию через интерфейсы, 
    //но они не отображаются в инспекторе и все равно приходится привязываться к классу
    //может я что то не так делаю? 
    [SerializeField] private UIAnimations anim;

    [SerializeField] private IBounceAnimation bounceAnim;
    [SerializeField] private IFadeImageAnimation imageAnim;
    [SerializeField] private IFadeTextAnimation textAnim;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private Button buttonRestart;
    [SerializeField] private Text textScore;
    [SerializeField] private Text textGameOver;

    [SerializeField] private Image loadingScreen;

    public UnityEvent Restart;

    private void Awake()
    {
        bounceAnim = anim;
        imageAnim = anim;
        textAnim = anim;
    }

    public void OnPrepare()
    {
        buttonRestart.transform.localScale = new Vector3(0, 0, 0);
        textScore.color = new Color(textScore.color.r, textScore.color.g, textScore.color.b, 0f);
        textGameOver.color = new Color(textGameOver.color.r, textGameOver.color.g, textGameOver.color.b, 0f);

        textGameOver.gameObject.SetActive(false);
        buttonRestart.gameObject.SetActive(false);
        textScore.gameObject.SetActive(false);
    }

    public void OnGameOver()
    {
        buttonRestart.gameObject.SetActive(true);
        textScore.gameObject.SetActive(true);
        textGameOver.gameObject.SetActive(true);

        textAnim.TextFadeShow(textScore);
        textAnim.TextFadeShow(textGameOver);
        bounceAnim.BounceShow(buttonRestart.transform);
    }

    public void OnRestartClicked()
    {
        bounceAnim.BounceTouch(buttonRestart.transform);
        StartCoroutine(RestartLoadingScreen());
    }

    public void OnScoreChanged()
    {
        textScore.text = "Score: " + gameManager.Score;
    }

    private IEnumerator RestartLoadingScreen()
    {
        loadingScreen.gameObject.SetActive(true);
        imageAnim.ImageFadeShow(loadingScreen);

        yield return new WaitForSeconds(imageAnim.ImageFadeDuration);

        Restart?.Invoke();

        imageAnim.ImageFadeHide(loadingScreen);

        StartCoroutine(WaitFadeLoadingScreen());
    }

    private IEnumerator WaitFadeLoadingScreen()
    {
        yield return new WaitForSeconds(imageAnim.ImageFadeDuration);
        loadingScreen.gameObject.SetActive(false);
    }
}
