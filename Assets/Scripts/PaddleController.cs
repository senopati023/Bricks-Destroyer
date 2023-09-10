using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


 public class PaddleController : MonoBehaviour
{
    public float kecepatan;
    public string axis;
    public float batasKiri;
    public float batasKanan;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        float gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
        transform.Translate(0, gerak, 0);
        float nextPos = transform.position.y + gerak;
        
            if (nextPos > batasKiri)
            {
                gerak = 0;
            }
            if (nextPos < batasKanan)
            {
                gerak = 0;
            }
        
    }
    
}
