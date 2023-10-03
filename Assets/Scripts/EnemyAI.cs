using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Параметры сценария
    public float speed = 5.0f; //скорость движения
    public float obstacleRange = 5.0f; //радиус зрения
    public bool _alive = true; //жив ли вообще

    //Снаряды
    [SerializeField]
    private GameObject[] _fireballsPrefab; //обойма
    private GameObject _fireball; //выстрел

    private void Start()
    {
        _alive = true;
    }

    private void Update()
    {
        if (_alive)
        {
            //Непрерывное движение вперед
            transform.Translate(0, 0, speed * Time.deltaTime); //Time.deltaTime чтобы количество кадров не влияло на скорость передвижения

            //Луч из объекта вперед
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit; //объект удара

            //Пускаем луч и проверяем
            if (Physics.Raycast(ray, out hit))
            {
                //Получаем объект удара
                GameObject hitObject = hit.transform.gameObject;
                //Если объект удара игрок
                if (hitObject.GetComponent<CharacterController>())
                {
                    //Если огненного шара нет
                    if (_fireball == null)
                    {
                        int randFireball = Random.Range(1, _fireballsPrefab.Length);
                        _fireball = Instantiate(_fireballsPrefab[randFireball]) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation; //в том же направлении
                    }
                }
                //Если игрока нет, то проверяем дистанцию до объекта впереди
                else if (hit.distance < obstacleRange)
                {
                    //Пора действовать
                    float angleRotation = Random.Range(-100, 100); //выбираем угол поворота
                    transform.Rotate(0, angleRotation, 0); //поворачиваемся
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}