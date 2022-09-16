using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int offence; // 파워
    [SerializeField] private int offenceSpeed; // 연사
    [SerializeField] private int defence; // 방어력
    [SerializeField] private int health; // 체력

    [SerializeField] private int point;
    [SerializeField] private int score;
    [SerializeField] private EnemyOffenceType type;

    private float offenceDelay;

    private GameObject bullet;

    public void Initialize(
        int offence,
        int offenceSpeed,
        int defence,
        int health,
        int point,
        int score,
        EnemyOffenceType type
    )
    {
        this.offence = offence;
        this.offenceSpeed = offenceSpeed;
        this.defence = defence;
        this.health = health;
        this.point = point;
        this.score = score;
        this.type = type;
    }

    public void SetBullet(GameObject bullet)
    {
        this.bullet = bullet;
    }

    public EnemyOffenceType getType()
    {
        return this.type;
    }

    private void Update() // todo 이거 태형이가 하는 방식으로 변경
    {
        offenceDelay += Time.deltaTime;

        if (offenceDelay > offenceSpeed)
        {
            Attack();
            offenceDelay = 0; // initialize
        }
    }

    private void Attack() // todo type 별로 공격에 대한 것 만들기
    {
        Debug.Log(type + " 공격");

        if (type == EnemyOffenceType.REMOTE_AND_SINGLE || type == EnemyOffenceType.REMOTE_AND_MULTI)
        {
            bullet.transform.position = transform.position;
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector3 dirVec = Vector3.down;
            rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
        }
    }

    // todo 죽었을 때 상호작용 interface ?
}