using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshGrid))]
[CanEditMultipleObjects]
public class MeshGridEditor : Editor 
{
	private int m_previousWidth;
	private int m_previousHeight;
	private Color m_previousOverrideColor; 

	void OnEnable()
	{
		MeshGrid meshGrid = target as MeshGrid;

		m_previousWidth = meshGrid.width;
		m_previousHeight = meshGrid.height;

		m_previousOverrideColor = Color.green;
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		// grid
		MeshGrid meshGrid = target as MeshGrid;
		UpdateGrid(meshGrid);

		// cell grid
		GUILayout.Space (10);
		GUILayout.Label ("Shape");

		bool modified = false;

		for (int y = 0; y < meshGrid.height; ++y)
		{
			GUILayout.BeginHorizontal();

			for (int x = 0; x < meshGrid.width; ++x)
			{
				int currentElement = x + y * meshGrid.width;
				bool newValue = EditorGUILayout.Toggle (meshGrid.shapeGrid [currentElement]);
				modified |= newValue != meshGrid.shapeGrid [currentElement];
				meshGrid.shapeGrid [currentElement] = newValue;
			}

			GUILayout.EndHorizontal();
		}

		if(modified && Application.isPlaying)
			meshGrid.GenerateGrid();

		// color grid
		GUILayout.Space (10);
		GUILayout.Label ("Mesh Colors");

		for (int y = 0; y < meshGrid.height; ++y)
		{
			GUILayout.BeginHorizontal();
			 
			for (int x = 0; x < meshGrid.width; ++x)
			{
				int currentElement = x + y * meshGrid.width;
				Color newColor = EditorGUILayout.ColorField (meshGrid.colorGrid [currentElement]);

				// update	
				if (meshGrid.shapeGrid [currentElement] && meshGrid.colorGrid [currentElement] != newColor)
				{
					meshGrid.colorGrid [currentElement] = newColor;
                    if (Application.isPlaying)
					    meshGrid.ResetColor (currentElement);
				}
			}

			GUILayout.EndHorizontal();
		}

		// override color
		GUILayout.Space (5);
		GUILayout.Label ("Override Color");
		Color currentColor = EditorGUILayout.ColorField (m_previousOverrideColor);

		if(m_previousOverrideColor !=  currentColor)
		{
			for (int i = 0; i < meshGrid.colorGrid.Length; ++i)
			{
				meshGrid.colorGrid [i] = currentColor;

				if (meshGrid.shapeGrid [i] && Application.isPlaying)
					meshGrid.ResetColor (i);
			}

			m_previousOverrideColor = currentColor;
		}
	}

	void UpdateGrid(MeshGrid meshGrid)
	{
		int arraySize = meshGrid.width * meshGrid.height;

		// Generate new mesh grid
		if(meshGrid.shapeGrid == null || meshGrid.shapeGrid.Length != arraySize)
		{
			bool[] newMeshGrid = new bool[arraySize];
			Color[] newColorGrid = new Color[arraySize];

			// TODO: if resize is performed often would be nice to copy previous array here, but that implies save previus sizes
			meshGrid.shapeGrid = newMeshGrid;
			meshGrid.colorGrid = newColorGrid;
		}
	}
}
	