using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuración de Enemigos")]
    [Tooltip("El prefab del enemigo que quieres spawnear")]
    public GameObject enemyPrefab;

    [Tooltip("Tiempo en segundos entre cada aparición")]
    public float spawnInterval = 2f;

    [Tooltip("Cantidad máxima de enemigos permitidos al mismo tiempo")]
    public int maxEnemies = 10;

    [Header("Seguimiento del Jugador")]
    [Tooltip("Referencia al Transform del jugador")]
    public Transform player;

    [Tooltip("Si está activo, este objeto seguirá la posición del jugador automáticamente")]
    public bool followPlayer = true;

    [Tooltip("Offset (distancia extra) respecto a la posición del jugador")]
    public Vector3 offset;

    [Header("Rango de Spawn (Relativo al Spawner)")]
    [Tooltip("Distancia mínima y máxima en X desde el centro")]
    public float minX = -10f;
    public float maxX = 10f;

    [Tooltip("Distancia mínima y máxima en Y desde el centro")]
    public float minY = -5f;
    public float maxY = 5f;

    [Header("Visualización (Editor)")]
    public bool showGizmos = true;
    public Color areaColor = new Color(0, 1, 0, 0.3f);

    private List<GameObject> activeEnemies = new List<GameObject>();

    private void Start()
    {
        // Si no asignaste el jugador, intentamos buscarlo por el tag "Player"
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) player = playerObj.transform;
        }

        // Iniciamos la rutina de spawn
        StartCoroutine(SpawnRoutine());
    }

    private void Update()
    {
        // Mover el spawner a la posición del jugador
        if (followPlayer && player != null)
        {
            transform.position = player.position + offset;
        }

        // Limpiar la lista de enemigos muertos para poder spawnear más
        activeEnemies.RemoveAll(enemy => enemy == null);
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (CanSpawn())
            {
                SpawnEnemy();
            }
        }
    }

    private bool CanSpawn()
    {
        return enemyPrefab != null && activeEnemies.Count < maxEnemies;
    }

    private void SpawnEnemy()
    {
        // Generar posición aleatoria dentro del rango definido
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // La posición es relativa a la posición actual del spawner (que sigue al jugador)
        Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, 0f);

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        activeEnemies.Add(newEnemy);
    }

    // Dibuja un rectángulo en la ventana de Escena para ver el área de spawn
    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        Gizmos.color = areaColor;

        // Calculamos el centro y el tamaño para el cubo de visualización
        Vector3 center = transform.position + new Vector3((minX + maxX) / 2, (minY + maxY) / 2, 0);
        Vector3 size = new Vector3(maxX - minX, maxY - minY, 0.1f);

        Gizmos.DrawCube(center, size);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(center, size);

        // Dibujamos una pequeña esfera en el punto exacto del Spawner
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.3f);
    }
}