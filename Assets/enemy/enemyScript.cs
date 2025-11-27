using System.Collections;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [Range(1, 360)]public float fov = 45;    
    private GameObject player;
    public bool hasLoS = false;
    public LayerMask obstacleMask;
    public LayerMask playerMask;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private float turnTimer;
    private float turnTime;
    void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0, 0, 180);
        StartCoroutine(RotateSequence());
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    void Update()
    {

        FoV();
        DrawFOVLines();

       
    }
    private void DrawFOVLines()
{
    float range = 4f;                         
    float halfFov = fov / 2f;
    
    Vector3 forward = transform.up;

    Vector3 leftBoundary  = Quaternion.Euler(0, 0, +halfFov) * forward;
    Vector3 rightBoundary = Quaternion.Euler(0, 0, -halfFov) * forward;

    Debug.DrawLine(transform.position,transform.position + leftBoundary * range,Color.red);

    Debug.DrawLine(transform.position,transform.position + rightBoundary * range,Color.red);
}

    IEnumerator RotateSequence()
    {
        while (true) 
        {
            
            turnTime = Random.Range(3f,5f);
            turnTimer = Random.Range(1.5f,2.5f);
            
            yield return StartCoroutine(RotateOverTime(targetRotation, turnTime));

            
            yield return new WaitForSeconds(turnTimer);

            
            yield return StartCoroutine(RotateOverTime(initialRotation, turnTime));

            
            yield return new WaitForSeconds(turnTimer);
        }
    }
    IEnumerator RotateOverTime(Quaternion target, float duration)
    {
        if (isRotating) yield break;

        isRotating = true;

        Quaternion startRotation = transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        transform.rotation = target;

        isRotating = false;
    }
    private void FoV()
    {
        Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(transform.position, 4, playerMask);

        if (rangeChecks.Length > 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, directionToTarget) < fov / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);
                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                {
                    hasLoS = true;
                }
                else
                {
                    hasLoS = false;
                }
            }
            else
            {
                hasLoS = false;
            }

        }
        else if (hasLoS)
        {
            hasLoS = false;
        }
    }   
}
