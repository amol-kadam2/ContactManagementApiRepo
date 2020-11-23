using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagementApi.Constants
{
    public static class StoredProcudureConstants
    {
        //Stored Procedure constants
        public static readonly string sp_GetAll = "sp_GetAllContacts";
        public static readonly string sp_Insert = "sp_CreateContact";
        public static readonly string sp_Update = "sp_UpdateContact";
        public static readonly string sp_Delete = "sp_DeleteContact";

        //Out parameters constants
        public static readonly string out_Id = "Id";
        public static readonly string out_FirstName = "FirstName";
        public static readonly string out_LastName = "LastName";
        public static readonly string out_Email = "Email";
        public static readonly string out_PhoneNumber = "PhoneNumber";
        public static readonly string out_Status = "Status";

        //In parameters constants
        public static readonly string in_Id = "@id";
        public static readonly string in_FirstName = "@first_name";
        public static readonly string in_LastName = "@last_name";
        public static readonly string in_Email = "@email";
        public static readonly string in_PhoneNumber = "@phone_number";
        public static readonly string in_Status = "@status";
    }
}