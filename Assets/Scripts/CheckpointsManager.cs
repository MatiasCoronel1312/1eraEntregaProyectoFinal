using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsManager : MonoBehaviour
{
    [SerializeField] List<Transform> CheckPoint = new List<Transform>();

    private void Awake() {
        foreach(Transform checkPoint in transform ){
            
            CheckPoint.Add(checkPoint);
        }
    }

    void Start()
    {
        
        
    }

    public void FindCheckPoint(string name){
        int indexPoint = CheckPoint.FindIndex(item => item.name ==  name);
        GameManager.instancePlayer.lastSP = indexPoint;
    }

    public Transform GetCheckPoint(int index){  
            
            return CheckPoint[index];      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
