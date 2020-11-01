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

    /// <summary>
    /// adding class to do tests for program
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Test1s this instance.
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
    }
}