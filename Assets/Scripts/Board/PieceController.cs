﻿using UnityEngine;
using System.Collections;

public class PieceController : MonoBehaviour {

	public int playerID;

	public GameObject currentTile;
	public GameObject lastTile;

	int cooldown = 0;
	int roll = 0;
	float moveFactor = 0;
	bool checkingBranch = false;

	void Start(){
		transform.position = currentTile.transform.position;
	}

	void FixedUpdate(){
		if(cooldown != 0 && checkingBranch == false){
			cooldown--;
		}

		if(GlobalPlayerManager.GetButton(playerID, "A") && cooldown == 0){
			roll = Random.Range (1, 7);
			moveFactor = 1;
			Debug.Log (roll);

			GameObject actualLastTile = currentTile;
			currentTile= currentTile.GetComponent<TileController>().getTileThatIsnt(lastTile);
			lastTile = actualLastTile;
			checkingBranch = true;


			cooldown = 7;
		}

		if(roll != 0){
			if (moveFactor <= 0) {
				moveFactor = 1;
				roll--;

				if(roll != 0){
					GameObject actualLastTile = currentTile;
					currentTile= currentTile.GetComponent<TileController>().getTileThatIsnt(lastTile);
					lastTile = actualLastTile;
					checkingBranch = true;
				}

			} else {
				moveFactor -= 0.07f;
				transform.position = lastTile.transform.position * (moveFactor) + currentTile.transform.position * (1f - moveFactor);
			}
		}
	}

	void CheckBranch()
	{
		/*
		if (numberof adjacent tiles =3){
			forkdirection.SetActive(true);
			if(GlobalPlayerManager.GetButton(playerID, "A"))
			   ContinueAround();
			else if(GlobalPlayerManager.GetButton(playerID, "B"))
				GoTowardCentre();
			forkDirection.Setactive(false);
			checkingBranch=false
		}*/
	}
}
