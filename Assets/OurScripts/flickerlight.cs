using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickerlight : MonoBehaviour
{

	Light testLight;
	public float minWaitTime;
	public float maxWaitTime;

	void Start()
	{
		testLight = GetComponent<Light>();
		StartCoroutine(Flashing());
	}

	IEnumerator Flashing()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.2f);
			testLight.enabled = !testLight.enabled;

		}
	}
}
	