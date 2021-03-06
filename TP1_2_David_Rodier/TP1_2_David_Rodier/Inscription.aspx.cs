﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_2_David_Rodier
{
   public partial class Inscription : System.Web.UI.Page
   {
      public static String UserName = "";
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!Page.IsPostBack)
         {
            Session["captcha"] = BuildCaptcha();
         }
      }

      Random random = new Random();
      char RandomChar()
      {
         // les lettres comportant des ambiguïtées ne sont pas dans la liste
         // exmple: 0 et O ont été retirés
         string chars = "abcdefghkmnpqrstuvwvxyzABCDEFGHKMNPQRSTUVWXYZ23456789";
         return chars[random.Next(0, chars.Length)];
      }

      Color RandomColor(int min, int max)
      {
         return Color.FromArgb(255, random.Next(min, max), random.Next(min, max), random.Next(min, max));
      }

      string Captcha()
      {
         string captcha = "";

         for (int i = 0; i < 5; i++)
            captcha += RandomChar();
         return captcha;//.ToLower();
      }

      string BuildCaptcha()
      {
         int width = 200;
         int height = 70;
         Bitmap bitmap = new Bitmap(width, height);
         Graphics DC = Graphics.FromImage(bitmap);
         SolidBrush brush = new SolidBrush(RandomColor(0, 127));
         SolidBrush pen = new SolidBrush(RandomColor(172, 255));
         DC.FillRectangle(brush, 0, 0, 200, 100);
         Font font = new Font("Snap ITC", 32, FontStyle.Regular);
         PointF location = new PointF(5f, 5f);
         DC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
         string captcha = Captcha();
         DC.DrawString(captcha, font, pen, location);

         // noise generation
         for (int i = 0; i < 5000; i++)
         {
            bitmap.SetPixel(random.Next(0, width), random.Next(0, height), RandomColor(127, 255));
         }
         bitmap.Save(Server.MapPath("Captcha.png"), ImageFormat.Png);
         return captcha;
      }

      protected void RegenarateCaptcha_Click(object sender, ImageClickEventArgs e)
      {
         Session["captcha"] = BuildCaptcha();
         // + DateTime.Now.ToString() pour forcer le fureteur recharger le fichier
         IMGCaptcha.ImageUrl = "~/Captcha.png?ID=" + DateTime.Now.ToString();
         PN_Captcha.Update();
      }
      protected void BTN_Submit_Click(object sender, EventArgs e)
      {
         if (Page.IsValid)
         {
            USERS users = new USERS((string)Application["DB"], this);
            users.ID = users.SelectBiggestInt();
            users.UserName = TB_Username.Text;
            users.Password = TB_Password.Text;
            users.FullName = TB_Name.Text;
            users.Email = TB_Email.Text;
            users.Insert();

            Session["message"] = "(Inscription réussie - complétez maintenant votre profil...)";
            Response.Redirect("Login.aspx");
         }
      }
      protected void CV_Captcha_ServerValidate(object source, ServerValidateEventArgs args)
      {
         args.IsValid = (TB_Captcha.Text == (string)Session["captcha"]);
      }
      protected void CV_ConfirmPassword_OnClick(object source, ServerValidateEventArgs args)
      {
         if (TB_ConfirmPassword.Text == "")
         {
            args.IsValid = false;
         }
         else
         {
            args.IsValid = (TB_ConfirmPassword.Text == TB_Password.Text);
         }
      }
      protected void CV_ConfirmEmail_OnClick(object source, ServerValidateEventArgs args)
      {
         if (TB_ConfirmEmail.Text == "")
         {
            args.IsValid = false;
         }
         else
         {
            args.IsValid = (TB_ConfirmEmail.Text == TB_Email.Text);
         }
      }
   }
}