using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private List<AudioSource> sources = new List<AudioSource>();

    [SerializeField] private AudioSource _sourcePrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        for (int i = sources.Count - 1; i >= 0; i--)
        {
            if (!sources[i].isPlaying)
            {
                Destroy(sources[i].gameObject);
                sources.RemoveAt(i);
            }
        }
    }

    public void PlaySound(AudioClip clip, Vector2 pos, bool loop = false)
    {
        AudioSource source = Instantiate(_sourcePrefab);
        source.transform.position = pos;

        source.loop = loop;
        source.clip = clip;
        source.Play();
        sources.Add(source);
    }
}
