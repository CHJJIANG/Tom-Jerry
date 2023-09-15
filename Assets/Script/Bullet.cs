using UnityEngine;

public class Bullet : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("floor"))
        {
            // 如果子弹碰到地板，销毁子弹对象
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("player2"))
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查进入触发器的对象是否具有特定标签
        if (other.CompareTag("Player"))
        {
            // 在这里可以执行特定于玩家的操作
            // 获取玩家控制脚本
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // 减少玩家的生命值
                playerController.playerHealth--;

                // 处理玩家死亡逻辑
                if (playerController.playerHealth <= 0)
                {
                    // 玩家已死亡，可以执行相应的操作
                }
            }

            // 销毁子弹对象
            Destroy(gameObject);
            Debug.Log("health: " + playerController.playerHealth);

        }
    }
}


