using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Director : MonoBehaviour {
    public GameObject [] prefab;
    
    public float maxDistFromParent = 2f;
    public float[] rotationValues;

    public OscInterface oscInterface;


    // on va maintenir nous même une liste de tous les éléments créés
    // "List<>" c'est comme un tableau[], mais dynamique (sa taille peut changer à tout moment)
    private List<GameObject> allKids;
    
    // Start
    void Start() {
        //on initialise la liste
        allKids = new List<GameObject>();
       
        //on ajoute un premier élément, à la position du Director
        AddTo(gameObject);
        oscInterface = GameObject.Find("Osc").GetComponent<OscInterface>();
    }

   
    // Update
    void Update()
    {
        if (oscInterface.IsCapacitiveTouched() || Input.GetKey("space")) {
            Grow();
           
            

        }
        else {
            Shrink();
        }
        
    }

    // c'est le script qui étend la ville
    void Grow() {
        // si on a déjà 3000 éléments, on n'en crée pas de nouveaux
        if (allKids.Count < 3000) {
            
            // on crée un nombre aléatoire de nouveaux éléments
            int numNewKids = Random.Range(1, 2);
            for (int i = 0; i < numNewKids; i++) {
                
                // kidID pour avoir un élément aléatoire dans la liste
                int kidID = Random.Range(0, allKids.Count);
                
                // c'est une sécurité pour le while plus bas (pas idéal, mais en attendant)
                int attempts = 20;

                /*
                 * donc on va prendre un élément aléatoire parmis les éléments créés
                 * à condition que l'élément ne contienne pas plus de 5 enfants.
                 * Si notre élément aléatoire a déjà 5 enfants, on en cherche un nouveau
                 * jusqu'à le trouver.
                 * "Jusqu'à le trouver" c'est dangereux s'il n'en reste pas, on serait dans une boucle infinie
                 * donc ma sécurité un peu foireuse c'est de limiter le nombre de tentatives.
                 * Si après 20 tentatives on trouve rien, on sort du while et on arrête (break, casse le "for")
                 */
                while (allKids[kidID].transform.childCount >= 5 && attempts > 0) {
                    // nouvel ID aléatoire
                    kidID = Random.Range(0, allKids.Count);
                    // décompte une tentative
                    attempts--;
                }

                if (attempts <= 0) break;
                
                // si l'élément répond aux conditions, on lui ajoute un enfant
                AddTo(allKids[kidID]);
               
                
            }
        }
        
    }
    
    // c'est le script qui réduit la ville
    void Shrink() {
        // uniquement s'il reste plus que 1 enfant (comme ça on garde la base)
        if (allKids.Count > 1) {
            
            // on va supprimer un nombre aléatoire d'éléments
            int numKids = Random.Range(5, 10);
            for (int i = 0; i < numKids; i++) {
                
                //même logique que Grow()
                int kidID = Random.Range(0, allKids.Count);
                int attempts = 20;

                while (allKids[kidID].transform.childCount > 0 && attempts > 0) {
                    kidID = Random.Range(0, allKids.Count);
                    attempts--;
                  
                   
                }

                if (attempts <= 0) break;
                
                // on supprime le GameObject référencé dans la liste allKids
                Destroy(allKids[kidID]);
                // puis on supprime la référence dans la liste
                allKids.RemoveAt(kidID);
                
                /* On doit faire les 2 opérations
                 * Juste "Destroy", il resterait un NullPointer dans la case du tableau
                 * Juste "RemoveAt", le GameObject existerait toujours, mais sans moyen de l'atteindre
                 */
            }
        }
    }

    // ajouter un enfant à un élément
    void AddTo(GameObject thatKid) {
        // j'ai fait ça pour l'instant : l'enfant est dans un périmètre autour du parent
        Vector2 randomCircle = Random.insideUnitCircle.normalized * maxDistFromParent;
        Vector3 kidPos = thatKid.transform.position + new Vector3(randomCircle.x, 0, randomCircle.y);
        
        // rotation aléatoire
        Quaternion kidRot= Quaternion.Euler(0, rotationValues[Random.Range(0, rotationValues.Length)],0);

       GameObject newObject = Instantiate(
            prefab [UnityEngine.Random.Range(0, 3)], // ce qu'on instantie
            kidPos, // la position
            kidRot, // une rotation 
            thatKid.transform); // le parent
        
        // on lui donne un nom unique (chaque game object a une "instance ID" unique, donc on inclut ça)
        newObject.name = "Kid " + newObject.GetInstanceID().ToString();
        
        // on ajoute le gameobjet créé dans la List<> aka le tableau dynamique
        allKids.Add(newObject);
        
    }
    
    
}
