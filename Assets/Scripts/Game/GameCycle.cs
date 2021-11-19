using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCycle : MonoBehaviour {

	// this could be a list....
	public GameMatch gameMatch;
	public PlayerReaction playerReaction;

	// Use this for initialization
	void Start ()
	{
		gameMatch.onFinishWaves += new GameMatch.OnFinishWaves(OnLevelFinished);
		playerReaction.onPlayerDie += new PlayerReaction.OnPlayerDie (OnLevelFail);

		StartNewMatch ();
	}

	void StartNewMatch ()
	{
		gameMatch.StartSpawning ();
	}

	void OnLevelFinished(EventArgs eventArgs)
	{
		ClearLevel ();
	}

	void OnLevelFail(EventArgs eventArgs)
	{
		ClearLevel ();
		StartNewMatch ();
	}
		
	void ClearLevel()
	{
		gameMatch.ResetLevel ();
	}
}
