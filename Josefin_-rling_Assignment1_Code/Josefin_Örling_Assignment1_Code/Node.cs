using System;

namespace Josefin_Örling_Assignment1_Code
{
    public class Node
    {
        #region Fields

        /// <summary>
        /// Viewed item
        /// </summary>
        Item viewedItem;

        /// <summary>
        /// boolean to indicate whether the item is included or not
        /// </summary>
        bool isIncluded;

        /// <summary>
        /// Parent node
        /// </summary>
        Node parent;

        /// <summary>
        ///  Total Value
        /// </summary>
        int totalValue;

        /// <summary>
        /// Total Weight
        /// </summary>
        int totalWeight;
        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor
        /// Creates a new instance of Item()
        /// </summary>
        public Node()
        {
            parent = null;
            totalValue = 0;
            totalWeight = 0;
            viewedItem = new Item();
        }

        /// <summary>
        /// Constructor with three parameters
        /// Calculates the totalValue and totalWeight
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parent"></param>
        /// <param name="isIncluded"></param>
        public Node(Item item, Node parent, bool isIncluded)
        {
            if (parent != null)
            {
                this.parent = parent;
                viewedItem = item;
                this.isIncluded = isIncluded;
                if(isIncluded)
                {
                    totalValue += parent.totalValue + item.Value;
                    totalWeight += parent.totalWeight + item.Weight;
                }
                else
                {
                    totalValue += parent.totalValue;
                    totalWeight += parent.totalWeight;
                }
                
            }
        }
        #endregion Constructors

        #region Properties

        /// <summary>
        /// Property related to viewedItem field
        /// Just read access
        /// </summary>
        public Item ViewedItem => viewedItem;

        /// <summary>
        /// Property related to isIncluded field
        /// Just read access
        /// </summary>
        public bool IsIncluded => isIncluded;

        /// <summary>
        /// Property related to parent field
        /// Just read access
        /// </summary>
        public Node Parent => parent;

        /// <summary>
        /// Property related to totalValue field
        /// Just read access
        /// </summary>
        public int TotalValue => totalValue;

        /// <summary>
        /// Property related to totalWeight field
        /// Just read access
        /// </summary>
        public int TotalWeight => totalWeight;

        #endregion Properties

    }
}
