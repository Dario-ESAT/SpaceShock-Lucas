using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableArea : MonoBehaviour {

	public float border = 2.0f;
	public float thickness = 8.0f;
	public Camera cameraReference;
	public Transform mainPlayer;
	public bool edgesTeleport = false;

	void OnTriggerExit(Collider other)
	{
		GameObject otherGameObject = other.gameObject;

		if(otherGameObject != mainPlayer.gameObject)
			Destroy(otherGameObject);
	}

	void Update()
	{
		// WARNING
		// weak method as it only works if Playable area is aligned to the camera;

		// calculate area size
		float far = transform.position.z - cameraReference.transform.position.z;

		Vector3 leftTopPos = cameraReference.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, far));
		Vector3 rightDownPos = cameraReference.ScreenToWorldPoint(new Vector3((float)cameraReference.pixelWidth, (float)cameraReference.pixelHeight, far));

		Vector3 areaSize = rightDownPos - leftTopPos;

		// scale area
		transform.localScale = new Vector3(areaSize.x, areaSize.y, thickness);

		// maintain player on screen
		if (edgesTeleport)
		{
			Vector3 playerPos = mainPlayer.transform.position;
			float playerPosX = leftTopPos.x + ((playerPos.x - leftTopPos.x + areaSize.x) % areaSize.x);
			float playerPosY = leftTopPos.y + ((playerPos.y - leftTopPos.y + areaSize.y) % areaSize.y);
			mainPlayer.transform.position = new Vector3 (playerPosX, playerPosY, playerPos.z);
		}
		else 
		{
			Vector3 playerPos = mainPlayer.transform.position;
			float playerPosX = Mathf.Clamp (playerPos.x, leftTopPos.x, rightDownPos.x);
			float playerPosY = Mathf.Clamp (playerPos.y, leftTopPos.y, rightDownPos.y);
			mainPlayer.transform.position = new Vector3 (playerPosX, playerPosY, playerPos.z);
		}

	}
}
