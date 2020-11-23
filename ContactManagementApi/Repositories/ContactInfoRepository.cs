using ContactManagementApi.Constants;
using ContactManagementApi.Interfaces;
using ContactManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ContactManagementApi.Repositories
{
    public class ContactInfoRepository: IContactRepository
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["SqlContactCon"].ConnectionString;

        public IEnumerable<Contact> GetAllContacts()
        {
            var ContactList = new List<Contact>();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    using (SqlCommand command = new SqlCommand(StoredProcudureConstants.sp_GetAll, sqlCon))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var contact = new Contact();
                                contact.Id = Convert.ToInt32(reader[StoredProcudureConstants.out_Id]);
                                contact.FirstName = reader[StoredProcudureConstants.out_FirstName].ToString();
                                contact.LastName = reader[StoredProcudureConstants.out_LastName].ToString();
                                contact.Email = reader[StoredProcudureConstants.out_Email].ToString();
                                contact.PhoneNumber = reader[StoredProcudureConstants.out_PhoneNumber].ToString();
                                contact.Status = reader[StoredProcudureConstants.out_Status].ToString();
                                ContactList.Add(contact);
                            }
                        }
                    }
                    return ContactList;
                }
            }
            catch (Exception)
            {
                return null;
            }
           
        }

        public bool CreateContact(Contact contact)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(StoredProcudureConstants.sp_Insert, sqlCon))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(StoredProcudureConstants.in_FirstName, contact.FirstName);
                        command.Parameters.AddWithValue(StoredProcudureConstants.in_LastName, contact.LastName);
                        command.Parameters.AddWithValue(StoredProcudureConstants.in_Email, contact.Email);
                        command.Parameters.AddWithValue(StoredProcudureConstants.in_PhoneNumber, contact.PhoneNumber);
                        command.Parameters.AddWithValue(StoredProcudureConstants.in_Status, contact.Status);
                        sqlCon.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public bool UpdateContact(int id, Contact contact)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(StoredProcudureConstants.sp_Update, sqlCon))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(StoredProcudureConstants.in_Id, id);
                        command.Parameters.AddWithValue(StoredProcudureConstants.in_FirstName, contact.FirstName);
                        command.Parameters.AddWithValue(StoredProcudureConstants.in_LastName, contact.LastName);
                        command.Parameters.AddWithValue(StoredProcudureConstants.in_Email, contact.Email);
                        command.Parameters.AddWithValue(StoredProcudureConstants.in_PhoneNumber, contact.PhoneNumber);
                        command.Parameters.AddWithValue(StoredProcudureConstants.in_Status, contact.Status);
                        sqlCon.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public bool DeleteContact(int id)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(StoredProcudureConstants.sp_Delete, sqlCon))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue(StoredProcudureConstants.in_Id, id);
                        sqlCon.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}