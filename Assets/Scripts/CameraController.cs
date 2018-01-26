using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float smoothing = 10f;
    [SerializeField]
    private Transform target;





    void Update()
    {

            CameraFollowTarget(target);

    }


    public void CameraFollowTarget(Transform target)
    {
        if (target != null)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(target.transform.position.x, target.transform.position.y, -10f), smoothing * Time.deltaTime);

        }

    }

}
