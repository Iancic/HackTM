using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform target;
    //transform of the player

    public float smoothSpeed = 0.125f;
    //the bigger the faster the camera will lock onto the target, the smaller the opposite

    public Vector3 offset;
    //offset for camera

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        //pozitia dorita de jucator

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //Ajung la pozitia dorita de jucator prin functia lerp. Aceasta te duce de la un punct la altul inntr-un anumit timp (smoothSpeed)

        transform.position = desiredPosition;
        //schimbarea pozitiei

        transform.LookAt(target);
    }
    //Late update este chemat dupa ce a fost chemat update deoarece obiectul isi schimba miscarea in update. Noi il urmarim dupa ce si-a facut miscarile
}
