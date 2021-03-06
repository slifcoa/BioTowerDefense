﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class __app : MonoBehaviour {

	private Options options;
	private Screenshake screenshake;
	private particleManager particles;
	private string level;
	public static float ellipseYMult = .43f;
	public static float towerShadowYOffset = -0.36f;

	// BALANCE VARIABLES
	public static int baseCurrency = 60;
	public static int baseCurrencyPerKill = 2; 
	public static int baseDamage = 50;
	public static int maxAmmo = 30;
	public static float spawnInterval = 1.2f;
   	public const float mutationIncrement = 0.05f;
	public static float reloadCostDiv = 2f;


	// COLOR
	public static Color amoxColor = Color.green;
	public static Color methColor = (Color)(new Color32(80, 80, 255, 255));
	public static Color vancColor = (Color)(new Color32(155, 0, 205, 255));
	public static Color carbColor = (Color)(new Color32(255, 60, 0, 255));
	public static Color lineColor = Color.red;
	public static Color rifaColor = (Color)(new Color32(205, 205, 205, 255));
	public static Color isonColor = (Color)(new Color32(85, 85, 85, 255));

	public static IDictionary<string, Color> colors = new Dictionary<string, Color>() { 
					{"amox", amoxColor},
					{"meth", methColor},
					{"vanc", vancColor},
					{"carb", carbColor},
					{"line", lineColor},
					{"rifa", rifaColor},
					{"ison", isonColor} };

	public static IDictionary<string, bool> logbook = new Dictionary<string, bool>() { 
		//Enemies
		{"strep",false},
		{"staph",false},
		{"pneu",false},
		{"TB",false},
		//Towers
		{"amox", false},
		{"meth", false},
		{"vanc", false},
		{"carb", false},
		{"line", false},
		{"rifa", false},
		{"ison", false},
		//Levels
		{"heart",false},
		{"lungs",false},
		//Extras
		{"prof",false}
	};
	public static IDictionary<string, int> logbookChances = new Dictionary<string, int>() { 
		//Enemies
		{"strep",20},
		{"staph",20},
		{"pneu",20},
		{"TB",20},
		//Towers
		{"amox", 100},
		{"meth", 100},
		{"vanc", 100},
		{"carb", 100},
		{"line", 100},
		{"rifa", 100},
		{"ison", 100},
		//Levels
		{"heart",100},
		{"lungs",100},
		//Extras
		{"prof",100}
	};
					
        // Dictionaries are arranged in order of effectiveness up to carb (1-5)
    // Linezolid is its own category, rifampicin and isoniazid are their own category.
private static IDictionary<string, float> amox = new Dictionary<string, float>() { // amoxicillin
					{"staph", 1f},
					{"strep", 1f},
					{"pneu", .4f},
					{"TB", 0f} };
private static IDictionary<string, float> meth = new Dictionary<string, float>() { // methicillin
					{"staph", 1f},
					{"strep", 1f},
					{"pneu", .4f},
					{"TB", 0f} };
private static IDictionary<string, float> vanc = new Dictionary<string, float>() { // vancomycin
					{"staph", 1f},
					{"strep", 1f},
					{"pneu", .4f},
					{"TB", 0f} };
private static IDictionary<string, float> carb = new Dictionary<string, float>() { // carbapenem
					{"staph", 1f},
					{"strep", 1f},
					{"pneu", 1f}, // best. If resistant, 1, 2, 3 useless.
					{"TB", 0f} };
private static IDictionary<string, float> line = new Dictionary<string, float>() { // linezolid
					{"staph", 1f},
					{"strep", 1f},
					{"pneu", .9f}, // second best
					{"TB", 0f} }; // 0-3 slider?
private static IDictionary<string, float> rifa = new Dictionary<string, float>() { // rifampicin
					{"staph", .1f},
					{"strep", .1f},
					{"pneu", .1f},
					{"TB", .5f} }; // Used in conjunction with isoniazid
private static IDictionary<string, float> ison = new Dictionary<string, float>() { // isoniazid
					{"staph", .1f},
					{"strep", .1f},
					{"pneu", .1f},
					{"TB", .5f} };                                                                                

public static IDictionary<string, IDictionary<string, float>> antibiotics = new Dictionary<string, IDictionary<string, float>>() {
					{"amox", amox},
					{"meth", meth},
					{"vanc", vanc},
					{"carb", carb},
					{"line", line},
					{"rifa", rifa},
					{"ison", ison} };

public static IDictionary<string, float> mutationChances =
				new Dictionary<string, float>() {
					{"amox", 0f},
					{"meth", 0f},
					{"vanc", 0f},
					{"carb", 0f},
					{"line", 0f},
					{"rifa", 0f},
					{"ison", 0f} };

	mutationBars mbScript;
	void Awake () {
		options = new Options();
		screenshake = new Screenshake();
		particles = new particleManager();
		level = "doi";
	}

	
	void Update () {
		screenshake.Update();
	}
	
	public void setLevel(string lvl){
		level = lvl;
		//Debug.Log("LEVEL SET!!!"+level);
	}

	public string getLevel(){
		//Debug.Log("RETURNING!!!"+level);
		return level;
	}

	public void increaseMutationChanceForAntibiotic(string antibioticType, float mult=1f) {
		mutationChances[antibioticType] += mutationIncrement * mult;

		mbScript.updateBars();
		print("Increasing mutation chances for " + antibioticType + " by " + mutationIncrement * mult);
	}

	public void lowerAllChances(float percent) {
		List<string> antibiotics = new List<string> (mutationChances.Keys);
		foreach (string antibiotic in antibiotics) {
			mutationChances[antibiotic] *= percent;
		}
    }

	public void giveMutationBarsScript(mutationBars mb) {
		mbScript = mb;
	}
	
	public bool getMusic(){
		return options.getMusic();
	}
	
	public void setMusic(bool mus){
		options.setMusic(mus);
		GetComponent<MusicPlayer>().updatePlay();
	}
	
	public bool getSFX(){
		return options.getSFX();
	}
	
	public void setSFX(bool s){
		options.setSFX(s);
	}
	
	public bool getScreenshake(){
		return options.getScreenshake();
	}
	
	public void setScreenshake(bool ss){
		options.setScreenshake(ss);
	}
	
	public void newParticles(Vector3 pos, int count, float spd, Color col){
		particles.newParticles(pos,count,spd,col);
	}

	public void explode(Vector3 pos, int count, float spd, Color col){
		particles.explode(pos,count,spd,col);
	}
	
	private class Options {
		private bool music;
		private bool sfx;
		private bool screenshake;
		
		public Options(){
			music = false;
			sfx = true;
			print("Music: "+music);
			print("SFX: "+sfx);
		}
		
		public bool getMusic(){
			return music;
		}
		
		public void setMusic(bool mus){
			music = mus;
		}
		public bool getSFX(){
			return sfx;
		}
		
		public void setSFX(bool s){
			sfx = s;
		}
		
		public bool getScreenshake(){
			return screenshake;
		}
		
		public void setScreenshake(bool ss){
			screenshake = ss;
		}
	}
	
	public void newScreenshake(int t, float mag){
		screenshake.newScreenshake(t,mag);
	}
	
	public bool isScreenshaking(){
			return screenshake.isScreenshaking();
	}
	
	public float getXOffset(){
		return screenshake.getXOffset();
	}
	
	public float getYOffset(){
		return screenshake.getYOffset();
	}
	
	private class Screenshake {
		private int time;
		private float magnitude;
		
		public Screenshake(){
			time = 0;
			magnitude = 0f;
		}
		
		public void newScreenshake(int t, float mag){
			time = t;
			magnitude = mag;
		}
		
		public void Update(){
			time--;
		}
		
		public bool isScreenshaking(){
			return time>0;
		}
		
		public float getXOffset(){
			return Random.Range(-magnitude,magnitude);
		}
		
		public float getYOffset(){
			return Random.Range(-magnitude,magnitude);
		}
	}
	
	private class particleManager {
		private int maxParticles;
		private GameObject particle;
		
		public particleManager() {
			particle = Resources.Load("Prefabs/Particle") as GameObject;
		}
		
		public void newParticles(Vector3 pos, int count, float spd, Color col){
			for (int i = 0; i < count; i++) {
				GameObject part = Instantiate(particle);
				part.transform.position = pos;
				part.GetComponent<SpriteRenderer>().color = col;
				part.GetComponent<Particle>().setVelocity(spd);
			}
		}

		public void explode(Vector3 pos, int count, float spd, Color col) {
			for (int i = 0; i < count; i++) {
				GameObject part = Instantiate(particle);
				part.transform.position = pos;
				part.GetComponent<SpriteRenderer>().color = col;
				part.GetComponent<Particle>().explode(spd);
			}
		}
	}
}