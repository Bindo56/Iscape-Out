using UnityEngine;

public class PlayerResetShape : MonoBehaviour
{
    public SpringJoint2D[] springJoints;
    [SerializeField] float maxDistance = 2f; // Set your maximum distance here
    [SerializeField] float springForce = 50f; // Adjust the spring force to control stiffness
    [SerializeField] float dampingRatio = 0.5f; // Adjust the damping ratio to control damping

    void Start()
    {
        // Ensure the spring joints are not auto-configured for distance
        foreach (SpringJoint2D joint in springJoints)
        {
            joint.autoConfigureDistance = false;
        }
    }

    void Update()
    {
        foreach (SpringJoint2D joint in springJoints)
        {
            // Calculate the current distance between connected bodies
            float currentDistance = Vector2.Distance(joint.connectedBody.transform.position, joint.transform.position);

            // Check if the current distance exceeds the maximum distance
            if (currentDistance > maxDistance)
            {
                // Calculate the desired distance based on the maximum distance
                float desiredDistance = maxDistance;

                // Apply force to bring the connected bodies closer if they exceed the maximum distance
                float forceMagnitude = springForce * (currentDistance - desiredDistance);
                joint.connectedBody.AddForce((joint.transform.position - joint.connectedBody.transform.position).normalized * forceMagnitude);

                // Apply damping to prevent oscillation
                Vector2 relativeVelocity = (joint.connectedBody.velocity - joint.GetComponent<Rigidbody2D>().velocity);
                joint.connectedBody.AddForce(dampingRatio * relativeVelocity, ForceMode2D.Force);
            }
        }
    }
}
