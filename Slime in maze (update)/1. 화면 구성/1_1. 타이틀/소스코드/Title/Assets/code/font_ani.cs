using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class font_ani: MonoBehaviour
{

    public GameObject fontani;

    float time = 0f;

    bool start = false;

    public void fontanion()
    {

        fontani.GetComponent<Image>().enabled = true;
        start = true;

    }
    private void Update()
    {
        if (start == true)
        {
            if (fontani.GetComponent<Image>().color.a == 0f) StartCoroutine("fadein"); // 0 -> 1

            if (fontani.GetComponent<Image>().color.a == 1f) StartCoroutine("fadeout"); // 1 -> 0

        }
        if(start == true && Input.anyKeyDown)
        {
            // 구글 등록
            SceneManager.LoadScene("sample");// 씬전환
        }
        
        }

    public IEnumerator fadein()
    {
        if (fontani.GetComponent<Image>().color.a == 1f) StopCoroutine("fadein");
        Color font = fontani.GetComponent<Image>().color;
        time = 0f;

        while(font.a < 1f)
        {
            time += Time.deltaTime / 2f;
            font.a = Mathf.Lerp(0f, 1f, time);
            fontani.GetComponent<Image>().color = font;
            yield return null;
        }

    }
    public IEnumerator fadeout()
    {
        if (fontani.GetComponent<Image>().color.a == 0f) StopCoroutine("fadeout");
        Color font = fontani.GetComponent<Image>().color;
        time = 0f;

        while (font.a >0f)
        {
            time += Time.deltaTime / 2f;
            font.a = Mathf.Lerp(1f, 0f, time);
            fontani.GetComponent<Image>().color = font;
            yield return null;
        }
    }

}
