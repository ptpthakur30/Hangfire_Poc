// Copyright (c) 2020 Pankaj Thakur

namespace Hangfire_Poc.Business
{
    using Hangfire_Poc.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the IPersonBusiness
    /// </summary>
    public interface IPersonBusiness
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
        /// <returns>The <see cref="List{Person}"/></returns>
        List<Person> GetPersonById(int id);

        /// <summary>
        /// The GetPersonList
        /// </summary>
        /// <returns>The <see cref="List<Person>"/></returns>
        List<Person> GetPersonList();

        /// <summary>
        /// The DeleteEmployeeById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        bool DeleteEmployeeById(int id);

        bool UpdateEmployeeDetails(int id, Person person);
    }
}
