using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public GameObject Platform;
    public float MovementIndex = 0.01f;
    public float OffSet = 1.0f; // this offset is chosen, the platform only moves if a certain amount of change has occured
    // needed as the platform moves the handle, causing unwanted changes

    private Transform handleTransform;
    private float oldAngle = 0f;
    private float newAngle = 0f;


    // Start is called before the first frame update
    void Start()
    {
        handleTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //z-axis is the rotating axis
        newAngle = handleTransform.localRotation.eulerAngles.z;
        //the range is -90 to 90, but eulerAngles only give 0-360, therefore any higher angles need to get reduced by 360
        // 250 is chosen, simply because its high enough not to be reached normally and low enough to not interfere with current range
        if (newAngle > 250.0f)
        {
            newAngle -= 360.0f;
        }

        if (oldAngle + OffSet < newAngle || oldAngle - OffSet > newAngle)
        {
            Platform.transform.localPosition = Platform.transform.localPosition + new Vector3(0, 0, -MovementIndex * (oldAngle - newAngle));

            oldAngle = newAngle;
        }
    }
}
