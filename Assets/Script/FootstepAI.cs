using UnityEngine; // Подключаем библиотеку Unity для работы с функциями и объектами Unity
using System.Collections; // Подключаем библиотеку для работы с коллекциями данных
using Invector.vCharacterController.AI; // Подключаем библиотеку  от Invector для работы с контроллером персонажа
using FMODUnity; // Подключаем библиотеку FMODUnity для работы с звуками и музыкой

public class FootstepAI : MonoBehaviour // Объявляем класс FmodFootstep, который наследуется от MonoBehaviour
{
    
    public EventReference walkingEvent; // Объявляем публичную строковую переменную walkingEvent для звуков ходьбы
    
    public EventReference jumpEvent; // Объявляем публичную строковую переменную jumpEvent для звука прыжка
    
    public EventReference runEvent; // Объявляем публичную строковую переменную runEvent для звука бега
    
    public EventReference rollEvent; // Объявляем публичную строковую переменную rollEvent для звука кувырка

    public EventReference attackEvent;

    public EventReference damageEvent;
    vAIMotor AAA; // Объявляем переменную AAA типа vAIMotor 
    vControlAIMelee vAI;
    


    FMOD.Studio.EventInstance walkingInstance; // Объявляем переменную footstepEvent типа FMOD.Studio.EventInstance для воспроизведения звука ходьбы
    FMOD.Studio.EventInstance runInstance;
    FMOD.Studio.EventInstance jumpInstance;
    FMOD.Studio.EventInstance rollInstance;
    public LayerMask lm;   // Объявляем публичную переменную lm типа LayerMask для работы с маской слоев
    float Material;  // Объявляем переменную Material типа float для хранения информации о материале поверхности

    void Start()
    {
        AAA = gameObject.GetComponent<vAIMotor>(); // Получаем компонент vAIMotor
        vAI = gameObject.GetComponent<vControlAIMelee>();
        

    }

    void footstepPlayer()
    {

    }
    void footstepPlayerJump() { }
    
    void footstepPlayerRoll() { } 
    void footstepPlayerLand() { }

        void FootstepsAI()
    {

        if (AAA.input.magnitude > 0.1) // Проверяем, превышает ли величина ввода по модулю 0.1
        {
            MaterialCheck();
            if (AAA.isJumping == false) // Проверяем, не прыгает ли персонаж
            {
                if (AAA.movementSpeed == vAIMovementSpeed.Running)
                {
                    runInstance = FMODUnity.RuntimeManager.CreateInstance(runEvent);
                    FMODUnity.RuntimeManager.AttachInstanceToGameObject(runInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
                    runInstance.setParameterByName("MaterialCheck", Material);
                    runInstance.start();
                    runInstance.release();
                }
                else
                {

                    walkingInstance = FMODUnity.RuntimeManager.CreateInstance(walkingEvent);
                    FMODUnity.RuntimeManager.AttachInstanceToGameObject(walkingInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
                    walkingInstance.setParameterByName("MaterialCheck", Material);
                    walkingInstance.start();
                    walkingInstance.release();
                }

            }
            else
            {
                walkingInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                walkingInstance.release();
                runInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                runInstance.release();
            }

        }

        void Attack()
        {
            FMODUnity.RuntimeManager.PlayOneShot(attackEvent, gameObject.transform.position);
        }
        void Damage()
        {
            FMODUnity.RuntimeManager.PlayOneShot(damageEvent, gameObject.transform.position);
        }




        // Функция MaterialCheck проверяет материал, по которому идет персонаж
        void MaterialCheck()
        {
            RaycastHit rh;

            if (Physics.Raycast(gameObject.transform.position, Vector3.down, out rh, 0.3f, lm))
            {
                if (rh.collider != null)
                {
                    Debug.Log("Raycast hit: " + rh.collider.tag);

                    switch (rh.collider.tag)
                    {
                        case "Concrete":
                            Material = 0;
                            break;
                        case "Wood":
                            Material = 1;
                            break;
                        case "Carpet":
                            Material = 2;
                            break;

                        default:
                            Material = 0;
                            break;
                    }
                }
            }
        }
    }
}
