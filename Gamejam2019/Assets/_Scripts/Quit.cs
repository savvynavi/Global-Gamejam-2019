using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Quit : MonoBehaviour {
	Button btn;
	// Use this for initialization
	void Start () {
		btn = GetComponent<Button>();

		btn.onClick.AddListener(() => HandleClick());

	}

	void HandleClick(){
		Application.Quit();
	}
}
