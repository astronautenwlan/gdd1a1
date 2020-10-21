using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RendererExtensions
{
    // this checks, if an object is visible to the current camera / renderer
    public static bool isVisibleFrom(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}
