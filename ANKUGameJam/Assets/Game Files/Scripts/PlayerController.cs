using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask interactables;
    //public GameObject playerRenderer;
    public Transform groundCheck;
    public Transform interactablePivot;

    [Header(" Player Settings ")]
    public float movementSpeed;
    public float jumpMultiplier;
    public float interactionRadius;

    Rigidbody2D rb;
    public Animator animator;

    float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        /*
        if (IsGrounded())
        {
            //Can jump
            Jump();
        }
        */

        //Check for interactables, if there is any interact with it with key 'E'
        InteractableChecker();
        CharacterAnimations();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * movementSpeed * Time.deltaTime, rb.velocity.y);

        Rotation();
    }

    private void Rotation()
    {
        if (rb.velocity.x > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (rb.velocity.x < -0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    /*
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.up * jumpMultiplier, ForceMode2D.Impulse);
        }
    }
    */

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.transform.position, .2f, groundLayer);
    }

    private void InteractableChecker()
    {
        Collider2D[] interactableColliders = Physics2D.OverlapCircleAll(interactablePivot.position, interactionRadius, interactables);
        if (interactableColliders.Length > 0)
        {
            if (interactableColliders[0].TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                GameStateHandler.instance.SetInteractionInfo(interactableColliders[0].transform.GetChild(0).position);//Her tezgahýn ilk çocuðunu pivot olarak sectim
                //TODO Eger oyun isInteractable degilse etkileþim paneli açýlmasýn
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Etkileþime girdim");
                    interactable.Interaction();
                }
            }
        }
        else
        {
            GameStateHandler.instance.interactionInfo.SetActive(false);
        }
    }
    private void CharacterAnimations()
    {
        if (rb.velocity.x > 0 || rb.velocity.x < 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactablePivot.position, interactionRadius);
    }

}
