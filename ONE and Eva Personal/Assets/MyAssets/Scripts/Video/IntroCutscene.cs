using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroCutscene : MonoBehaviour
{
	public LevelLoader levelLoader;
	private float counter = 0;
	void Update()
	{
		counter += Time.deltaTime;
		if (counter > 95)
		{
			levelLoader.LoadNextLevel();
		}
	}
}
