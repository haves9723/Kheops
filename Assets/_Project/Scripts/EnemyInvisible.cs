using System.Collections;
using UnityEngine;

public class EnemyInvisible : MonoBehaviour
{
    private SpriteRenderer _sprite;

    private void OnMouseDown()
    {
        Enemy.enemies.Remove(gameObject.GetComponent<Enemy>());
        
        Destroy(gameObject);
    }

    private void Awake()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _sprite.color = new Color(1f, 1f, 1f, 0f);
    }

    private void Start()
    {
        StartCoroutine(ChangeVisibility());
    }

    private IEnumerator ChangeVisibility()
    {
        while (true)
        {
            if (_sprite.color.a == 0f)
            {
                _sprite.color = new Color(1f, 1f, 1f, 5f);
            }
            else
            {
                _sprite.color = new Color(1f, 1f, 1f, 0f);
            }  
            yield return new WaitForSeconds(Random.Range(0, 2f));
        }
        

        //yield return new WaitForSeconds(Random.Range(0, 2f));
    }
}