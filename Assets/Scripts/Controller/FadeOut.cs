using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image image;

    public void SceneChange()
    {
        StartCoroutine("Change");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Change()
    {
        float startAlpha = 1;
        while(startAlpha > 0f)
        {
            startAlpha -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, startAlpha);
        }
    }
}
