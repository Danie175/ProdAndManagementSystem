public static class CodeIdGenerator
{
    public static string GenerateCodeId(string fullName)
    {
        //if (string.IsNullOrWhiteSpace(fullName))
        //    return "cus-xx-0000";

        var parts = fullName.Trim().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string initials = string.Join("", parts.Select(w => w[0]));
        string firstName = parts[0];

        int numeric = ConvertFirstNameToNumber(firstName);
        return $"cus-{initials}-{numeric:D4}";
    }

    private static int ConvertFirstNameToNumber(string name)
    {
        // Simple sum of ASCII values mod 10000
        return name.ToLower().Sum(c => (int)c) % 10000;
    }
}
