using System.Text;

namespace Common.Helper.Extensions;

public static class ExceptionExtensions
{
    public static string ErrorText(this Exception ex)
    {
        var errorText = new StringBuilder(ex.Message);
        var ex1 = ex;
        while (ex1.InnerException != null)
        {
            errorText.Append($"\n{ex1.InnerException.Message}");
            ex1 = ex1.InnerException;
        }

        return errorText.ToString();
    }

    public static List<string> ErrorTextList(this Exception ex)
    {
        var errorText = new List<string> { ex.Message };
        var ex1 = ex;
        while (ex1.InnerException != null)
        {
            errorText.Add(ex1.Message);
            ex1 = ex1.InnerException;
        }

        return errorText;
    }
}
