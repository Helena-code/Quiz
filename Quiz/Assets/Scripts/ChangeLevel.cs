using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour
{
    public int successValue
    {
        get { return _successValue; }
    }

    [SerializeField]
    private int _successLimit;

    [SerializeField]
    private int _delayRestart;

    [SerializeField]
    private GameObject _buttonRestart;

    [SerializeField]
    private GameObject _stopBackground;

    [SerializeField]
    private GameObject _blackBackground;

    [SerializeField]
    private float _speedFadeOut;

    private CellSpawner _cellSpawnewScript;
    private int _successValue;


    public void StartLevel()
    {
        _cellSpawnewScript.ChooseBundle();
    }

    public void IncreaseSuccessValue()
    {
        _successValue++;
    }

    public void CheckSuccessLimit()
    {
        if (_successValue >= _successLimit)
        {
            _stopBackground.SetActive(true);
            _buttonRestart.SetActive(true);

        }
        else
        {
            StartLevel();
        }
    }

    public void CleanOutLevel()
    {
        _cellSpawnewScript.CleaneAllCell();

    }

    public void RestartGame()
    {
        // метод DOTween DoFade применяется только для материала
        // в связи с этим применен другой способ появления загрузочного экрана

        _blackBackground.SetActive(true);
        StartCoroutine(FadeOutBlack());
        _successValue = 0;
        Invoke("CleanOutLevel", _delayRestart);
        _buttonRestart.SetActive(false);
        _stopBackground.SetActive(false);
    }

    private void Awake()
    {
        _cellSpawnewScript = GetComponent<CellSpawner>();
        _buttonRestart.SetActive(false);
        _stopBackground.SetActive(false);
        _blackBackground.SetActive(false);
    }

    private void Start()
    {
        StartLevel();
    }

    private IEnumerator FadeOutBlack()
    {

        Color current = _blackBackground.GetComponent<Image>().color;
        _blackBackground.GetComponent<Image>().color = new Color(current.r, current.b, current.g, current.a + _speedFadeOut);
        if (current.a >= 1f)
        {

            yield return new WaitForSeconds(1);
            _blackBackground.SetActive(false);
            _blackBackground.GetComponent<Image>().color = Color.black;
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(0);
            StartCoroutine(FadeOutBlack());
        }
    }
}
