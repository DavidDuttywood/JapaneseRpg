using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextTypeWriter : MonoBehaviour
{
	public Text txt;
	string story;
	public bool isTyping;

	public void Type(string input)
	{
		txt.supportRichText = true;
		txt.text = "";
		story = input;
		StartCoroutine("PlayText");

	}
	IEnumerator PlayText()
	{
		isTyping = true;
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(0.00375f);
		}
		isTyping = false;
	}
}