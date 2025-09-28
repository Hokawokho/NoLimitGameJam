using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Gameplay
{
    public class StarsUI : MonoBehaviour
    {
        [SerializeField] List<Image> stars = new List<Image>();
        
        [SerializeField] Color starColor = Color.white; 
        [SerializeField] Color highlightColor = Color.yellow;

        public void UpdateRating(int rating)
        {
            stars.ForEach((i) => i.color = starColor);
            for (var i = 0; i < rating; i++)
            {
                stars[i].color = highlightColor;
            }
        }
    }
}