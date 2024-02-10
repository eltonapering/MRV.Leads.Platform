using System.ComponentModel;

namespace MRV.Leads.Platform.Domain.Enums;

public enum Category
{

    [Description("Undefined")]
    undefined = 0,

    [Description("Painters")]
    painters = 1,

    [Description("Interior Painters")]
    interiorPainters = 2,

    [Description("General Building Work")]
    demolition = 3,

    [Description("Home Renovations")]
    building = 4,
}
