// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RideRepository.cs" company="Capgemini">
//   Copyright
// </copyright>
// <creator Name="Vishal Garg"/>
// --------------------------------------------------------------------------------------------------------------------

namespace CabInvoiceDay23
{
    using System;
    using System.Collections.Generic;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;
    public class RideRepository
    {
        //Dictionary to store UserId and Rides int List.
        Dictionary<string, List<Ride>> userRides = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Adds ride of a customer in list and then to a dictionary with user id as a key.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="rides">The rides array with datatype ride</param>
        /// <exception cref="CabInvoiceDay23.CabInvoiceException">Rides are null</exception>
        public void AddRide(string  userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if(!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }

        /// <summary>
        /// Gets the rides for specific user id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns> retruns the array of all the rides of user in form of array</returns>
        /// <exception cref="CabInvoiceDay23.CabInvoiceException">Invalid User id</exception>
        public Ride[] GetRides(string userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid User id");
            }
        }
    }
}
