using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3DMovement : MonoBehaviour
{
    public PlayerController3D target;
    public float followSpeed;
    public float baseOffset = 1.3f;
    public float maxOffset = 3;
    public float camHeight = 7;
    private float timePressing;
    Vector3 targetPos;
    Vector3 offsetPos;
    Vector3 basicPos;
    float angle;
    float Zoffset;

    Camera cam;
    private void Awake()
    {
        cam = this.GetComponent<Camera>();

        //angle = (90 - this.transform.eulerAngles.x) * Mathf.Deg2Rad;
        //Zoffset = (Mathf.Tan(angle)) * camHeight;
        //targetPos = new Vector3(target.transform.position.x, camHeight + target.transform.position.y, target.transform.position.z - Zoffset);
        SetCamPos();
        this.transform.position = basicPos + offsetPos;
    }

    private void FixedUpdate()
    {
        SetCamPos();
    }

    private void SetCamPos()
    {
        //if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        //    timePressing += Time.deltaTime * .35f;
        //else timePressing -= Time.deltaTime * .15f;
        //timePressing = Mathf.Clamp(timePressing, 0, maxOffset);

        angle = (90 - this.transform.eulerAngles.x) * Mathf.Deg2Rad;
        Zoffset = (Mathf.Tan(angle)) * camHeight;

        basicPos = new Vector3(target.transform.position.x, camHeight + target.transform.position.y, target.transform.position.z - Zoffset);
        offsetPos = new Vector3(target.rb.velocity.x * timePressing / 2, 0, target.rb.velocity.z * timePressing / 2) + target.transform.forward * (timePressing + baseOffset);

        targetPos = Vector3.MoveTowards(targetPos, basicPos + offsetPos, followSpeed * Time.fixedDeltaTime);

        this.transform.position = targetPos;
    }

    //private void OnDrawGizmos()
    //{

    //    if (UnityEditor.EditorApplication.isPlaying)
    //    {
    //        Gizmos.color = Color.green;
    //        Gizmos.DrawWireSphere(offsetPos, .5f);
    //    }
    //}
}
