using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    [SerializeField] AudioClip carStop;
    [SerializeField] AudioClip jokerLaugh;
    [SerializeField] private Transform m_target;
    [SerializeField] private Transform n_target;

    public Vector3 TargetPosition
    {
        get { return m_target.position; }
        set { m_target.position = value; }
    }
    public Vector3 AvoidPosition
    {
        get { return n_target.position; }
        set { n_target.position = value; }
    }
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    Rigidbody2D rb;
    public int behaviour;
    public bool soundPlayed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        TargetPosition = m_target.position;
        AvoidPosition = n_target.position;
    }

    void Update()
    {
        if(behaviour == 1)
        {
            Seeking();
        }
        if(behaviour == 2)
        {
            Fleeing();
        }
        if(behaviour == 3)
        {
            Arrival();
        }
        if(behaviour == 4)
        {
            Avoidance();
        }
    }

    private void Seeking()
    {
        Vector2 directionToTarget = (TargetPosition - transform.position).normalized;

        float targetAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg + 90.0f;

        float angleDifference = Mathf.DeltaAngle(targetAngle, transform.eulerAngles.z);
        float rotationStep = rotationSpeed * Time.deltaTime;
        float rotationAmount = Mathf.Clamp(angleDifference, -rotationStep, rotationStep);
        transform.Rotate(Vector3.forward, rotationAmount);

        rb.velocity = transform.up * moveSpeed;
    }
        private void Fleeing()
    {
        if (transform.position.x < 8.4 && transform.position.x > -8.4 && transform.position.y < 4.4 && transform.position.y > -4.4)
        {
        Vector2 directionToTarget = (TargetPosition - transform.position).normalized;

        float targetAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg + 90.0f;

        float angleDifference = Mathf.DeltaAngle(targetAngle, transform.eulerAngles.z);
        float rotationStep = rotationSpeed * Time.deltaTime;
        float rotationAmount = Mathf.Clamp(angleDifference, -rotationStep, rotationStep);
        transform.Rotate(-Vector3.forward, rotationAmount);

        rb.velocity = transform.up * moveSpeed;
        }
        else
        {
            if (soundPlayed == false)
            {
                AudioSource.PlayClipAtPoint(jokerLaugh, transform.position);
                soundPlayed = true;
            }
            rb.velocity *= 0;
        }
    }
    private void Arrival()
    {
        if (Mathf.Abs(transform.position.x - m_target.position.x) > 1f || Mathf.Abs(transform.position.y - m_target.position.y) > 1f)
        {
        Vector2 directionToTarget = (TargetPosition - transform.position).normalized;

        float targetAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg + 90.0f;

        float angleDifference = Mathf.DeltaAngle(targetAngle, transform.eulerAngles.z);
        float rotationStep = rotationSpeed * Time.deltaTime;
        float rotationAmount = Mathf.Clamp(angleDifference, -rotationStep, rotationStep);
        transform.Rotate(Vector3.forward, rotationAmount);

        rb.velocity = transform.up * moveSpeed;
        }
        else if(Mathf.Abs(transform.position.x - m_target.position.x) <= 0.1f && Mathf.Abs(transform.position.y - m_target.position.y) <= 0.1f)
        {
            rb.velocity *= 0;
        }
        else if(Mathf.Abs(transform.position.x - m_target.position.x) <= 1f && Mathf.Abs(transform.position.y - m_target.position.y) <= 1f)
        {
            if (soundPlayed == false)
            {
                AudioSource.PlayClipAtPoint(carStop, transform.position);
                soundPlayed = true;
            }
            rb.velocity = transform.up * moveSpeed * ((Mathf.Abs(transform.position.x - m_target.position.x) + Mathf.Abs(transform.position.y - m_target.position.y))/2);
        }
    }
    private void Avoidance()
    {
        if(Mathf.Abs(transform.position.x - m_target.position.x) <= 0.1f && Mathf.Abs(transform.position.y - m_target.position.y) <= 0.1f)
        {
            if (soundPlayed == false)
            {
                AudioSource.PlayClipAtPoint(carStop, transform.position);
                soundPlayed = true;
            }
            rb.velocity *= 0;
        }
        else if(Mathf.Abs(transform.position.x - n_target.position.x) <= 1.5f && Mathf.Abs(transform.position.y - n_target.position.y) <= 1.5f)
        {
        Vector2 directionToAvoid = (AvoidPosition - transform.position).normalized;

        float avoidAngle = Mathf.Atan2(directionToAvoid.y, directionToAvoid.x) * Mathf.Rad2Deg - 90.0f;

        float aAngleDifference = Mathf.DeltaAngle(avoidAngle, transform.eulerAngles.z);
        float aRotationStep = rotationSpeed * Time.deltaTime;
        float aRotationAmount = Mathf.Clamp(aAngleDifference, -aRotationStep, aRotationStep);
        transform.Rotate(Vector3.forward, aRotationAmount);
        rb.velocity = transform.up * moveSpeed;
        }
        else
        {
        Vector2 directionToTarget = (TargetPosition - transform.position).normalized;

        float targetAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg + 90.0f;

        float angleDifference = Mathf.DeltaAngle(targetAngle, transform.eulerAngles.z);
        float rotationStep = rotationSpeed * Time.deltaTime;
        float rotationAmount = Mathf.Clamp(angleDifference, -rotationStep, rotationStep);
        transform.Rotate(Vector3.forward, rotationAmount);
        rb.velocity = transform.up * moveSpeed;
        }
    }
}
