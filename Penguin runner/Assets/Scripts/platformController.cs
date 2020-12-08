
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject randomSegment;
    float max =0;
    GameObject[] gos;
    void Start()
    {
         gos = GameObject.FindGameObjectsWithTag("floor");
    }

    // Update is called once per frame
    void Update()
    {
        CheckDestroy();
        
        
    }
     public void NewSegment(){
        Debug.Log("NewSegment method");
        GameObject seg = Instantiate<GameObject>(randomSegment);
                      seg.transform.SetParent(this.transform); 
                       
                      foreach(Transform tran in this.transform){
                          if(tran.position.x>max){
                            max=tran.position.x;
                          }
                      }
                     
                    seg.transform.position =this.transform.position+ new Vector3(max,0,0);

    }
    void CheckDestroy(){
        foreach(Transform tran in this.transform){
            if(tran.position.x<-20){
                            Destroy(tran.gameObject);
                            NewSegment();
                          }
        }
    }
}
