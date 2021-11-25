using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGrid : MonoBehaviour {

	public float rotation;
	public float length;

	[Header("Element")]
	public Mesh baseMesh;

	[Range(0.0f, 0.8f)] 
	public float spaceBetweenShapes = 0.2f;

	[Range(0.001f, 2.0f)] 
	public float thickness = 0.4f;

	[Header("Grid")]
	[Range(1, 9)] 
	public int width = 4;
	[Range(1, 9)] 
	public int height = 4;
	public int numCells { get { return width * height; } }

	[HideInInspector]
	public bool[] shapeGrid;
	[HideInInspector]
	public Color[] colorGrid;

	public Vector3 defaultObjectScale
	{
		// assuming default mesh size is 1
		get { return new Vector3(1.0f - (spaceBetweenShapes * 0.5f), 1.0f - (spaceBetweenShapes * 0.5f), thickness); }
	}

	// internal count
	private GameObject[] m_objectGrid;
	public List<GameObject> meshObjects { private set; get; }

	// Use this for initialization
	void Start ()
	{
		GenerateGrid ();
	}

	public void GenerateGrid()
	{
		int arraySize = numCells;

		// init
		if (meshObjects == null)
		{
			meshObjects = new List<GameObject> (arraySize);
			m_objectGrid = new GameObject[arraySize];
		}
		// clean up
		else 
		{ 
			for (int i = 0; i < meshObjects.Count; ++i)
				Destroy(meshObjects[i].gameObject);

			meshObjects.Clear ();
		}
				

		// mesh grid
		for (int i = 0; i < arraySize; ++i)
		{
			if (shapeGrid [i])
				GenerateMeshObject (i);
			else
				m_objectGrid [i] = null;
		}

		transform.RotateAround(transform.position, transform.forward, rotation);
		transform.localScale = new Vector3(transform.localScale.x * length, transform.localScale.y, transform.localScale.z);

	}

	private void GenerateMeshObject (int index)
	{
		// create object
		GameObject meshObject = new GameObject ("Mesh Object " + meshObjects .Count);
		meshObjects .Add(meshObject);
		m_objectGrid[index] = meshObject;

		// renderer and mesh
		meshObject.AddComponent<MeshRenderer>();
		MeshFilter meshFilter = meshObject.AddComponent<MeshFilter> ();
		meshFilter.mesh = baseMesh;

		// reset
		ResetTransform (index);
		ResetColor (index);
	}

	public void ResetTransform(int index)
	{
		int x = index % width;
		int y = -index / width;
		float offsetX = width * -0.5f + 0.5f;
		float offsetY = height * 0.5f - 0.5f;
		Vector3 localPosition = new Vector3 ((float)x + offsetX, (float)y + offsetY, 0.0f);

		Transform objectTransform = m_objectGrid[index].transform;
		objectTransform.SetParent (transform, false);
		objectTransform.localPosition = localPosition;
		objectTransform.localScale = defaultObjectScale;
	}

	public void ResetColor(int index)
	{
		m_objectGrid[index].GetComponent<Renderer>().material.color = colorGrid[index];
	}

	public void ResetGrid()
	{
		int arraySize = numCells;

		for (int i = 0; i < arraySize; ++i)
		{
			if (shapeGrid [i])
			{
				ResetTransform (i);
				ResetColor (i);
			}
		}
	}


	////////////////////////////////////////////////////////////////

	void OnDrawGizmos()
	{
		Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

		bool found = (colorGrid == null);
		int i = 0; 

		while(!found && i < colorGrid.Length)
		{
			if (shapeGrid[i])
				Gizmos.color = colorGrid [i];

			found |= shapeGrid [i];
			++i;
		}

		// avoid z-fighting
		float gizmoThickness = thickness * 0.8f;

		Gizmos.DrawCube(transform.position, new Vector3((float)width, (float)height, gizmoThickness));
	}

}
