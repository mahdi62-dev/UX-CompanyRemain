using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace APP
{
    public class MaskValid
    {
        public static string MaskPersian = @"[ابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیءئآ ]+";
        public static string MaskPersianWithNum = @"[ابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیءئآ)(0123456789 ]+";

        public static string MaskEnglish = @"\p{L}+\s+\p{L}+\s+\p{L}+\s+\p{L}+";
        public static string MaskEnglishWithNum = @"[0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ]+";

        public static string MaskEnglishWithNumChar =
            @"[0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()_+-=.,';>< ]+";

        // public static string MaskEmail = @"[0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@_.]+";
        public static string MaskEmail = @"(\w|[.-])+@(\w|-)+\.(\w|-){2,4}";

        public static string MaskNumWithDecimal = @"[/.0123456789]+";
        public static string MaskNum = @"[0123456789]+";
        public static string MaskNationalCode = @"[0123456789]{10}";
        public static string MaskMobile = @"[0123456789]{11}";
        public static string MaskNumNegative = @"[0123456789-]+";
        public static string MaskNumWithComma = @"[0123456789,]+";


        public bool NationalCodeCValidate(string nationalCode)
        {
            bool isValidNationalCode = true;

            ////در صورتی که کد ملی وارد شده تهی باشد
            //if (String.IsNullOrEmpty(nationalCode))
            //    isValidNationalCode = false;


            //در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
            if (nationalCode.Length != 10)
            {
                isValidNationalCode = false;
            }

            //در صورتی که کد ملی ده رقم عددی نباشد
            Regex regex = new Regex(@"\d{10}");
            if (!regex.IsMatch(nationalCode))
            {
                isValidNationalCode = false;
            }

            //در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
            string[] allDigitEqual = new[]
            {
                "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666",
                "7777777777", "8888888888", "9999999999"
            };
            if (((IList)allDigitEqual).Contains(nationalCode))
            {
                isValidNationalCode = false;
            }

            if (isValidNationalCode) //تا اینجا مشکلی نداشته باشد
            {
                //عملیات شرح داده شده در بالا
                char[] chArray = nationalCode.ToCharArray();
                int num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
                int num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
                int num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
                int num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
                int num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
                int num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
                int num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
                int num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
                int num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
                int a = Convert.ToInt32(chArray[9].ToString());

                int b = num0 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9;
                int c = b % 11;

                isValidNationalCode = c < 2 && a == c || c >= 2 && 11 - c == a;
            }

            return isValidNationalCode;
        }

        public bool MobileValidate(string Mobile)
        {
            bool isMobile = true;

            //در صورتی که مبایل وارد شده طولش کمتر از 10 رقم باشد
            if (Mobile.Length != 11)
            {
                isMobile = false;
            }

            if (Mobile.Substring(0, 2) != "09")
            {
                isMobile = false;
            }


            return isMobile;
        }
    }
}