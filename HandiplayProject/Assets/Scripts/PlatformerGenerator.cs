﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

	private float plateformWidth;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public ObjectPooler theObjectPool;


	// Use this for initialization
	void Start () {
		
		plateformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x; // Récupère la taille de la plateforme

	} //fin du Start
	
	// Update is called once per frame
	void FixedUpdate () {
		
		// Si la position x du générateur est inférieur à generationPoint...
		if (transform.position.x < generationPoint.position.x){

			// La distance entre les plateformes générées est aléatoire
			distanceBetween = Random.Range (distanceBetweenMin,distanceBetweenMax);

			// Déplacer le générateur, à partir de sa position, de la largeur de la plateforme + la distance entre les plateformes
			transform.position = new Vector3(transform.position.x + plateformWidth + distanceBetween,transform.position.y,transform.position.z);

			GameObject newPlateform = theObjectPool.GetPooledObject();
			newPlateform.transform.position = transform.position;
			newPlateform.transform.rotation = transform.rotation;
			newPlateform.SetActive(true);
		} // fin du IF

	} // fin du FixedUpdate

} // fin de la classe
