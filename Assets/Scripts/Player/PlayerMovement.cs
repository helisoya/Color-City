using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;

    [SerializeField] private Camera cam;

    [SerializeField] private Animator animator;

    [SerializeField] private LayerMask layerToUse;



    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        animator.SetBool("Walking",movement.magnitude!=0);

        MoveTowardTarget(movement);
        RotateTowardMouse();
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
    }

    void RotateTowardMouse(){
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo;
        if(Physics.Raycast(ray,out hitinfo,300f,layerToUse)){
            transform.LookAt(new Vector3(hitinfo.point.x,transform.position.y,hitinfo.point.z));
        }
    }

    void MoveTowardTarget(Vector3 move){
        move = Quaternion.Euler(0,cam.transform.eulerAngles.y,0) * move;
        transform.position+=speed*Time.deltaTime*move;
    }
}
