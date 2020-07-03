// Copyright (c) 2020 Pankaj Thakur

namespace Hangfire_Poc.Repository
{
    using Hangfire_Poc.Models;
    using System.Data;

    /// <summary>
    /// Defines the IPersonRepository
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// The SetEmployeeDetails
        /// </summary>
        /// <param name="person">The person Person</param>
        /// <returns>The bool</returns>
        bool SetEmployeeDetails(Person person);

        /// <summary>
        /// The GetPersonById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable GetPersonById(int id);

        /// <summary>
        /// The GetPersonList
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable GetPersonList();

        /// <summary>
        /// The DeleteEmployeeById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        bool DeleteEmployeeById(int id);

        bool UpdateEmployeeDetails(int id, Person person);
    }
}
