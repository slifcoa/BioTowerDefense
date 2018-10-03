﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	private int projectileType = 0;//0 = Pellet, 1 = Laser, 2 = AOE
	private float projectileSize = 0f;
	private float projectileSpeed = 0f;
	private float projectileAOE = 0f;
	private bool projectilePierce;
	private int specialEffect = 0;//0 = none, 1 = slow, 2 = increase damage taken, etc.
	private GameObject tower;
	private float xsp = 0;
	private float ysp = 0;
	private List<GameObject> hurtEnemies;
	// Use this for initialization
	void Start () {
		hurtEnemies = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		//Move
		transform.position = new Vector3(transform.position.x + xsp, transform.position.y + ysp,transform.position.z);
	}
	
	public void setVals(int pType, float pSize, float pSpeed, float pAOE, bool pPierce, int pSpec, GameObject pTow, float pXsp, float pYsp){
		projectileType = pType;
		projectileSize = pSize;
		projectileSpeed = pSpeed;
		projectileAOE = pAOE;
		projectilePierce = pPierce;
		specialEffect = pSpec;
		GameObject tower = pTow;
		xsp = pXsp;
		ysp = pYsp;
		transform.localScale  = new Vector3(projectileSize,projectileSize,projectileSize);
	}
	
	void OnTriggerEnter2D(Collider2D col){	
		Debug.Log("YEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEasdfasdfasdf");
		var obj = col.gameObject;
		if(obj.tag=="Enemy" && !hurtEnemies.Contains(obj)){
			Debug.Log("ASFDWASFSDFSDFSDF");
			hurtEnemies.Add(obj);
			Destroy(obj);
			//obj.GetComponent<Enemy>().speed-=2;
			if(!projectilePierce){
				Destroy(gameObject);
			}
		}	
	}
}
