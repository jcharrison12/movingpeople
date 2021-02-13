using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IKLimbsCentral : MonoBehaviour
{
    //this script attached to dummy gameobject
    protected Animator animator;
    public GameObject RH;
    public GameObject LH;
    public GameObject RF;
    public GameObject LF;
    public GameObject handle;
    protected Collider _colliderRH;
    protected Collider _colliderLH;
    protected Collider _colliderRF;
    protected Collider _colliderLF;
    protected Collider _colliderHandle;
    private Camera mainCamera; 
    private Plane plane;
    private bool isSet;

    void Start()
    {
        animator = GetComponent<Animator>();
        mainCamera = Camera.main; //Accessing Camera.main has overhead comparable to calling GameObject.GetComponent; it's best to cache it, where possible
        _colliderRH = RH.GetComponent<Collider>(); //collider on each hand or foot
        _colliderLH = LH.GetComponent<Collider>(); //collider on each hand or foot
        _colliderRF = RF.GetComponent<Collider>(); //collider on each hand or foot
        _colliderLF = LF.GetComponent<Collider>(); //collider on each hand or foot
        _colliderHandle = handle.GetComponent<Collider>();
        //plane = new Plane(this.transform.forward, this.transform.position); //having the plane go through the transform rather than somewhere else seems to help keep the targets from disappearing behind the plane
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) //if mouse click
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //get mouse position and project ray from camera to that point
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray, 150.0F); //get all the things hit by the ray instead of just one
            if (hits.Length > 0)
            {
                RaycastHit hit = hits[0]; //always take the first hit in the array even if there are multiple (just to pick one)
                plane = new Plane(hit.collider.transform.forward, hit.collider.transform.position); //use the plane through each IK target so they don't get stuck hopefully
                if (hit.collider == _colliderRH)
                {
                    float enter;
                    if (plane.Raycast(ray, out enter))
                    {
                        Vector3 hitPoint = ray.GetPoint(enter); //get point where ray intersects plane which should also be where ray hits the collider
                        RH.transform.position = hitPoint;
                    }
                }
                if (hit.collider == _colliderLH)
                {
                    float enter;
                    if (plane.Raycast(ray, out enter))
                    {
                        Vector3 hitPoint = ray.GetPoint(enter); //get point where ray intersects plane which should also be where ray hits the collider
                        LH.transform.position = hitPoint;
                    }
                }
                if (hit.collider == _colliderRF)
                {
                    float enter;
                    if (plane.Raycast(ray, out enter))
                    {
                        Vector3 hitPoint = ray.GetPoint(enter); //get point where ray intersects plane which should also be where ray hits the collider
                        RF.transform.position = hitPoint;
                    }
                }
                if (hit.collider == _colliderLF)
                {
                    float enter;
                    if (plane.Raycast(ray, out enter))
                    {
                        Vector3 hitPoint = ray.GetPoint(enter); //get point where ray intersects plane which should also be where ray hits the collider
                        LF.transform.position = hitPoint;
                    }
                }
                if (hit.collider == _colliderHandle)
                {
                    float enter;
                    if (Input.GetKeyDown("a")) //if both clicking on handle collider and pressing "a"
                    {
                        transform.RotateAround(handle.transform.position, Vector3.up, 30f); //rotate whole dummy 30 degrees (can't hold down yet, have to press several times)
                    }
                    else if (Input.GetKeyDown("s"))
                    {
                        transform.RotateAround(handle.transform.position, Vector3.up, -30f);
                    }
                    else if (Input.GetKeyDown("w")) 
                    {
                        transform.RotateAround(handle.transform.position, Vector3.forward, 30f);
                    }
                    else if (Input.GetKeyDown("d"))
                    {
                        transform.RotateAround(handle.transform.position, Vector3.forward, -30f);
                    }
                    else if (Input.GetKeyDown("q"))
                    {
                        transform.RotateAround(handle.transform.position, Vector3.left, 30f);
                    }
                    else if (Input.GetKeyDown("e"))
                    {
                        transform.RotateAround(handle.transform.position, Vector3.left, -30f);
                    }
                    plane.Raycast(ray, out enter); 
                    //vector subtraction/addition to find direction and distance dummy moves, and apply to IK targets so they don't get left behind
                    Vector3 beforepos = handle.transform.position;
                    Vector3 hitPoint = ray.GetPoint(enter);
                    //transform.position = hitPoint;
                    handle.transform.position = hitPoint;
                    Vector3 diff = hitPoint - beforepos;
                    transform.position = transform.position + diff;
                    RH.transform.position = RH.transform.position + diff;
                    LH.transform.position = LH.transform.position + diff;
                    RF.transform.position = RF.transform.position + diff;
                    LF.transform.position = LF.transform.position + diff;
                }
            }
        //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //get mouse position and project ray from camera to that point
        //    RaycastHit hit;
        //    if (_colliderRH.Raycast(ray, out hit, 10f) && !_colliderLH.Raycast(ray, out hit, 10f)) //if ray hits collider
        //    {
        //        float enter;
        //        if (plane.Raycast(ray, out enter))
        //        {
        //            Vector3 hitPoint = ray.GetPoint(enter); //get point where ray intersects plane which should also be where ray hits the collider
        //            RH.transform.position = hitPoint;
        //        }
        //    }
        //    else if (_colliderLH.Raycast(ray, out hit, 10f) && !_colliderRH.Raycast(ray, out hit, 10f))
        //    {
        //        float enter;
        //        if (plane.Raycast(ray, out enter))
        //        {
        //            Vector3 hitPoint = ray.GetPoint(enter); //get point where ray intersects plane which should also be where ray hits the collider
        //            LH.transform.position = hitPoint;
        //        }
        //    }
        //    else if (_colliderLH.Raycast(ray, out hit, 10f) && _colliderRH.Raycast(ray, out hit, 10f))
        //    {
        //        float enter;
        //        if (plane.Raycast(ray, out enter))
        //        {
        //            Vector3 hitPoint = ray.GetPoint(enter); //get point where ray intersects plane which should also be where ray hits the collider
        //            RH.transform.position = hitPoint;
        //        }
        //    }
        //    if (_colliderRF.Raycast(ray, out hit, 10f) && !_colliderLF.Raycast(ray, out hit, 10f)) //if ray hits collider
        //    {
        //        float enter;
        //        if (plane.Raycast(ray, out enter))
        //        {
        //            Vector3 hitPoint = ray.GetPoint(enter); //get point where ray intersects plane which should also be where ray hits the collider
        //            RF.transform.position = hitPoint;
        //        }
        //    }
        //    else if (_colliderLF.Raycast(ray, out hit, 10f) && !_colliderRF.Raycast(ray, out hit, 10f))
        //    {
        //        float enter;
        //        if (plane.Raycast(ray, out enter))
        //        {
        //            Vector3 hitPoint = ray.GetPoint(enter); //get point where ray intersects plane which should also be where ray hits the collider
        //            LF.transform.position = hitPoint;
        //        }
        //    }
        //    else if (_colliderLF.Raycast(ray, out hit, 10f) && _colliderRF.Raycast(ray, out hit, 10f))
        //    {
        //        float enter;
        //        if (plane.Raycast(ray, out enter))
        //        {
        //            Vector3 hitPoint = ray.GetPoint(enter); //get point where ray intersects plane which should also be where ray hits the collider
        //            RF.transform.position = hitPoint;
        //        }
        //    }
        //    else if (_colliderHandle.Raycast(ray, out hit, 10f)) //if the ray hits the collider
        //    {
        //        float enter;
        //        if (Input.GetKeyDown("a")) //if both clicking on handle collider and pressing "a"
        //        {
        //            transform.Rotate(0, 30f, 0); //rotate whole dummy 30 degrees (can't hold down yet, have to press "a" several times)
        //        }
        //        else if (Input.GetKeyDown("s"))
        //        {
        //            transform.Rotate(0, -30f, 0); //rotate whole dummy 30 degrees other direction
        //        }
        //        if (Input.GetKeyDown("w")) //if both clicking on handle collider and pressing "a"
        //        {
        //            transform.Rotate(30f, 0, 0); //rotate whole dummy 30 degrees (can't hold down yet, have to press "a" several times)
        //        }
        //        else if (Input.GetKeyDown("d"))
        //        {
        //            transform.Rotate(-30f ,0, 0); //rotate whole dummy 30 degrees other direction
        //        }
        //        else if (plane.Raycast(ray, out enter)) //if just clicking, no WASD
        //        {
        //            //vector subtraction/addition to find direction and distance dummy moves, and apply to IK targets so they don't get left behind
        //            Vector3 beforepos = transform.position;
        //            Vector3 hitPoint = ray.GetPoint(enter);
        //            transform.position = hitPoint;
        //            handle.transform.position = hitPoint;
        //            Vector3 diff = hitPoint - beforepos;
        //            RH.transform.position = RH.transform.position + diff;
        //            LH.transform.position = LH.transform.position + diff;
        //            RF.transform.position = RF.transform.position + diff;
        //            LF.transform.position = LF.transform.position + diff;
        //        }
        //    }

        }
    }
    private void LateUpdate()
    {
        //again, because animator changes the positions of everything after Start, have to assign initial position of each target this way because I can't think of a better way to do it
        if (isSet == false)
        {
            //handle.transform.position = transform.GetComponent<Renderer>().bounds.center;
            ChildrenLoop(transform, "B-hand_R", RH.transform); //have to loop through all the body parts in the mode
            ChildrenLoop(transform, "B-hand_L", LH.transform);
            ChildrenLoop(transform, "B-foot_R", RF.transform);
            ChildrenLoop(transform, "B-foot_L", LF.transform);
            ChildrenLoop(transform, "B-chest", handle.transform);
            isSet = true;
        }
    }
    void ChildrenLoop(Transform trans, string bodypart, Transform target)
    {
        foreach (Transform child in trans)
        {
            if (child.gameObject.name == bodypart) //if body part matches name
            {
                target.position = child.position;
               
            }
            else if (child.childCount > 0) // if there are more children, iterate through next level deep, etc.
            {
                ChildrenLoop(child, bodypart, target);
            }
        }
    }
    void OnAnimatorIK()
    {
        if (animator) //if animator is assigned
        {
            if (RH!= null)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1); //IK weight at 1 means movement is controlled entirely by IK rather than animation (I think)
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKPosition(AvatarIKGoal.RightHand, RH.transform.position); //set position of RH
                animator.SetIKRotation(AvatarIKGoal.RightHand, RH.transform.rotation); //set rotation  of LH (to do--rotation of hands is really weird, maybe don't set the same as target transform?)
            }
            if (LH != null)
            {
                //blah blah blah same as above
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                animator.SetIKPosition(AvatarIKGoal.LeftHand, LH.transform.position);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, LH.transform.rotation);
            }
            if (RF != null)
            { //note: not having foot rotation looks better than having it so I'm just keeping it that way for now
                animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
                animator.SetIKPosition(AvatarIKGoal.RightFoot, RF.transform.position);
                //animator.SetIKRotation(AvatarIKGoal.RightFoot, GameManager.Instance.RF.rotation);
            }
            if (LF != null)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                animator.SetIKPosition(AvatarIKGoal.LeftFoot, LF.transform.position);
                //animator.SetIKRotation(AvatarIKGoal.LeftFoot, GameManager.Instance.LF.rotation);
            }
        }
    }
}
