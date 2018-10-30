﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LoadTowers : MonoBehaviour {
        public static Sprite amoxSprite;
        public static Sprite methSprite;
        public static Sprite vancSprite;
        public static Sprite carbSprite;
        public static Sprite lineSprite;
        public static Sprite rifaSprite;
        public static Sprite isonSprite;
        public static GameObject projectile;

        public int showTowers;

        public Button navUp;
        public Button navDown;

        private bool scrolling;
        private float destination;

        private Vector2 movement;
        private IDictionary<int, Vector2> scrollCoordinates;
    public static IDictionary<string, object> amoxProjectile = new Dictionary<string, object>(){
                                {"name", "Amoxicillin"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 2.75f},
                                {"antibioticType", "amox"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 10},
								{"type",2},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", amoxSprite},
                                {"towerColor", Color.green},
                                {"projectileSprite", projectile},
                                };

    public static IDictionary<string, object> methProjectile = new Dictionary<string, object>(){
                                {"name", "Methicillin"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 1.75f},
                                {"antibioticType", "meth"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 15},
								{"type",1},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", methSprite},
                                {"towerColor", (Color)(new Color32(80, 80, 255, 255))},
                                {"projectileSprite", projectile} };

    public static IDictionary<string, object> vancProjectile = new Dictionary<string, object>(){
                                {"name", "Vancocymin"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 0.75f},
                                {"antibioticType", "vanc"},
                                {"towerType", 0},
                                {"targetType", 0},
                                {"cost", 20},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", vancSprite},
                                {"towerColor", (Color)(new Color32(155, 0, 250, 255))},
                                {"projectileSprite", projectile},
                                 };

    public static IDictionary<string, object> carbProjectile = new Dictionary<string, object>(){
                                {"name", "Carbapenem"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", -0.25f},
                                {"antibioticType", "carb"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 30},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", carbSprite},
                                {"towerColor", (Color)(new Color32(255, 65, 0, 255))},
                                {"projectileSprite", projectile},
                                };

    public static IDictionary<string, object> lineProjectile = new Dictionary<string, object>(){
                                {"name", "Linezolid"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", -1.25f},
                                {"antibioticType", "line"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 40},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", lineSprite},
                                {"towerColor", Color.red},
                                {"projectileSprite", projectile},
                                };

    public static IDictionary<string, object> rifaProjectile = new Dictionary<string, object>(){
                                {"name", "Rifampicin"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", -2.25f},
                                {"antibioticType", "rifa"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 30},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", rifaSprite},
                                {"towerColor", (Color)(new Color32(9, 9, 200, 255))},
                                {"projectileSprite", projectile},
                                 };

    public static IDictionary<string, object> isonProjectile = new Dictionary<string, object>(){
                                {"name", "Isoniazid"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", -3.25f},
                                {"antibioticType", "ison"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 30},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", isonSprite},
                                {"towerColor", (Color)(new Color32(200, 9, 9, 255))},
                                {"projectileSprite", projectile},
                                 };

public static IDictionary<string, object> amoxHitscan = new Dictionary<string, object>(){
                                {"name", "AmoxHitscan"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 3.75f},
                                {"antibioticType", "amox"},
                                {"towerType", 1},
                                {"targetType", 0}, 
                                {"cost", 10},
                                {"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", amoxSprite},
                                {"towerColor", Color.green},
                                {"projectileSprite", projectile},
                                };

public static IDictionary<string, object> methHitscan = new Dictionary<string, object>(){
                                {"name", "MethHitscan"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 4.75f},
                                {"antibioticType", "meth"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 15},
								{"type",1},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", methSprite},
                                {"towerColor", (Color)(new Color32(80, 80, 255, 255))},
                                {"projectileSprite", projectile} };

 public static IDictionary<string, object> vancHitscan = new Dictionary<string, object>(){
                                {"name", "VancHitscan"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 5.75f},
                                {"antibioticType", "vanc"},
                                {"towerType", 0},
                                {"targetType", 0},
                                {"cost", 20},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", vancSprite},
                                {"towerColor", (Color)(new Color32(155, 0, 250, 255))},
                                {"projectileSprite", projectile},
                                 };

 public static IDictionary<string, object> carbHitscan = new Dictionary<string, object>(){
                                {"name", "CarbHitscan"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 6.75f},
                                {"antibioticType", "carb"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 30},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", carbSprite},
                                {"towerColor", (Color)(new Color32(255, 65, 0, 255))},
                                {"projectileSprite", projectile},
                                };

 public static IDictionary<string, object> lineHitscan = new Dictionary<string, object>(){
                                {"name", "LineHitscan"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 7.75f},
                                {"antibioticType", "line"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 40},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", lineSprite},
                                {"towerColor", Color.red},
                                {"projectileSprite", projectile},
                                };

    public static IDictionary<string, object> rifaHitscan = new Dictionary<string, object>(){
                                {"name", "RifaHitscan"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 8.75f},
                                {"antibioticType", "rifa"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 30},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", rifaSprite},
                                {"towerColor", (Color)(new Color32(9, 9, 200, 255))},
                                {"projectileSprite", projectile},
                                 };

    public static IDictionary<string, object> isonHitscan = new Dictionary<string, object>(){
                                {"name", "IsonHitscan"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 9.75f},
                                {"antibioticType", "ison"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 30},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", isonSprite},
                                {"towerColor", (Color)(new Color32(200, 9, 9, 255))},
                                {"projectileSprite", projectile},
                                 };

public static IDictionary<string, object> amoxAOE = new Dictionary<string, object>(){
                                {"name", "AmoxAOE"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 10.75f},
                                {"antibioticType", "amox"},
                                {"towerType", 1},
                                {"targetType", 0}, 
                                {"cost", 10},
                                {"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", amoxSprite},
                                {"towerColor", Color.green},
                                {"projectileSprite", projectile},
                                };

public static IDictionary<string, object> methAOE = new Dictionary<string, object>(){
                                {"name", "MethAOE"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 11.75f},
                                {"antibioticType", "meth"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 15},
								{"type",1},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", methSprite},
                                {"towerColor", (Color)(new Color32(80, 80, 255, 255))},
                                {"projectileSprite", projectile} };

 public static IDictionary<string, object> vancAOE = new Dictionary<string, object>(){
                                {"name", "VancAOE"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 12.75f},
                                {"antibioticType", "vanc"},
                                {"towerType", 0},
                                {"targetType", 0},
                                {"cost", 20},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", vancSprite},
                                {"towerColor", (Color)(new Color32(155, 0, 250, 255))},
                                {"projectileSprite", projectile} };

 public static IDictionary<string, object> carbAOE = new Dictionary<string, object>(){
                                {"name", "CarbAOE"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 13.75f},
                                {"antibioticType", "carb"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 30},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", carbSprite},
                                {"towerColor", (Color)(new Color32(255, 65, 0, 255))},
                                {"projectileSprite", projectile} };

 public static IDictionary<string, object> lineAOE = new Dictionary<string, object>(){
                                {"name", "LineAOE"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 14.75f},
                                {"antibioticType", "line"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 40},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", lineSprite},
                                {"towerColor", Color.red},
                                {"projectileSprite", projectile} };

    public static IDictionary<string, object> rifaAOE = new Dictionary<string, object>(){
                                {"name", "RifaAOE"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 15.75f},
                                {"antibioticType", "rifa"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 30},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", rifaSprite},
                                {"towerColor", (Color)(new Color32(9, 9, 200, 255))},
                                {"projectileSprite", projectile} };

    public static IDictionary<string, object> isonAOE = new Dictionary<string, object>(){
                                {"name", "IsonAOE"},
                                {"towerPositionX", 8f},
                                {"towerPositionY", 16.75f},
                                {"antibioticType", "ison"},
                                {"towerType", 0},
                                {"targetType", 0}, 
                                {"cost", 30},
								{"type",0},
                                {"radius", 4f},
                                {"cooldown", 30.0f},
                                {"towerSprite", isonSprite},
                                {"towerColor", (Color)(new Color32(200, 9, 9, 255))},
                                {"projectileSprite", projectile} };

    public IDictionary<string, IDictionary<string, object>> towers = new Dictionary<string, IDictionary<string, object>>(){
                                {"Amoxicillin", amoxProjectile},
                                {"Methicillin", methProjectile},
                                {"Vancocymin", vancProjectile},
                                {"Carbapenem", carbProjectile},
                                {"Linezolid", lineProjectile},
                                {"Rifampicin", rifaProjectile},
                                {"Isoniazid", isonProjectile},
                                {"AmoxHitscan", amoxHitscan},
                                {"MethHitscan", methHitscan},
                                {"VancHitscan", vancHitscan},
                                {"CarbHitscan", carbHitscan},
                                {"LineHitscan", lineHitscan},
                                {"RifaHitscan", rifaHitscan},
                                {"IsonHitscan", isonHitscan},
                                {"AmoxAOE", amoxAOE},
                                {"MethAOE", methAOE},
                                {"VancAOE", vancAOE},
                                {"CarbAOE", carbAOE},
                                {"LineAOE", lineAOE},
                                {"RifaAOE", rifaAOE},
                                {"IsonAOE", isonAOE} };

/* 
    private static IDictionary<string, object> pellet = new Dictionary<string, object>() {
                                {"additionalCost", 0},
                                {"radius", 4f},
                                {"cooldown", 30.0f}, };
                                */

 // USE ADDITIONAL DICTIONARIES BASED ON TOWER TYPE TO ADJUST VALUES BEING SET
    private GameObject tower;

    private __app appTowers;

    // Use this for initialization
    void Start() {
        appTowers = GameObject.Find("__app").GetComponent<__app>();
        tower = Resources.Load("Prefabs/Tower") as GameObject;

        //Load the towers sprites, and assign them to their spots in the dictionaries
        towers["Amoxicillin"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["Methicillin"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["Vancocymin"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["Carbapenem"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["Linezolid"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["Rifampicin"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["Isoniazid"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["AmoxHitscan"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["MethHitscan"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["VancHitscan"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["CarbHitscan"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["LineHitscan"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["RifaHitscan"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["IsonHitscan"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["AmoxAOE"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["MethAOE"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["VancAOE"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["CarbAOE"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["LineAOE"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["RifaAOE"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
        towers["IsonAOE"]["towerSprite"] = Resources.Load<Sprite>("Sprites/Towers/tower") as Sprite;
       

        projectile = Resources.Load("Prefabs/Projectile") as GameObject;

        showTowers = 0;
        destination = 6;
        scrolling = false;
        LoadAllTowers();

        movement = new Vector2(0,0);

        scrollCoordinates =  new Dictionary<int, Vector2>() {
							{0, new Vector2(0f, 6.02f)},
							{1, new Vector2(0f, -0.9f)},
							{2, new Vector2(0f, -7.9f)} };
    }

    // Update is called once per frame
    void Update() {
        if(scrolling) {
            scrollTowers(destination);        
        }
    }

    //Reloads towers, called by the DragAndDrop script attached to individual towers
    public void reloadTower(string towerName, Vector3 relativePosition) {
      
        IDictionary <string, object> towerAttributes;
        towerAttributes = towers[towerName];

        GameObject newTower = setTowerAttributes(towerAttributes);

        newTower.transform.position = relativePosition;
        Instantiate(newTower, gameObject.transform, true);
    }

    //Loads the first column of towers on start, will load the displayed column
    void LoadAllTowers() {
        foreach (KeyValuePair<string, IDictionary<string, object>> tow in towers) {    
                  GameObject newTower = setTowerAttributes(tow.Value);
                  Instantiate(newTower, gameObject.transform, true);                 
        }
    }

    //Set the towers attributes before spawning to the menu
    GameObject setTowerAttributes(IDictionary<string, object> attributes) {

        GameObject t = tower;
        Tower tScript = tower.GetComponent<Tower>();

        tScript.towerName = (string) attributes["name"];
        tScript.antibioticType = (string) attributes["antibioticType"];
        tScript.type = (int) attributes["towerType"];
        tScript.targetType = (int) attributes["targetType"]; 
        tScript.cost = (int) attributes["cost"];
		tScript.type = (int) attributes["type"];
        tScript.detectionRadius = (float)attributes["radius"];
        tScript.coolDown = (float)attributes["cooldown"];
        //tScript.specialEffect = (int) attributes["specialEffect"];
        t.GetComponent<SpriteRenderer>().sprite = (Sprite) attributes["towerSprite"];
        t.GetComponent<SpriteRenderer>().color = (Color) attributes["towerColor"];
        tScript.projectileSprite = null;

        float xPos =  (float) attributes["towerPositionX"];
        float yPos =  (float) attributes["towerPositionY"] - movement.y;

        tScript.transform.position = new Vector3(xPos, yPos, -2f);

        tScript.tag = "MenuItems";

        return t;
    }

    public void ShowTowerColumn(int step) {
        showTowers += step;
        Debug.Log(gameObject.transform.position.y);

        movement = scrollCoordinates[showTowers];

        scrolling = true;

        if(showTowers == 0){
             navUp.interactable = false;
        } else {
             navUp.interactable = true;
        }
        if(showTowers == 2){
              navDown.interactable = false;
        } else {
            navDown.interactable = true;
        }
    }

    void scrollTowers(float y) {
        
        Vector3 position = transform.position;
        Debug.Log(position);

        Vector2 dest = scrollCoordinates[showTowers];
		float dy = dest.y - position.y;
		position.y += dy * 0.1f;
		transform.position = position;

        if (Math.Abs(dy) < .02) {
				scrolling = false;
			}
    }
}