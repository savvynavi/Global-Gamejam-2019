using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour {

	RandomLevelLoad rndLvlLoad;
	Button btn;

	// Use this for initialization
	void Start () {
		rndLvlLoad = GameObject.FindGameObjectWithTag("Loader").GetComponent<RandomLevelLoad>();
		btn = GetComponent<Button>();
		btn.onClick.AddListener(() => HandleClick());
	}
	
	// Update is called once per frame
	void HandleClick(){
		//rndLvlLoad.NextLevel();
		SceneManager.LoadScene("StartCutscene", LoadSceneMode.Single);

	}

}
