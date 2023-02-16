using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josefin_Örling_Assignment1_Code
{
    public class Item
    {
        #region Fields
        /// <summary>
        /// Item id
        /// </summary>
        int id;
        /// <summary>
        /// Item weight
        /// </summary>
        int weight;
        /// <summary>
        /// Item value
        /// </summary>
        int value;
        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Item() : this(0, 0, 0) 
        {
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        /// <param name="id">Item id</param>
        /// <param name="weight">Item weight</param>
        /// <param name="value">Item Value</param>
        public Item(int id, int weight, int value)
        {
            this.id = id;
            this.weight = weight;
            this.value = value;
        }
        #endregion Constructors

        #region Properties

        /// <summary>
        /// Property related to id field
        /// Just read access
        /// </summary>
        public int Id => id;

        /// <summary>
        /// Property related to weight field
        /// Just read access
        /// </summary>
        public int Weight => weight;

        /// <summary>
        /// Property related to value field
        /// Just read access
        /// </summary>
        public int Value => value;
        #endregion Properties
    }
}
