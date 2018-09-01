//-----------------------------------------------------------------------
// <copyright file="Person.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DomainLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The person who posts a bid or who bidds
    /// </summary>
    public class Person
    {  
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value> 
        public string Name { get; set; }

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>true if they are equal.</returns>
        public bool Equals(Person other)
        {
            return this.Id.Equals(other.Id);
        } 

        /// <summary>
        /// Builds a Person
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// The pending person which would be built
            /// </summary>
            private Person pending;

            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            public Builder()
            {
                this.pending = new Person();
            }
             
            /// <summary>
            /// Sets the identifier.
            /// </summary>
            /// <param name="id">The identifier.</param>
            public void SetId(int id)
            {
                this.pending.Id = id;
            }

            /// <summary>
            /// Sets the name of the new person.
            /// </summary>
            /// <param name="name">The name.</param>
            public void SetName(string name)
            {
                this.pending.Name = name;
            }

            /// <summary>
            /// Builds this instance.
            /// </summary>
            /// <returns>The just created person.</returns>
            public Person Build()
            { 
                ////if (this.pending.Id.Length == 0)
                ////{
                ////    return null;
                ////}

                if (string.IsNullOrWhiteSpace(this.pending.Name))
                {
                    return null;
                }

                return this.pending;
            }
        }
    }
}
