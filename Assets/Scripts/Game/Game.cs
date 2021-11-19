using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	private static Game ms_instance = null;

	void Awake ()
	{
		ms_instance = this;
	}

	public static Game Get() 
	{
		return ms_instance;
	}
	
}
