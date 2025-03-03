using UnityEngine;

public class WaveController : MonoBehaviour
{
    public WaveData waveData;

    void Start()
    {
        for (int i = 0; i < waveData.enemyCount; ++i) 
        {
			Instantiate(waveData.enemyPrefab);
        }
	}
}
