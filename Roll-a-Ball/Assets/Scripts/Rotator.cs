﻿using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	
	void Update () 
	{
		transform.Rotate (new Vector3 (15, 40, 35) * Time.deltaTime);
	}
}
