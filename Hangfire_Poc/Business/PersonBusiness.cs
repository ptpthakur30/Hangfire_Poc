// Copyright (c) 2020 Pankaj Thakur

namespace Hangfire_Poc.Business
{
    using Hangfire_Poc.Models;
    using Hangfire_Poc.Repository;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Defines the PersonBusiness
    /// </summary>
    public class PersonBusiness : IPersonBusiness
    {
        /// <summary>
        /// Defines the personRepository
        /// </summary>
        private IPersonRepository personRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBusiness"/> class.
        /// </summary>
        public PersonBusiness()
        {
            personRepository = new PersonRepository();
        }

        /// <summary>
        /// The SetEmployeeDetails
        /// </summary>
        /// <param name="person">The person Person</param>
        /// <returns>The bool</returns>
        public bool SetEmployeeDetails(Person person) => personRepository.SetEmployeeDetails(person);

        /// <summary>
        /// The GetPersonById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="List{Person}"/></returns>
        public List<Person> GetPersonById(int id)
        {
            List<Person> lstPerson = new List<Person>();
            DataTable dtPerson = personRepository.GetPersonById(id);
            if (dtPerson.Rows?.Count > 0)
            {
                //foreach (DataRow dr in dtPerson.Rows)
                //{
                //    lstPerson.Add(new Person()
                //    {
                //        Id = dr[StaticConstants.ID] == DBNull.Value ? 0 : Convert.ToInt64(dr[StaticConstants.ID]),
                //        FirstName = dr[StaticConstants.FirstName] == DBNull.Value ? string.Empty : Convert.ToString(dr[StaticConstants.FirstName]),
                //        LastName = dr[StaticConstants.LastName] == DBNull.Value ? string.Empty : Convert.ToString(dr[StaticConstants.LastName]),
                //        PayRate = dr[StaticConstants.PayRate] == DBNull.Value ? 0 : Convert.ToDouble(dr[StaticConstants.PayRate]),
                //        StartDate = dr[StaticConstants.StartDate] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[StaticConstants.StartDate]),
                //        EndDate = dr[StaticConstants.EndDate] == DBNull.Value ? DateTime.MaxValue : Convert.ToDateTime(dr[StaticConstants.EndDate])
                //    });
                //}
                lstPerson = Helper.DatatableToList<Person>(dtPerson);

            }
            return lstPerson;
        }

        /// <summary>
        /// The GetPersonList
        /// </summary>
        /// <returns>The <see cref="ArrayList"/></returns>
        public List<Person> GetPersonList()
        {
            List<Person> lstPerson = new List<Person>();
            DataTable dtPerson = personRepository.GetPersonList();
            if (dtPerson.Rows?.Count > 0)
            {
                //foreach (DataRow dr in dtPerson.Rows)
                //{
                //    lstPerson.Add(new Person()
                //    {
                //        Id = dr[StaticConstants.ID] == DBNull.Value ? 0 : Convert.ToInt64(dr[StaticConstants.ID]),
                //        FirstName = dr[StaticConstants.FirstName] == DBNull.Value ? string.Empty : Convert.ToString(dr[StaticConstants.FirstName]),
                //        LastName = dr[StaticConstants.LastName] == DBNull.Value ? string.Empty : Convert.ToString(dr[StaticConstants.LastName]),
                //        PayRate = dr[StaticConstants.PayRate] == DBNull.Value ? 0 : Convert.ToDouble(dr[StaticConstants.PayRate]),
                //        StartDate = dr[StaticConstants.StartDate] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[StaticConstants.StartDate]),
                //        EndDate = dr[StaticConstants.EndDate] == DBNull.Value ? DateTime.MaxValue : Convert.ToDateTime(dr[StaticConstants.EndDate])
                //    });
                //}
                lstPerson = Helper.DatatableToList<Person>(dtPerson);

            }
            return lstPerson;

        }

        /// <summary>
        /// The DeleteEmployeeById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool DeleteEmployeeById(int id) => personRepository.DeleteEmployeeById(id);
        public bool UpdateEmployeeDetails(int id, Person person) => personRepository.UpdateEmployeeDetails(id, person);
    }
}
