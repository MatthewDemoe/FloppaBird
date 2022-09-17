using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitioner : MonoBehaviour
{
    public static SceneTransitioner Instance { get; private set; } = null;

    [SerializeField]
    Image screenBlackout;

    const float TransitionTime = 0.5f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
            Debug.Log("Trying to create more than one SceneTransitioner");

        screenBlackout.color = Color.black;
    }

    void Start()
    {
        StartCoroutine(TransitionRoutine(fadeToBlack: false));
    }

    public void ReloadScene()
    {
        StartCoroutine(TransitionRoutine(fadeToBlack: true, reloadScene: true));
    }

    IEnumerator TransitionRoutine(bool fadeToBlack, bool reloadScene = false)
    {
        float transitionTimer = 0.0f;
        Color blackoutColor = Color.black;

        while (transitionTimer <= TransitionTime)
        {
            yield return null;
            transitionTimer += Time.deltaTime;

            blackoutColor.a = UtilMath.Lmap(transitionTimer, 0.0f, TransitionTime, fadeToBlack ? 0.0f : 1.0f, fadeToBlack ? 1.0f : 0.0f);

            screenBlackout.color = blackoutColor;
        }

        if(reloadScene)
            SceneManager.LoadScene(0);
    }
}
