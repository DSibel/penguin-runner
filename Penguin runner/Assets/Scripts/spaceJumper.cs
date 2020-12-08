using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spaceJumper : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    static public int playerScore=0;
     public GameObject cube;
    Vector3 pos;
    public bool isGrounded= false;
    Vector3 jump = new Vector3 (0.0f, 300f, 0.0f);
      public Rigidbody penguinRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreTracker");
        scoreGT =scoreGO.GetComponent<Text>();
        scoreGT.text ="0"; 
    }

    // Update is called once per frame
    void Update()
    {
    
     if (Input.GetKeyDown("space"))
        {Jump();}

 
 
 
        
    }
    void FixedUpdate(){
          
    }


    public void Jump(){
        if(isGrounded){
            isGrounded = false;
            penguinRigidbody.AddForce (jump);
            Rotate(); 
        }
              
    }
    public void Rotate(){
        // how to get object rotation
        Transform transform=cube.transform;
        float rotationX = transform.rotation.x;
        float rotationY = transform.rotation.y;
        float rotationZ = transform.rotation.z;

        
        rotationY =(Random.Range(0,60)-30);
        


    transform.rotation =Quaternion.Euler(rotationX,rotationY,rotationZ);
    } 



    void OnCollisionEnter(Collision coll){
        GameObject collidedWith= coll.gameObject;
        pos= penguinRigidbody.position;
        if (collidedWith.tag =="floor"){
           pos.y =0;
           Debug.Log("penguin hit the floor");
           isGrounded = true;

        }
        else if(collidedWith.tag =="good"){
            Destroy(collidedWith);
             int score = int.Parse(scoreGT.text);

            playerScore += 1;
            scoreGT.text = playerScore.ToString();
        }
           
        else if (collidedWith.tag =="bad"){
            playerScore -= 5;
            Destroy(collidedWith);
            scoreGT.text = playerScore.ToString();
          

       
        //track the  score
        
        } 
         



    





}

}
    


    
    