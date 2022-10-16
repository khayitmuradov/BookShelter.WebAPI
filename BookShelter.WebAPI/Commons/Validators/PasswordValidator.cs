namespace BookShelter.WebAPI.Commons.Validators;

public class PasswordValidator
{
    public static (bool IsValid, string Message) IsStrong(string password)
    {
        bool isLower = false;
        bool isUpper = false;
        bool isDigit = false;
        bool isChar = false;
        for (int i = 0; i < password.Length; i++)
        {
            int k = (int)password[i];
            if (k >= 97 && k <= 122)
                isLower = true;
            else if (k >= 65 && k <= 90)
                isUpper = true;
            else if (k >= 48 && k <= 57)
                isDigit = true;
            else if (k > 32 && k < 127)
                isChar = true;
        }

        if (!isLower)
        {
            return (IsValid: false, Message: "Password must have at least 1 lower letter");
        }
        if (!isUpper)
        {
            return (IsValid: false, Message: "Password must have at least 1 upper letter");
        }
        if (!isDigit)
        {
            return (IsValid: false, Message: "Password must have at least 1 digit");
        }
        if (!isChar)
        {
            return (IsValid: false, Message: "Password must have at least 1 character");
        }

        return (IsValid: true, Message: "Password is hell strong bro!");
    }
}
