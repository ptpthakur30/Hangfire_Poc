namespace Hangfire_Poc.Repository
{
    /// <summary>
    /// Defines the <see cref="StaticConstants" />
    /// </summary>
    public class StaticConstants
    {
        /// <summary>
        /// Defines the TestConnectionString
        /// </summary>
        public static readonly string TestConnectionString = "test";

        /// <summary>
        /// Defines the <see cref="SetEmployeeDetails" />
        /// </summary>
        public struct SetEmployeeDetails
        {
            /// <summary>
            /// Defines the Procedure
            /// </summary>
            public static readonly string Procedure = "Core_SP_InsertEmpoyeeDetails";

            /// <summary>
            /// Defines the <see cref="Parameters" />
            /// </summary>
            public struct Parameters
            {
                /// <summary>
                /// Defines the Id
                /// </summary>
                public static readonly string Id = "@ID";

                /// <summary>
                /// Defines the FirstName
                /// </summary>
                public static readonly string FirstName = "@FirstName";

                /// <summary>
                /// Defines the LastName
                /// </summary>
                public static readonly string LastName = "@LastName";

                /// <summary>
                /// Defines the PayRate
                /// </summary>
                public static readonly string PayRate = "@PayRate";

                /// <summary>
                /// Defines the StartDate
                /// </summary>
                public static readonly string StartDate = "@StartDate";

                /// <summary>
                /// Defines the EndDate
                /// </summary>
                public static readonly string EndDate = "@EndDate";
            }
        }

        /// <summary>
        /// Defines the <see cref="DeleteEmployeeById" />
        /// </summary>
        public struct DeleteEmployeeById
        {
            /// <summary>
            /// Defines the Procedure
            /// </summary>
            public static readonly string Procedure = "Core_SP_DeleteEmployeeById";

            /// <summary>
            /// Defines the <see cref="Parameters" />
            /// </summary>
            public struct Parameters
            {
                /// <summary>
                /// Defines the Id
                /// </summary>
                public static readonly string Id = "@ID";
            }
        }

        /// <summary>
        /// Defines the <see cref="GetPersonById" />
        /// </summary>
        public struct GetPersonById
        {
            /// <summary>
            /// Defines the Procedure
            /// </summary>
            public static readonly string Procedure = "Core_SP_GetEmployeeDetails";

            /// <summary>
            /// Defines the <see cref="Parameters" />
            /// </summary>
            public struct Parameters
            {
                /// <summary>
                /// Defines the Id
                /// </summary>
                public static readonly string Id = "@ID";
            }
        }

        public struct UpdateEmployeeDetails
        {
            /// <summary>
            /// Defines the Procedure
            /// </summary>
            public static readonly string Procedure = "Core_SP_UpdateEmpoyeeDetails";

            /// <summary>
            /// Defines the <see cref="Parameters" />
            /// </summary>
            public struct Parameters
            {
                /// <summary>
                /// Defines the Id
                /// </summary>
                public static readonly string Id = "@ID";

                /// <summary>
                /// Defines the FirstName
                /// </summary>
                public static readonly string FirstName = "@FirstName";

                /// <summary>
                /// Defines the LastName
                /// </summary>
                public static readonly string LastName = "@LastName";

                /// <summary>
                /// Defines the PayRate
                /// </summary>
                public static readonly string PayRate = "@PayRate";

                /// <summary>
                /// Defines the StartDate
                /// </summary>
                public static readonly string StartDate = "@StartDate";

                /// <summary>
                /// Defines the EndDate
                /// </summary>
                public static readonly string EndDate = "@EndDate";
            }
        }

    }
}
