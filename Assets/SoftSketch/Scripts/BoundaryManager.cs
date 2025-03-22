using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Taichi.Soft2D.Generated;
using Taichi.Soft2D.Plugin;
using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    private ETrigger _eTrigger;

    private void Awake()
    {
        _eTrigger = GetComponent<ETrigger>();
    }

    private void Update()
    {
        _eTrigger.InvokeCallbackAsync(ManipulateParticles);
    }

    [AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
    public static void ManipulateParticles(IntPtr particles, uint size)
    {
        int particleSize = Marshal.SizeOf<S2Particle>();
        for (int i = 0; i < size; i++)
        {
            IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
            S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
            particle.is_removed = 1;
            Marshal.StructureToPtr(particle, particlePtr, false);
        }
    }
}
