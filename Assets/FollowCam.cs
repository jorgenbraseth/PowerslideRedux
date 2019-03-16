using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public GameObject follow;
    public float offsetAbove;
    public float offsetBehind;
    public float followSpeed = 2;
    public float offsetSide = 0;

    // Update is called once per frame
    void Update()
    {
        if (follow == null)
            return;
        
        Transform followTransform = follow.transform;
        var followTransformPosition = followTransform.position;
        var targetNewPos = followTransformPosition + followTransform.forward * -offsetBehind + Vector3.up * offsetAbove + followTransform.right * offsetSide;
        transform.position = Vector3.Lerp(transform.position, targetNewPos, Time.deltaTime * followSpeed); 

        transform.LookAt(followTransform);
    }
}
