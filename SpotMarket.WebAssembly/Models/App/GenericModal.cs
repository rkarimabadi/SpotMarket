
using Microsoft.AspNetCore.Components;

public class GenericModal
    {
    public RenderFragment Body { get; set; }
    public string Label { get; set; } = "آیتم جدید";
    public string FormName { get; set; } = "";
    public bool ShowSaveButton { get; set; } = true;
    public bool ShowDeleteButton { get; set; } = false;
    public string DeleteConfirmationMessage { get; set; } = "آیا از حذف این آیتم مطمئن هستید؟";
}