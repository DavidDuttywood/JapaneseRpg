using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextTypeWriter : MonoBehaviour
{
	public Text txt;
	string story;

    public void Start()
    {
		txt = GetComponent<Text>();
	}

	public void Type(string input)
	{
		txt.text = "";
		story = input;
		StartCoroutine("PlayText");

	}
	IEnumerator PlayText()
	{
		GameManager.instance.interactButton.interactable = false;
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(0.03375f);
		}
		GameManager.instance.interactButton.interactable = true;
	}
}