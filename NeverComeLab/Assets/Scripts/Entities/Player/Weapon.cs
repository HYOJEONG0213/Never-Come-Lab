using UnityEngine;

//몬스터->플레이어 공격 관련, 피격 효과 필요, 몬스터 공격시 여러번 적용되는 버그 수정 필요 

public class Weapon : MonoBehaviour
{
    [Header("# References")]
    public Transform pos;
    Player player;
    Vector3 inputVec;

    [Header("# Weapon Info")]
    public int id;
    public int prefabId;
    public float damage;
    public bool isSelected;
    public ItemData Itemdata;

    [Header("# Stats")]
    public float fireRate;
    public AudioManager.Sfx fireSound;

    float timer;

    private void Awake()
    {
        //Init();
        player = GameManager.Instance.player;
        pos = GetComponent<Transform>();
    }
    
    private void Update()
    {
        if (player.isDie) return;

        isSelected = Itemdata.isSelected;
        if (isSelected == false) return;

        timer += Time.deltaTime;

        if(timer > fireRate)
        {
            timer = 0f;
            Fire();
        }
    }

    public void Init(ItemData data)
    {
        Itemdata = data;

        //기본 셋팅
        name = "Weapon " + data.itemId;
        transform.parent = player.transform;    //weapon 부모를 player로 지정 
        transform.localPosition = Vector3.zero;    //지역위치로 함으로써 플레이어 안으로 지정

        //속성 셋팅
        id = data.itemId;
        damage = data.baseDamage;
        isSelected = data.isSelected;

        prefabId = GameManager.Instance.pool.GetPrefabId(data.projectile);

        fireRate = data.fireRate;
        fireSound = data.fireSound;
        
    }



    void Fire()
    {
        if(player == null || player.anim == null || player.spriter == null)
        {
            return;
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotation = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;    //dir 각 구하기 * 라디안을 도로 바꾸기
        transform.rotation = Quaternion.Euler(0, 0, rotation); //실제겜 오브젝트 회전값으로 설정

        
        //바로앞에 벽있는지 확인, 벽있다면 발사 안하게끔 return 
        float rayDistance = 0.03f;
        Vector2 bulletDirection = new Vector2(Mathf.Cos(rotation * Mathf.Deg2Rad), Mathf.Sin(rotation * Mathf.Deg2Rad));
        //Debug.DrawLine(transform.position, bulletDirection * rayDistance, Color.red, 1f); // 1초간 지속

        RaycastHit2D hit = Physics2D.Raycast(transform.position, bulletDirection, rayDistance, ~LayerMask.GetMask("Bullet"));

        if (hit.collider != null)
        {
            //print("Hit object: " + hit.collider.gameObject.name);
            if (hit.collider.CompareTag("Wall"))
            {
                return;
            }
        }

        AudioManager.instance.PlaySfx(fireSound);

        //벽이 없다면 총알 정상 생성 
        GameObject bullet = GameManager.Instance.pool.Get(prefabId);    //기존 오브젝트 재활용 하기 

        //bullet.transform.position = pos.position;
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        BaseBullet baseBullet = bullet.GetComponent<BaseBullet>();
        if (baseBullet != null)
        {
            baseBullet.Init(damage);
        }
    }


}
