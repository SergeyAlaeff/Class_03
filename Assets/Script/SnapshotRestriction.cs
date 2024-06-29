using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SnapshotRestriction : MonoBehaviour
{
    // Структура для хранения информации о снимке и его приоритете
    private struct SnapshotInfo
    {
        public FMOD.Studio.EventInstance instance;
        public int priority; // Чем выше число, тем выше приоритет

        public SnapshotInfo(FMOD.Studio.EventInstance instance, int priority)
        {
            this.instance = instance;
            this.priority = priority;
        }
    }

    private static List<SnapshotInfo> activeSnapshots = new List<SnapshotInfo>();

    public static void ActivateSnapshot(EventReference snapshotToActivate, int priority)
    {
        var instance = RuntimeManager.CreateInstance(snapshotToActivate);
        var newSnapshot = new SnapshotInfo(instance, priority);
        instance.start();

        activeSnapshots.Add(newSnapshot);
        activeSnapshots.Sort((a, b) => b.priority.CompareTo(a.priority)); // Сортируем по убыванию приоритета

        // Останавливаем все снимки с более низким приоритетом
        for (int i = 1; i < activeSnapshots.Count; i++)
        {
            activeSnapshots[i].instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    public static void DeactivateSnapshot(EventReference snapshotToDeactivate)
    {
        for (int i = 0; i < activeSnapshots.Count; i++)
        {
            if (activeSnapshots[i].instance.handle == RuntimeManager.CreateInstance(snapshotToDeactivate).handle)
            {
                activeSnapshots[i].instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                activeSnapshots.RemoveAt(i);
                break;
            }
        }

        if (activeSnapshots.Count > 0)
        {
            // Возобновляем снимок с наивысшим приоритетом
            activeSnapshots[0].instance.start();
        }
    }
}