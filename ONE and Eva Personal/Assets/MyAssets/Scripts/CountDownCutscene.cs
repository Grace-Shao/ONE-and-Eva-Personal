using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CountDownCutscene : MonoBehaviour
{

	private float counter = 0;
	void Update()
	{
		counter += Time.deltaTime;
		if (counter > 4)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
