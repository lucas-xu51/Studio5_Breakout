using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //this for apply particle effect
    [SerializeField] private ParticleSystem destoryParticle;

    private Coroutine destroyRoutine = null;

    private ParticleSystem destoryParticleInstance;

    private void OnCollisionEnter(Collision other)
    {
        if (destroyRoutine != null) return;
        if (!other.gameObject.CompareTag("Ball")) return;
        destroyRoutine = StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(0.1f); // two physics frames to ensure proper collision
        GameManager.Instance.OnBrickDestroyed(transform.position);

        //span particle effects
        SpanDestoryParticle();

        Destroy(gameObject);
    }

    private void SpanDestoryParticle()
    { 
        destoryParticleInstance = Instantiate(destoryParticle, transform.position,Quaternion.identity);
    }
}
