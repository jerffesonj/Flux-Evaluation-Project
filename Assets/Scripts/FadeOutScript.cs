using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeOutScript : MonoBehaviour
{
    public TMP_Text loadingText;

    Animation fadeOutAnimation;

    // Start is called before the first frame update
    void Start()
    {
        fadeOutAnimation = GetComponent<Animation>();
        BundleWebLoader.onFinishLoading += FadeOut;
    }
    private void OnDisable()
    {
        BundleWebLoader.onFinishLoading -= FadeOut;
    }

    void FadeOut()
    {
        loadingText.gameObject.SetActive(false);

        fadeOutAnimation.Play();
    }
}
