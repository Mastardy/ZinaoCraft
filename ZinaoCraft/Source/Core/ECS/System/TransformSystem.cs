﻿using OpenTK.Mathematics;

namespace ZinaoCraft;

public class TransformSystem : ISystem
{
    public void Update()
    {
        var transforms = World.GetComponents<Transform>();
        if (transforms == null) return;

        for (int i = 0; i < transforms.Count; i++)
        {
            var renderable = transforms[i].parent.GetComponent<Renderable>();
            if (renderable == null) continue;

            renderable.Material.ChangeUniform("transform", transforms[i].Matrix);
        }
    }
}