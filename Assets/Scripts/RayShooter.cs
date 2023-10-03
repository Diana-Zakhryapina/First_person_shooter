using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    //Объект камеры
    private Camera _camera;

    private void Start()
    {
        // Получаем данные о камере
        _camera = GetComponent<Camera>();

        //Скроем указатель мыши в Game окошке
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Проверяем, когда нажимаем на "выстрел"
        if (Input.GetMouseButtonDown(0))
        {
            //Запоминаем центр экрана
            Vector3 screenCenter = new Vector3(Screen.width/2, Screen.height/2, 0);

            //Пускаем луч из центра экрана относительно камеры
            Ray ray = _camera.ScreenPointToRay(screenCenter);
            RaycastHit hit; //улавливаем попадание в эту переменную

            //Если попали в какой-то объект
            if(Physics.Raycast(ray, out hit)) //пускаем луч ray результат столкновения считываем в hit
            {
                //Распознавание попаданий в цель
                GameObject hitObject = hit.transform.gameObject; //получаем объект, в который попали
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>(); //получаем компонент этого объекта

                //Проверим, попадание в мишень
                if (target != null)
                {
                    target.ReactToHit();
                }
                else //значит попали в стену
                {
                    //Запускаем сопрограмму
                    StartCoroutine(SphereInicatorCoroutine(hit.point));
                    //Рисуем отладочную линию, чтобы проследить траекторию луча
                    Debug.DrawLine(this.transform.position, hit.point, Color.green, 6);
                }
            }
        }
    }

    private void OnGUI()
    {
        //Добавление визуального индикатора в центре экрана
        int size = 12; //просто для более правильной пропорции
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    //Сопрограмма, создающая сферу в месте попадания
    private IEnumerator SphereInicatorCoroutine(Vector3 pos)
    {
        //Создадим игровой объект - сферу
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos; //указываем позицию сферы

        //yield - ключевое слово для сопрограммы, указывающее ей, что пора остановиться
        yield return new WaitForSeconds(6); //время ожидания
        //После ожидания вернется в эту часть сопрограммы
        Destroy(sphere); //удалим сферу
    }
}
