using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour {
	public GameObject[] availableRooms;
	public List<GameObject> currentRooms;
	private float screenWidthInPoints;

	void Start() {
		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
	}

	void FixedUpdate() {
		GenerateRoomIfRequired();
	}

	void AddRoom(float farthestRoomEndX) {
		int randomRoomIndex = Random.Range(0, availableRooms.Length);
		GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);
		float roomWidth = room.transform.FindChild("floor").localScale.x;
		float roomCenter = farthestRoomEndX + roomWidth / 2.0f;
		room.transform.position = new Vector3(roomCenter, 0, 0);
		currentRooms.Add(room);
	}

	void GenerateRoomIfRequired() {
		List<GameObject> roomToRemove = new List<GameObject>();
		bool addRooms = true;
		float playerX = transform.position.x;
		float removeRoomX = playerX - screenWidthInPoints;
		float addRoomX = playerX + screenWidthInPoints;
		float farthestRoomEndX = 0.0f;

		foreach (var room in currentRooms) {
			float roomWidth = room.transform.FindChild("floor").localScale.x;
			float roomStartX = room.transform.position.x - (roomWidth * 0.5f);
			float roomEndX = roomStartX + roomWidth;

			if (roomStartX > addRoomX) {
				addRooms = false;
			}

			if (roomEndX < removeRoomX) {
				roomToRemove.Add(room);
			}

			farthestRoomEndX = Mathf.Max(farthestRoomEndX, roomEndX);
		}

		foreach (var room in roomToRemove) {
			currentRooms.Remove(room);
			Destroy(room);
		}

		if (addRooms) {
			AddRoom(farthestRoomEndX);
		}
	}
}
