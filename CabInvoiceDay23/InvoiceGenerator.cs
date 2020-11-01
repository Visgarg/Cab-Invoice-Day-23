// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceGenerator.cs" company="Capgemini">
//   Copyright
// </copyright>
// <creator Name="Vishal Garg"/>
// --------------------------------------------------------------------------------------------------------------------

namespace CabInvoiceDay23
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;
    /// <summary>
    /// InvoiceGenerator class to calculate total fare of a trip
    /// </summary>
    public class InvoiceGenerator
    {
        //Variables
        private RideRepository rideRepository;
        //Constants
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceGenerator"/> class.
        /// </summary>
        public InvoiceGenerator()
        {
            this.rideRepository = new RideRepository();
            this.MINIMUM_COST_PER_KM = 10;
            this.COST_PER_TIME = 1;
            this.MINIMUM_FARE = 5;
        }

        /// <summary>
        /// Calculates the fare.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceDay23.CabInvoiceException">
        /// Invalid Distance
        /// or
        /// Invalid Time
        /// </exception>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch(CabInvoiceException)
            {
                if(distance<=0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if(time<=0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
        /// <summary>
        /// Calculates the fare for array of rides
        /// </summary>
        /// <param name="rides">The rides.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceDay23.CabInvoiceException">no rides found</exception>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            // checks for rides available and passes them to calculate fare method to calculate fare for each method
            try
            {
                //calculating total fare for all rides
                foreach(Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            //catches exception
            catch(CabInvoiceException)
            {
                if(rides==null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "no rides found");
                }
            }
            //returns invoice summary object 
            return new InvoiceSummary(rides.Length, totalFare);
        }
        /// <summary>
        /// Adds the rides in dictionary with key as a user id 
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        /// <exception cref="CabInvoiceDay23.CabInvoiceException">Null rides</exception>
        public void AddRides(string userId, Ride[] rides)
        {
            try
            {
                rideRepository.AddRide(userId, rides);
            }
            catch(CabInvoiceException)
            {
                if(rides==null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Null rides");
                }
            }
        }
        /// <summary>
        /// Gets the invoice summary by passing user id into ride repository and then passing rides array to calculate fares.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceDay23.CabInvoiceException">Invalid user id</exception>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user id");
            }
        }
    }
}
