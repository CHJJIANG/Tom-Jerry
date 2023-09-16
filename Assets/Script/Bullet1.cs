using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet1 : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("floor"))
        {
            // 如果子弹碰到地板，销毁子弹对象
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("player1"))
        {
            // 在这里可以执行特定于玩家的操作
            // 获取玩家控制脚本
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // 减少玩家的生命值
                playerController.playerHealth--;

                // 处理玩家死亡逻辑
                if (playerController.playerHealth <= 0)
                {
                    // 玩家已死亡，可以执行相应的操作
                    SceneManager.LoadScene(1);
                }
            }

            // 销毁子弹对象
            Destroy(gameObject);
            Debug.Log("life left: " + playerController.playerHealth);
        }

        if (collision.gameObject.CompareTag("Cheese1"))
        {
            // 在这里可以执行特定于玩家的操作
            // 获取玩家控制脚本
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // 减少芝士的生命值
                playerController.playerHealth--;
                // 加分
                playerController.playerScore += 3;

                // 处理玩家死亡逻辑
                if (playerController.playerHealth <= 0)
                {
                    // 玩家已死亡，可以执行相应的操作
                    SceneManager.LoadScene(1);
                }
            }

            // 销毁子弹对象
            Destroy(gameObject);
            Debug.Log("Cheese Health: " + playerController.playerHealth);
        }

        if (collision.gameObject.CompareTag("Cheese2"))
        {
            // 在这里可以执行特定于玩家的操作
            // 获取玩家控制脚本
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // 减少芝士的生命值
                playerController.playerHealth--;
                // 加分
                playerController.playerScore += 3;

                // 处理玩家死亡逻辑
                if (playerController.playerHealth <= 0)
                {
                    // 玩家已死亡，可以执行相应的操作
                    SceneManager.LoadScene(1);
                }
            }

            // 销毁子弹对象
            Destroy(gameObject);
            Debug.Log("Cheese Health: " + playerController.playerHealth);
        }
    }
}
