using System;

namespace MimosiGeDb.Models;

public sealed class GroupMaterial
{

    private Material? _materialNavigation;
    public int GmtId { get; set; }

    /// <summary>
    ///     ჯგუფის იდენტიფიკატორი
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    ///     მასალის იდენტიფიკატორი
    /// </summary>
    public int MatId { get; set; }

    /// <summary>
    ///     გააქტიურების თარიღი
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    ///     გაუქმების თარიღი
    /// </summary>
    public DateTime? EndDate { get; set; }

    private Group? _groupNavigation;
    public Group GroupNavigation
    {
        get =>
            _groupNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(GroupNavigation));
        set => _groupNavigation = value;
    }

    public Material MaterialNavigation
    {
        get =>
            _materialNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(MaterialNavigation));
        set => _materialNavigation = value;
    }
}