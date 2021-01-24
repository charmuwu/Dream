public class FollowCamera : MonoBehaviour{
    public Transform target;
    public Vector3 offsetPosition;
    public Space offsetPositionSpace = Space.Self;
    public bool lookAt = true;

    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        if(target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        if(offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        if(lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
}