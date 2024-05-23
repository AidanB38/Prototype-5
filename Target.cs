using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private GameManager gameManger;
    public int pointValue;
    public ParticleSystem explosionParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(Vector3.up * Random.Range(12,16), ForceMode.Impulse);
        targetRB.AddTorque(Random.Range(-10,10), Random.Range(-10,10),
        Random.Range(-10,10), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4,4), -6);
        gameManger = GameObject.Find("Game Manager").GetComponent<GameManager>();
    
    }

    Vector3 RandomForce(){
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    
    }
    
    float RandomTorque(){
        return Random.Range(-maxTorque, maxTorque);
    
    }
    
    Vector3 RandomSpawnPos(){
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    
    private void OnMouseDown(){
        if(gameManger.isGameActive){
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManger.UpdateScore(pointValue);
        }
        
        
    }

    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")){
            gameManger.GameOver();
        }
    }

}
