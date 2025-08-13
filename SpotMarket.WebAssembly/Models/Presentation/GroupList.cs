using System.Collections.Generic;

namespace SpotMarket.WebAssembly.Models.Presentation
{
    /// <summary>
    /// وضعیت فعالیت یک گروه را مشخص می‌کند
    /// </summary>
    public enum GroupActivityStatus
    {
        HasOfferToday,      // عرضه امروز
        HasUpcomingOffer,   // عرضه در آینده
        Inactive            // سایر موارد (غیرفعال)
    }

    /// <summary>
    /// نمایانگر یک آیتم در لیست گروه‌های زیرمجموعه است
    /// </summary>
    public class GroupListItem
    {
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty; // زیرگروه های این گروه
        public string UrlName { get; set; } = string.Empty; // برای ناوبری
        public GroupActivityStatus Status { get; set; } = GroupActivityStatus.Inactive;
        public int? OfferCount { get; set; } // تعداد عرضه امروز یا آینده
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت لیست گروه‌های زیرمجموعه
    /// </summary>
    public class GroupListData
    {
        public List<GroupListItem> Items { get; set; } = new();
    }
}
