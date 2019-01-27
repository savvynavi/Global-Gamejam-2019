using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathSceneLoad : MonoBehaviour {

	Button btn;

	// Use this for initialization
	void Start()
	{
		btn = GetComponent<Button>();
		btn.onClick.AddListener(() => HandleClick());
	}

	// Update is called once per frame
	void HandleClick()
	{
		SceneManager.LoadScene("GameOverTxt", LoadSceneMode.Single);

	}
}
