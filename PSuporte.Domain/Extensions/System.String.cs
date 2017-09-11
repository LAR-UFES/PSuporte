using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PSuporte.Domain.Extensions
{
    public static class StringExtension
    {
        public static bool IsValidEmail(this string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrEmpty(value);
        }
    }
}