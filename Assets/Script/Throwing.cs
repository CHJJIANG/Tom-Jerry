using UnityEngine;

public class Throwing : MonoBehaviour
{
    public GameObject bulletPrefab; // 用于发射的子弹预制体
    public Transform firePoint; // 发射点
    public float minThrowForce = 10f; // 最小投掷力量
    public float maxThrowForce = 25f; // 最大投掷力量
    public float maxThrowAngle = 90f; // 最大发射角度（度数）

    private float chargeStartTime;
    private bool isCharging = false;
    private float maxChargeTime = 2f; // 最长允许充能时间（秒）
    private bool canShoot = true; // 控制玩家是否可以发射子弹

    void Update()
    {
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                chargeStartTime = Time.time;
                isCharging = true;
            }

            if (Input.GetKeyUp(KeyCode.S) && isCharging)
            {
                isCharging = false;
                float chargeTime = Mathf.Clamp(Time.time - chargeStartTime, 0f, maxChargeTime); // 限制充能时间
                float throwForce = Mathf.Lerp(minThrowForce, maxThrowForce, chargeTime / maxChargeTime); // 根据充能时间计算力量

                float throwAngle = Mathf.Lerp(maxThrowAngle, 0f, chargeTime / maxChargeTime); // 根据充能时间计算角度

                ThrowBullet(throwForce, throwAngle);
            }
        }
    }

    void ThrowBullet(float throwForce, float throwAngle)
    {
        // 获取发射点的位置和角度
        Vector3 spawnPosition = firePoint.position;
        Quaternion spawnRotation = firePoint.rotation;

        // 创建子弹实例并设置位置和角度
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, spawnRotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // 计算子弹的方向
        Vector2 forceDirection = Quaternion.Euler(0, 0, throwAngle) * Vector2.up;

        // 添加力量
        rb.AddForce(forceDirection * throwForce, ForceMode2D.Impulse);

        // 销毁子弹当它碰到地板或飞出屏幕外
        Destroy(bullet, 5f); // 5秒后销毁，可根据需要调整时间

        // 设置玩家不能发射新子弹，直到上一颗子弹消失
        canShoot = false;
    }

    void FixedUpdate()
    {
        // 如果没有子弹存在，允许玩家发射新子弹
        if (!canShoot && !GameObject.FindGameObjectWithTag("Bullet"))
        {
            canShoot = true;
        }
    }
}



