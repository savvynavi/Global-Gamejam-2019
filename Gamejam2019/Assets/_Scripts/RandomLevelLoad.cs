using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RandomLevelLoad : MonoBehaviour {
	public Scene[] scenes;
	public int NumOfLevels;

	int numOfRounds = 0;
	List<string> usedSceneNames;
	List<string> sceneNames;

	List<string> SaveSceneNames;
	Death death;

	// Use this for initialization
	void Start () {
		death = GetComponent<Death>();
		usedSceneNames = new List<string>();
		sceneNames = new List<string>();
		SaveSceneNames = new List<string>();
		InitiateScenes(sceneNames);
		InitiateScenes(SaveSceneNames);
	}

	void InitiateScenes(List<string> str){
		str.Add("SampleScene");
		str.Add("Level2");
		str.Add("Level3");
		str.Add("Level4");
	}

	public void NextLevel(){
		if(numOfRounds >= NumOfLevels) {
			SceneManager.LoadScene("FinalScene", LoadSceneMode.Single);
			return;

		} else {
			numOfRounds++;
		}
		string sceneToRun = sceneNames[Random.Range(0, sceneNames.Count)];
		sceneNames.Remove(sceneToRun);
		SceneManager.LoadScene(sceneToRun, LoadSceneMode.Single);
		//LoadScene(sceneToRun);
	}


	public void Reset(){
		sceneNames.Clear();
		InitiateScenes(sceneNames);
		numOfRounds = 0;
	}
}
