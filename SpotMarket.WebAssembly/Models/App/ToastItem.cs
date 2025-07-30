public class ToastItem
{
    public string Id { get; set; }
    public string Message { get; set; }
    public ToastType Type { get; set; }

    public string IconClass => Type switch
    {
        ToastType.Success => "bi-check-circle-fill",
        ToastType.Info => "bi-info-circle-fill",
        ToastType.Warning => "bi-exclamation-triangle-fill",
        ToastType.Error => "bi-x-circle-fill",
        _ => "bi-info-circle-fill"
    };
}