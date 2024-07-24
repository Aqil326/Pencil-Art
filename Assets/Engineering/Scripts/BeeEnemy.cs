//using MoreMountains.CorgiEngine;
//using MoreMountains.Tools;
//using UnityEngine;
//using System.Collections;
//using TMPro;

//public class BeeEnemy : AIAction
//{
//    public GameObject firePrefab;
//    public Transform fireballSpawnPoint;
//    private GameObject player;
//    //public Grass grass;
//    protected Character character;
//    public CharacterFly characterFly;

//    // private bool isPlayerSafe = false;
//    private bool playerDetected = false;
//    public static GameObject newFireInstance;
//    public float fireballLifetime = 2f; // Lifetime of each fireball
//    public float spawnInterval = 2f; // Interval between each fireball spawn
//    public float fireOffsetY = 0.5f; // Offset below the player's position

//    public override void Initialization()
//    {
//        player = GameObject.FindGameObjectWithTag("Player");
//        character = player.GetComponent<Character>();
//        characterFly.StartFlight();
//    }

//    public virtual void Start()
//    {
//        //grass = GameObject.FindGameObjectWithTag("Grass").GetComponent<Grass>();

//        Invoke("FindPlayer", 2f);
//    }

//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player"))
//        {
//            if (GrassDetection.isPlayeringrass)
//            {
//                if (character.MovementState.CurrentState == CharacterStates.MovementStates.Crouching && !playerDetected)
//                {
//                    //    Debug.Log("Player is safe");
//                    playerDetected = false;
//                }
//                else
//                {
//                    //  Debug.Log("Player is not safe");
//                    characterFly.StopFlight();
//                    playerDetected = true;
//                    StartCoroutine(SpawnFireballs());
//                }
//            }
//            else
//            {
//                if (!playerDetected)
//                {
//                    characterFly.StopFlight();
//                    playerDetected = true;
//                    StartCoroutine(SpawnFireballs());

//                }
//            }
//        }
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        playerDetected = false;
//        characterFly.StartFlight();
//    }

//    #region TriggerEnter Code
//    //public virtual void OnTriggerEnter2D(Collider2D collider)
//    //{

//    //    if (collider.CompareTag("Player"))
//    //    {
//    //        if (GrassDetection.isPlayeringrass)
//    //        {
//    //            if (character.MovementState.CurrentState == CharacterStates.MovementStates.Crouching && !playerDetected)
//    //            {
//    //              //  Debug.Log("Player is safe");
//    //                playerDetected = false;
//    //            }
//    //            else
//    //            {
//    //               // Debug.Log("Player is not safe");
//    //                playerDetected = true;
//    //                StartCoroutine(SpawnFireballs());
//    //            }
//    //        }
//    //        else
//    //        {
//    //            if (!playerDetected)
//    //            {
//    //                playerDetected = true;
//    //                StartCoroutine(SpawnFireballs());

//    //            }
//    //        }
//    //    }
//    //}


//    #endregion

//    private IEnumerator SpawnFireballs()
//    {
//        while (playerDetected)
//        {
//            SpawnFire();
//            yield return new WaitForSeconds(spawnInterval); // Wait before spawning the next fireball
//        }
//    }

//    public void SpawnFire()
//    {
//        if (firePrefab != null)
//        {
//            // Spawn a new fire instance at the fireball spawn point
//            newFireInstance = Instantiate(firePrefab, fireballSpawnPoint.position, Quaternion.identity);

//            // Move the fire towards the player's position at the time of spawning
//            Vector3 fireTargetPosition = new Vector3(player.transform.position.x, player.transform.position.y - fireOffsetY, player.transform.position.z);
//            StartCoroutine(MoveFireTowardsTarget(newFireInstance, fireTargetPosition));

//            Destroy(newFireInstance, spawnInterval);
//        }
//        else
//        {
//            Debug.LogError("Fire prefab is not assigned.");
//        }

//    }

//    private IEnumerator MoveFireTowardsTarget(GameObject fireInstance, Vector3 targetPosition)
//    {
//        // float elapsedTime = 0f;
//        while (fireInstance != null /*&& elapsedTime < fireballLifetime*/)
//        {
//            // Move the fire towards the target position
//            fireInstance.transform.position = Vector2.MoveTowards(
//                fireInstance.transform.position,
//                targetPosition,
//                Time.deltaTime * 15f // Adjust speed as needed
//               );

//            //  elapsedTime += Time.deltaTime;
//            yield return null;
//        }

//        yield return null;
//    }

//    private void FindPlayer()
//    {
//        player = GameObject.FindGameObjectWithTag("Player");
//        character = player.GetComponent<Character>();
//    }

//    private void Update()
//    {
//        // No need to move the fireball towards the player in Update

//    }

//    public override void PerformAction()
//    {
//        throw new System.NotImplementedException();
//    }
//}


using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;
using System.Collections;

public class BeeEnemy : AIAction
{
    public GameObject firePrefab;
    public Transform fireballSpawnPoint;
    //  public float fireballLifetime = 2f; // Lifetime of each fireball
    public float spawnInterval = 2f; // Interval between each fireball spawn
                                     //  public float fireOffsetY = 0.5f; // Offset below the player's position
    public float fireSpeed = 15f; // Speed of the fireball

    public GameObject player;
    private Character character;
    public CharacterFly characterFly;

    public bool playerDetected = false;

    [SerializeField]
    public static GameObject newFireInstance;

    public override void Initialization()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            character = player.GetComponent<Character>();
        }
    }

    public virtual void Start()
    {
        
        Invoke("FindPlayer", 1f);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            HandlePlayerDetection();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = false;
              characterFly.StartFlight();
              characterFly._flying = true;  
        }
    }

    private void HandlePlayerDetection()
    {
        if (GrassDetection.isPlayeringrass && character.MovementState.CurrentState == CharacterStates.MovementStates.Crouching)
        {
            playerDetected = false;
            return;
        }

        if (!playerDetected)
        {
            characterFly.StopFlight();
            characterFly._flying = false;
            playerDetected = true;
            StartCoroutine(SpawnFireballs());
        }
    }

    private IEnumerator SpawnFireballs()
    {
        while (playerDetected)
        {
            SpawnFire();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SpawnFire()
    {
        if (firePrefab != null)
        {
            newFireInstance = Instantiate(firePrefab, fireballSpawnPoint.position, Quaternion.identity);
            Rigidbody2D fireRb = newFireInstance.GetComponent<Rigidbody2D>();

            if (fireRb != null)
            {
                StartCoroutine(MoveFireTowardsPlayer(fireRb));
            }

            //  Destroy(newFireInstance, fireballLifetime);
        }
        else
        {
            Debug.LogError("Fire prefab is not assigned.");
        }
    }

    private IEnumerator MoveFireTowardsPlayer(Rigidbody2D fireRb)
    {
        while (fireRb != null && playerDetected)
        {

            Vector2 direction = ((Vector2)player.transform.position - fireRb.position).normalized;
            fireRb.velocity = direction * fireSpeed;
            yield return null;
        }
    }

    private void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            character = player.GetComponent<Character>();
            characterFly.StartFlight();
        }

        else
        {
            Debug.Log("Player is Null");
        }
    }

    public override void PerformAction()
    {
        // Implementation for PerformAction
    }
}
