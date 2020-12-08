using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class JumperAgent : Agent
{
    [Header("Set Dynamically")]
    [SerializeField] private KeyCode jumpKey;
     private int AgentScore=0;
     public GameObject cube;
    static public int highScore;
    Vector3 pos;
    public bool isGrounded= true;
    private Vector3 startingPosition;
    Vector3 jump = new Vector3 (0.0f, 300f, 0.0f);
    Rigidbody rBody;
    // Start is called before the first frame update
    public event Action OnReset;
    public GameObject agentPlatform;
    public GameObject agentArena;
    GameObject[] gos;
    
public override void Initialize(){
    rBody=GetComponent<Rigidbody>();
    startingPosition = rBody.transform.position;
   
    
     }
     

public override void OnEpisodeBegin(){
           Reset();
}
public override void OnActionReceived(float[] vectorAction){
    //1 action jump or not jump
    if(Mathf.FloorToInt(vectorAction[0]) == 1)
    {Jump();
    }    }
public override void Heuristic(float[] actionsOut){
    
    actionsOut[0]=0;
 if (Input.GetKey(jumpKey)){
     actionsOut[0]=1;
}
}
/* public override void CollectObservations(VectorSensor sensor){

    //target and agent positions
       GameObject[] goodorb = GameObject.FindGameObjectsWithTag("good");
            foreach (GameObject pTemp in goodorb) {
                sensor.AddObservation(pTemp.transform.localPosition);
            }
               GameObject[] badorb = GameObject.FindGameObjectsWithTag("bad");
            foreach (GameObject pTemp in badorb) {
                sensor.AddObservation(pTemp.transform.localPosition);
            }
    sensor.AddObservation(this.transform.localPosition);
    sensor.AddObservation(rBody.velocity.y);
    sensor.AddObservation(isGrounded);    

} */


 private void Jump(){
        if(isGrounded){
           
            isGrounded = false;
            rBody.AddForce (jump);
            //Rotate(); 
        }
              
    }
    /* private void Rotate(){
        Debug.Log("rotateCalled");
        Transform transform=this.transform;
        float rotationX = transform.rotation.x;
        float rotationY = transform.rotation.y;
        float rotationZ = transform.rotation.z;

        
        rotationY =(UnityEngine.Random.Range(0,60)-30);
        


    transform.rotation =Quaternion.Euler(rotationX,rotationY,rotationZ);
    }  */
   

    void OnCollisionEnter(Collision coll){
        GameObject collidedWith= coll.gameObject;
        pos= rBody.position;
        if (collidedWith.tag =="floor"){
           pos.y =0;
           
           isGrounded = true;

        }
        else if(collidedWith.tag =="good"){
            Destroy(collidedWith);
             

            AgentScore += 1;
            AddReward(1f);
            Debug.Log(AgentScore);
        }
           
        else if (collidedWith.tag =="bad"){
            AgentScore += -5;
            
            Destroy(collidedWith);
            AddReward(-5f);
             Debug.Log(AgentScore);
        
            
       
        //track the  score
        
        } }
     private void Reset(){
      
           if(AgentScore>highScore){
               highScore = AgentScore;
           }
        AgentScore = 0;
             Debug.Log("CAlls Reset- Highscore: "+ highScore);

       /*  gos = GameObject.FindGameObjectsWithTag("floor");
        foreach(GameObject go in gos ){
            Destroy(go);
        } */


 
        
        foreach (Transform child in agentPlatform.transform)
{
             if((child.gameObject.tag=="floor")){Destroy(child.gameObject);}
            
}           foreach (Transform child in agentArena.transform)
{
             if((child.gameObject.tag=="agentplat")){Destroy(child.gameObject);}}
            
          Vector3  oldLocation =agentArena.transform.position;
         /* gos = GameObject.FindGameObjectsWithTag("agentplat");
        foreach(GameObject go in gos ){
            Destroy(go);
        } */ 
                 

        
        GameObject plat =Instantiate<GameObject>(agentPlatform);
        plat.transform.SetParent(this.transform.parent);
            plat.transform.position = oldLocation;
        //Reset Movement and Position
        transform.position = startingPosition;
        rBody.velocity = Vector3.zero;
        
        OnReset?.Invoke();
    }



 //GameObject orb = Instantiate<GameObject>(bSpherePrefab);





    }

     
