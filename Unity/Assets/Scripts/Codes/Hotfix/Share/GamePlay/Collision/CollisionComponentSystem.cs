﻿using Box2DSharp.Collision.Collider;
using Box2DSharp.Dynamics.Contacts;
using System.Collections.Generic;
using System.Numerics;

namespace ET
{
    [ObjectSystem]
    public class CollisionAwakeSystem : AwakeSystem<CollisionComponent>
    {
        protected override void Awake(CollisionComponent self)
        {
            
        }
    }
    [ObjectSystem]
    public class CollisionFixedUpdateSystem : FixedUpdateSystem<CollisionComponent>
    {
        protected override void FixedUpdate(CollisionComponent self)
        {
            self.FixedUpdate();
        }
    }
    
    [ObjectSystem]
    public class CollisionDestroySystem : DestroySystem<CollisionComponent>
    {
        protected override void Destroy(CollisionComponent self)
        {
            
        }
    }
    [FriendOf(typeof(CollisionComponent))]
    public static class CollisionComponentSystem
    {
        public static void Awake(this CollisionComponent self)
        {
            
        }
        
        /// <summary>
        /// 碰撞组件添加碰撞器
        /// </summary>
        /// <param name="self"></param>
        /// <param name="colliderType"></param>
        /// <param name="vec2"></param>
        /// <param name="offset"></param>
        /// <param name="isSensor"></param>
        /// <param name="userData"></param>
        /// <param name="angle"></param>
        public static void AddCollider(this CollisionComponent self, EColliderType colliderType, Vector2 vec2, Vector2 offset, bool isSensor, object userData, float angle = 0)
        {
            self.Body = self.WorldComponent.CreateDynamicBody();
            switch (colliderType)
            {
                case EColliderType.Circle:
                    self.Body.CreateCircleFixture(vec2.X, offset, isSensor, self.BattleUnit.Unit);

                    break;
                case EColliderType.Box:
                    self.Body.CreateBoxFixture(vec2.X, vec2.Y, offset, angle, isSensor, self.BattleUnit.Unit);

                    break;
            }
        }

        /// <summary>
        /// 每帧更新，同步位置、旋转等信息
        /// </summary>
        /// <param name="self"></param>
        public static void FixedUpdate(this CollisionComponent self)
        {
            
        }


    }
}