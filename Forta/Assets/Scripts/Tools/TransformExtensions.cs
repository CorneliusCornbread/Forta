using UnityEngine;

namespace Forta.Tools
{
	public static class TransformExtensions
	{
        /// <summary>
        /// Takes a position in world space and converts it to local space, handles a null parent
        /// </summary>
        /// <param name="pos">Position to transform</param>
        /// <returns>World position in local space</returns>
        public static Vector3 ParentVectorLocalToWorld(this Transform transform, Vector3 pos)
        {
            if (transform.parent != null)
            {
                return transform.parent.TransformVector(pos);
            }

            else
            {
                return pos; //We don't do a transform, as there's no need, world space IS local space
            }
        }

        /// <summary>
        /// Takes a position in world space and converts it to local space, handles a null parent
        /// </summary>
        /// <param name="pos">Position to transform</param>
        /// <returns>World position in local space</returns>
        public static Vector2 ParentVectorLocalToWorld(this Transform transform, Vector2 pos)
        {
            if (transform.parent != null)
            {
                return transform.parent.TransformVector(pos);
            }

            else
            {
                return pos; //We don't do a transform, as there's no need, world space IS local space
            }
        }


        /// <summary>
        /// Takes a position in world space and converts it to local space, handles a null parent
        /// </summary>
        /// <param name="pos">Position to transform</param>
        /// <returns>World position in local space</returns>
        public static Vector3 ParentVectorWorldToLocal(this Transform transform, Vector3 pos)
        {
            if (transform.parent != null)
            {
                return transform.parent.InverseTransformVector(pos);
            }

            else
            {
                return pos; //We don't do a transform, as there's no need, local space IS world space
            }
        }

        /// <summary>
        /// Takes a position in world space and converts it to local space, handles a null parent
        /// </summary>
        /// <param name="pos">Position to transform</param>
        /// <returns>World position in local space</returns>
        public static Vector2 ParentVectorWorldToLocal(this Transform transform, Vector2 pos)
        {
            if (transform.parent != null)
            {
                return transform.parent.InverseTransformVector(pos);
            }

            else
            {
                return pos; //We don't do a transform, as there's no need, local space IS world space
            }
        }


        /// <summary>
        /// Takes a position in world space and converts it to local space, handles a null parent
        /// </summary>
        /// <param name="pos">Position to transform</param>
        /// <returns>World position in local space</returns>
        public static Vector2 ParentPointLocalToWorld(this Transform transform, Vector2 pos)
        {
            if (transform.parent != null)
            {
                return transform.parent.TransformPoint(pos);
            }

            else
            {
                return pos; //We don't do a transform, as there's no need, local space IS world space
            }
        }

        /// <summary>
        /// Takes a position in local space and covnerts it to local space, handles a null parent
        /// </summary>
        /// <param name="pos">Position the transform</param>
        /// <returns>Local position in world space</returns>
        public static Vector3 ParentPointWorldToLocal(this Transform transform, Vector3 pos)
        {
            if (transform.parent != null)
            {
                return transform.parent.TransformPoint(pos);
            }

            else
            {
                return pos; //We don't do a transform, as there's no need, world space IS local space
            }
        }


        /// <summary>
        /// Takes a position in local space and covnerts it to local space, handles a null parent
        /// </summary>
        /// <param name="pos">Position the transform</param>
        /// <returns>Local position in world space</returns>
        public static Vector2 ParentPointWorldToLocal(this Transform transform, Vector2 pos)
        {
            if (transform.parent != null)
            {
                return transform.parent.TransformPoint(pos);
            }

            else
            {
                return pos; //We don't do a transform, as there's no need, world space IS local space
            }
        }
    }
}