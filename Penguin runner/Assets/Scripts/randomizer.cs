using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizer : MonoBehaviour
{
      
    
    public GameObject bSpherePrefab;
    public GameObject gSpherePrefab;
    // Start is called before the first frame update
    void Start()
    {
         CreateSpheres();

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

   void CreateSpheres(){
       for(int i =0; i<10;i++){
           float height = Random.Range(1f,4f);
            int v = Random.Range(0, 100);
            int roll = v;
              //roll for red or green
            if(roll>70){
                    GameObject orb = Instantiate<GameObject>(bSpherePrefab);
                      orb.transform.SetParent(this.transform); 
                     
                    orb.transform.position =this.transform.position+ new Vector3((i*2)-10,height,0);
           }
            else if(roll>20){
                 GameObject orb = Instantiate<GameObject>(gSpherePrefab);
                 
                  orb.transform.SetParent(this.transform);
                 orb.transform.position =this.transform.position+ new Vector3((i*2)-10,height,0);
           }else{}; 
            // skip orb spawn


       }

    }


}
