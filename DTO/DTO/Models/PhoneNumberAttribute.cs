using System;
using System.ComponentModel.DataAnnotations;

public class PhoneNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null)
            return true;

        var phoneNumber = value.ToString();

        // Check if the phone number is 10 characters long
        if (phoneNumber.Length != 10)
            return false;

        // Check if the phone number starts with 0
        if (!phoneNumber.StartsWith("0"))
            return false;

        return true;
    }
}
