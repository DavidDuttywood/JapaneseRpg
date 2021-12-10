using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCreditsText : MonoBehaviour
{
    public Text currentText;
    private int i;

    private string[] introCreditText = {
        "A game for those with a curious mind",
        "Developed and produced by Dave Woodward",
        "With art created by Gutty Kreum",
        "And translations by -some dude-",
        "GAME TITLE"
    };
 

    public void Start()
    {
        i = 0;
        //StartCoroutine(WaitLoad());
        //StartCoroutine(GetLine());
    }

    public void GetLine()
    {
        currentText.text = introCreditText[i];
        i++;
    }

    //IEnumerator WaitLoad()
    //{
    //    yield return new WaitForSecondsRealtime(2);
    //}

    //IEnumerator GetLine()
    //{
    //    currentText.text = introCreditText[i];
    //    i++;

    //    yield return new WaitForSecondsRealtime(4);
    //    if(i < introCreditText.Length)
    //        StartCoroutine(GetLine());
    //}
}
