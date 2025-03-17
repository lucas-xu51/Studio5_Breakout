using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Ball Movement")]
    [SerializeField] private float ballLaunchSpeed;
    [SerializeField] private float minBallBounceBackSpeed;
    [SerializeField] private float maxBallBounceBackSpeed;
    [Header("References")]
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Rigidbody rb;
    // tail particle
    //[SerializeField] private ParticleSystem ballTail;

    private bool isBallActive;
    //position and velocity of ball
    //private Vector3 previousPosition;
    //private Vector3 currentVelocity;
    //private ParticleSystem.EmissionModule emissionModule;

    //public void Start()
    //{
    //    previousPosition = transform.position;
    //    emissionModule = ballTail.emission;
        //tail is not shown if ball not lunch
    //    emissionModule.enabled = false;
    //}
    //public void Update()
    //{
    //    currentVelocity = (transform.position - previousPosition) / Time.deltaTime;
    //    previousPosition = transform.position;
        //UpdateTrailDirection();
    //}
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Paddle"))
        {
            Vector3 directionToFire = (transform.position - other.transform.position).normalized;
            float angleOfContact = Vector3.Angle(transform.forward, directionToFire);
            float returnSpeed = Mathf.Lerp(minBallBounceBackSpeed, maxBallBounceBackSpeed, angleOfContact / 90f);
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(directionToFire * returnSpeed, ForceMode.Impulse);
            //add code to apply sound when ball hit paddle
            //AudioManager.instance.playBump();
        }
        //add code to detacted hit the walls and play sound
        if (other.gameObject.CompareTag("Environment"))
        {
            AudioManager.instance.playBump();
        }
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.None;
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.identity;
        isBallActive = false;
        //tail is not shown if ball not lunch
        //emissionModule.enabled = false;
    }

    public void FireBall()
    {
        if (isBallActive) return;
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(transform.forward * ballLaunchSpeed, ForceMode.Impulse);
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        isBallActive = true;
        //show tail
        //emissionModule.enabled = true;
    }
    //this method for update the direction of tail
    //private void UpdateTrailDirection()
    //{
    //    Vector3 moveDirection = currentVelocity.normalized;
    //    ballTail.transform.rotation = Quaternion.Slerp(
    //       ballTail.transform.rotation,
    //        Quaternion.LookRotation(-moveDirection),
    //        Time.deltaTime * 10f
    //        );
    //}
}
