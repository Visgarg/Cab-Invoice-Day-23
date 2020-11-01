// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tests.cs" company="Capgemini">
//   Copyright
// </copyright>
// <creator Name="Vishal Garg"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Cab_Invoice_TDD
{
    using NUnit.Framework;
    using CabInvoiceDay23;
    using System.Net.Http.Headers;

    /// <summary>
    /// adding class to do tests for program
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// gets total fare for one trip
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 2.0;
            int time = 5;

            //calculating fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }
        /// <summary>
        /// Givens the multiple rides should return invoice summary.
        /// </summary>
        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            //Creating instance of invoice generator 
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            //Generating Summary for rides
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            //Asserting values
            Assert.AreEqual(expectedSummary, summary);
        }
    }
}