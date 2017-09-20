using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Deals4All
{
    public class Customizations
    {
        private string Connection =Convert.ToString(ConfigurationManager.AppSettings["DBConnection"]);
        public int MerchantID(string email)
        {
            int merchant = 0;
            SqlConnection sqlcon = new SqlConnection(Connection);
            try
            {
                using (SqlCommand sqlcmd = new SqlCommand())
                {
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.CommandText = "GetMerchantDetails";
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@MerchantEmail", email);
                    sqlcon.Open();
                    merchant = Convert.ToInt32(sqlcmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return merchant;
        }


        public int CustomerID(string email)
        {
            int customer = 0;
            SqlConnection sqlcon = new SqlConnection(Connection);
            try
            {
                using (SqlCommand sqlcmd = new SqlCommand())
                {
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.CommandText = "GetCustomerDetails";
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@CustomerEmail", email);
                    sqlcon.Open();
                    customer = Convert.ToInt32(sqlcmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return customer;
        }




        //public int PublishCoupon(int CouponID)
        //{
        //    int PublishCoupon = 0;
        //    SqlConnection sqlcon = new SqlConnection(Connection);
        //    try
        //    {
        //        using (SqlCommand sqlcmd = new SqlCommand())
        //        {
        //            sqlcmd.Connection = sqlcon;
        //            sqlcmd.CommandText = "ProcPublishCoupon";
        //            sqlcmd.CommandType = CommandType.StoredProcedure;
        //            sqlcmd.Parameters.AddWithValue("@CustomerEmail", CouponID);
        //            sqlcon.Open();
        //            PublishCoupon = Convert.ToInt32(sqlcmd.ExecuteScalar());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        sqlcon.Close();
        //    }
        //    return PublishCoupon;
        //}



        public String RedeemCoupon(String CouponCode, int MerchantID, String CustomerEmail, String OrderTotal,ref  String Result)
        {
            SqlConnection sqlcon = new SqlConnection(Connection);
            try
            {
                using (SqlCommand sqlcmd = new SqlCommand())
                {
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.CommandText = "ProcRedeemCoupon";
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@CouponCode", CouponCode);
                    sqlcmd.Parameters.AddWithValue("@MerchantID", MerchantID);
                    sqlcmd.Parameters.AddWithValue("@CustomerEmail", CustomerEmail);
                    sqlcmd.Parameters.AddWithValue("@OrderTotal", OrderTotal);
                    //sqlcmd.Parameters.AddWithValue("@Result", CouponCode);
                    SqlParameter result = new SqlParameter("@Result", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };

                    sqlcmd.Parameters.Add(result);
                    sqlcon.Open();
                    
                    sqlcmd.ExecuteNonQuery();

                    Result = Convert.ToString(result.Value);
                     

                    

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return Result;
        }


    }
}