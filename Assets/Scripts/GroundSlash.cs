using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class GroundSlash : MonoBehaviour
{
    public float Velocity = 20f;
    public float SlowDownRate = 0.01f;
    public float GroundDetectingDistance = 0.1f;
    public float DestroyAfterSeconds = 5f;


    private Rigidbody _rigidbody;
    private bool _isStopped;

    private Coroutine _coroutine;

    // Start is called before the first frame update
    void Start()
    {
        // snap to the ground by default
        transform.position = new Vector3(
            transform.position.x,
            0f,
            transform.position.y
        );

        _rigidbody = GetComponent<Rigidbody>();
        if(_rigidbody != null){
            _coroutine = StartCoroutine(SlowDown());
        }

        Destroy(gameObject, DestroyAfterSeconds);
    }

    void FixedUpdate()
    {
        SnapToFloor();
    }

    void SnapToFloor(){
        if(!_isStopped){
            RaycastHit hit;

            var didHitFloor = Physics.Raycast(
                origin: transform.position + Vector3.up,
                direction: transform.TransformDirection(Vector3.down),
                hitInfo: out hit,
                maxDistance: GroundDetectingDistance
            );

            transform.position = new Vector3(
                transform.position.x,
                didHitFloor ? hit.point.y : 0,
                transform.position.y
            );
        }
    }

    IEnumerator SlowDown(){
        float t = 1;
        while (t > 0){
            _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity, Vector3.zero, t);
            t -= SlowDownRate;
            yield return new WaitForSeconds(0.1f);
        }

        _isStopped = true;
        StopCoroutine(_coroutine);
    }
}
