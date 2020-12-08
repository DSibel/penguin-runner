using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platMover : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = -1.5f;
      private Rigidbody platform;
    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update(){
    Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position =pos;


      
}


}
