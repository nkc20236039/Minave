/* ---------------------- */
/*  MonoBehaviour管理エリア */
/* ---------------------- */
using Cysharp.Threading.Tasks;
using Unity.Entities;
using UnityEngine;

public class MonoGate : MonoBehaviour
{
    private Entity entity;
    private EntityManager entityManager;
    private DemoSystem system;
    private int speed;
    private int returnSpeed;
    private bool isCompleted;

    private void Start()
    {
        Initalize();
    }

    private async void Initalize()
    {
        // EntityManagerを取得
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        system = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<DemoSystem>();

        // Entityの更新のために1フレーム待つ
        await UniTask.NextFrame();
        entityManager.CreateEntity(typeof(DemoComponent));

        // エンティティを取得する
        entity = entityManager.CreateEntityQuery(typeof(DemoComponent)).GetSingletonEntity();

        isCompleted = true;
    }

    private void Update()
    {
        if (!isCompleted) { return; }

        entityManager.AddComponentData(entity, new DemoComponentTag { Speed = speed });

        Debug.Log($"現在の速度:{speed}\n戻ってきた速度{system.speed}");

        speed++;
    }
}
