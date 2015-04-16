using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1_2_David_Rodier
{
   public class USERS : SqlExpressUtilities.SqlExpressWrapper
   {
      public int ID { get; set; }
      public String UserName { get; set; }
      public String Password { get; set; }
      public String FullName { get; set; }
      public String Email { get; set; }
      public USERS(String connexionString, System.Web.UI.Page Page)
         : base(connexionString, Page)
      {
         SQLTableName = "USERS";
      }
      public override void GetValues()
      {
         ID = int.Parse(FieldsValues[0]);
         UserName = FieldsValues[1];
         Password = FieldsValues[2];
         FullName = FieldsValues[3];
         Email = FieldsValues[4];
      }
      public override void Insert()
      {
         InsertRecord(ID, UserName, Password, FullName, Email);
      }
      public override void Update()
      {
         UpdateRecord(ID, UserName, Password, FullName, Email);
      }

      public bool Username_Exist(String username)
      {
         QuerySQL("SELECT * FROM " + SQLTableName + " WHERE USERNAME = '" + username + "'");
         //if (reader.HasRows) 
         //    GetValues(); 
         return reader.HasRows;
      }
      public bool CheckPassword(String username, String password)
      {
         QuerySQL("SELECT * FROM " + SQLTableName + " WHERE USERNAME = '" + username + "' AND PASSWORD='" + password + "'");
         //if (reader.HasRows) 
         //    GetValues(); 
         return reader.HasRows;
      }
      public String Getpassword(String username)
      {
         QuerySQL("SELECT PASSWORD FROM " + SQLTableName + " WHERE USERNAME = '" + username + "'");
         if (reader.HasRows)
         {
            reader.Read();
            return reader.GetString(0);
         }
         else
            return "ERROR";
      }
      public int GetInt(String username)
      {
         QuerySQL("SELECT ID FROM " + SQLTableName + " WHERE USERNAME = '" + username + "'");
         if (reader.HasRows)
         {
            reader.Read();
            return reader.GetInt32(0);
         }
         else
            return -1;
      }
      public String[] SelectByUsername(String username)
      {
         String[] ReturnValue = { "", "", "", "" };
         QuerySQL("SELECT USERNAME, PASSWORD, FULLNAME, EMAIL FROM USERS WHERE USERNAME='" + username + "'");

         reader.Read();
         ReturnValue[0] = reader.GetString(0);
         ReturnValue[1] = reader.GetString(1);
         ReturnValue[2] = reader.GetString(2);
         ReturnValue[3] = reader.GetString(3);

         return ReturnValue;
      }
      public String Getemail(String username)
      {
         QuerySQL("SELECT EMAIL FROM " + SQLTableName + " WHERE USERNAME = '" + username + "'");
         if (reader.HasRows)
         {
            reader.Read();
            return reader.GetString(0);
         }
         else
            return "ERROR";
      }
      public int SelectBiggestInt()
      {
         QuerySQL("SELECT MAX(ID) FROM " + SQLTableName);
         reader.Read();

         return reader.GetInt32(0) + 1;
      }
   }
}