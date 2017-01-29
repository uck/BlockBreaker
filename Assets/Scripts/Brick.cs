using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;

	private LevelManager levelManager;
	private int timesHit;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		print("collision");
		timesHit++;

		int maxHit = hitSprites.Length + 1;

		if (timesHit >= maxHit) {
			Destroy(gameObject);
		} 
		else {
			LoadSprites();
		}
	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;

		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}

	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
