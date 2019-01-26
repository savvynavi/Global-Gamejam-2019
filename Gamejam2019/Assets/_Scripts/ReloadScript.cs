using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReloadScript : MonoBehaviour {
	RandomLevelLoad rndLvlLoad;
	Button btn;
	// Use this for initialization
	void Start()
	{
		rndLvlLoad = GameObject.FindGameObjectWithTag("Loader").GetComponent<RandomLevelLoad>();
		btn = GetComponent<Button>();
		btn.onClick.AddListener(() => HandleClick());
	}

	// Update is called once per frame
	void HandleClick()
	{
		rndLvlLoad.Reset();
		SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);

	}

}
