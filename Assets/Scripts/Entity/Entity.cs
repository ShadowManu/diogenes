using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public enum EntityType {
		spearman,
		infantry,
		rams,
		archers,
		handCannon,
		skirms,
		conquistadors,
		cavalryArchers,
		gunpowder,
		standardBuildings,
		monk,
		siege,
		cavalry,
		ships,
		camels,
		eagles,
		buildings,
		warElephants,
		walls,
		castle,
		turtleShip,
		stoneDefense,
		gaia,
		trees,
		uniqueUnits
	};

public class Entity {
	

	public List<EntityType> entityTypes;
	public GameObject visualRepresentation;
	public float healthPoints;
	public Vector3 position;
	public Vector3 rotation;
	public float lineOfSight;
	public string name;

	public Entity(string n, List<EntityType> t, GameObject vr, float hp, float ls, Vector3 p, Vector3 r) {
		this.visualRepresentation = vr;
		this.healthPoints = hp;
		this.name = n;
		this.entityTypes = t;
		this.lineOfSight = ls;
		this.position = p;
		this.rotation = r;
	}

}
