namespace PSTodos.WebForms
{
    public class Toastr
    {
        public string Message { get; set; }
        public ToastType ToastType { get; set; }
    }

    public enum ToastType
    {
        Error,
        Info,
        Success,
        Warning
    }
}