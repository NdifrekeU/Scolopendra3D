using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CurvedPathGenerator;
public class CentipedeHead : MonoBehaviour
{
    public float speed = 100;
    public CentipedeController controller;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init(CentipedeController controller, PathGenerator pathGenerator)
    {
        this.controller = controller;
        PathFollower pathFollower = GetComponent<PathFollower>();
        pathFollower.Generator = pathGenerator;
        pathFollower.Speed = speed;

        pathFollower.EndEvent.AddListener(() => SceneLoader.ReloadLevel());
        GetComponent<Collider>().enabled = false;//cannot be destroyed, otherwise followers suffer
    }
}
