using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMatch : MonoBehaviour {

	public List<EnemyWave> wavesPrefabs;
	public List<EnemyWave> m_spwanedObjects = new List<EnemyWave>(32);
	private int m_currentWaveIndex = 0;

	private float m_accumTime = 0.0f;
	private float m_nextGoal = 0.0f;

	public bool isSpawning { get; private set; }
    public bool wavesActive { get; private set; }

    public event OnFinishingSpawning onFinishingSpawning; 	
	public event OnFinishWaves onFinishWaves; 	
    public delegate void OnFinishingSpawning(EventArgs eventArgs);
    public delegate void OnFinishWaves(EventArgs eventArgs);


    // Use this for initialization
    void Awake ()
	{
		isSpawning = false;
        wavesActive = false;

    }

	public void StartSpawning ()
	{
		isSpawning = true;
        wavesActive = true;

    }
	
	// Update is called once per frame
	void Update ()
	{
		m_accumTime += Time.deltaTime;

        if (!isSpawning)
        {
            if(m_accumTime >= m_nextGoal)
            {
                wavesActive = false;
                onFinishWaves(null);
            }
            return;
        }

		if (wavesPrefabs == null)
		{
			isSpawning = false;
			onFinishingSpawning(null);
		}

		// spawn
		if (m_accumTime >= m_nextGoal)
			m_nextGoal += SpawnNext().waveTime;
	}

	public void AddEnemyWave(EnemyWave enemyWavePrefab)
	{
		wavesPrefabs.Add (enemyWavePrefab);
		isSpawning = true;
	}

	public void ResetLevel()
	{
		int arrayLenght = m_spwanedObjects.Count;

		for (int i = 0; i < arrayLenght; ++i)
			Destroy (m_spwanedObjects [i].gameObject);

		m_spwanedObjects.Clear ();
	}

	private EnemyWave SpawnNext()
	{
		EnemyWave objectSpawnerPrefab = wavesPrefabs [m_currentWaveIndex++];

		EnemyWave objectSpawner = Instantiate (objectSpawnerPrefab);
		m_spwanedObjects.Add(objectSpawner); 
		objectSpawner.transform.position = transform.position;
		objectSpawner.gameObject.SetActive (true);
		objectSpawner.Spawn();

		if (m_currentWaveIndex >= wavesPrefabs.Count)
		{
			isSpawning = false;
			onFinishingSpawning (null);
		}

		return objectSpawner;
	}
}
