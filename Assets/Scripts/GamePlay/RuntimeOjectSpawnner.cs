
using UnityEngine;
using PlayerServices;


public class RuntimeOjectSpawnner : MonoBehaviour
{
    public static RuntimeOjectSpawnner instance;
    [SerializeField] private Transform[] enemySpawnPoint = new Transform[4];
    [SerializeField] private Enemy enemy;
    [SerializeField] private Coin coin;

    private GameObject pooledEnemy = null;
    private GameObject pooledCoin = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        SpawnEnemy();
        SpawnCoin();
    }

    //every Simple Implementation of object pooling to Avoid Excessive Instantiations
    //I have made object pool for only one object here, I have also made object pools of more than objects in my own projects
    public void SpawnEnemy()
    {
        int index = Random.Range(0, enemySpawnPoint.Length);


        if (pooledEnemy == null)
            pooledEnemy = Instantiate(enemy.gameObject, enemySpawnPoint[index].position, Quaternion.identity);
        else
            pooledEnemy.transform.position = enemySpawnPoint[index].position;

        pooledEnemy.GetComponent<Enemy>().SetRandomMovementSpeed();
    }
    public void SpawnCoin()
    {
        int index = Random.Range(0, enemySpawnPoint.Length);
        int randCoin = Random.Range(1, 3); //50% prob. to have animated coin or simple ground Coin

        if (pooledCoin == null)
            pooledCoin = Instantiate(coin.gameObject, enemySpawnPoint[index].position, Quaternion.identity);
        else
            pooledCoin.transform.position = enemySpawnPoint[index].position;

        if (randCoin == 1)
        {
            pooledCoin.GetComponentInChildren<Animator>().enabled = true;
        }
        else
        {
            pooledCoin.GetComponentInChildren<Animator>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && PlayerService.instance.GetPlayerController() != null)
        {
            SpawnEnemy();
        }
        if (other.CompareTag("Coin") && PlayerService.instance.GetPlayerController() != null)
        {
            SpawnCoin();
        }

    }
}
