using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DayNightTilemapManager : MonoBehaviour {

	public Tilemap dayNightMap;
	public Tilemap backgroundMap;
	public Tile dayNightTile;

	// Use this for initialization
	void Start () {
		dayNightMap.origin = backgroundMap.origin;
		dayNightMap.size = backgroundMap.size;

		foreach (Vector3Int p in dayNightMap.cellBounds.allPositionsWithin) {
			dayNightMap.SetTile (p, dayNightTile);
		}
	}
}
